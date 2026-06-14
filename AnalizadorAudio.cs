using System;
using System.IO;

namespace ReproductorMusical
{
    internal class AnalizadorAudio
    {
        private float[] muestrasAudio    = new float[0];
        private int     frecuenciaMuestreo = 44100;

        public bool Disponible { get; private set; }

        // ── API pública ───────────────────────────────────────────────────────────

        public void CargarArchivo(string archivo)
        {
            Disponible = false;
            muestrasAudio = new float[0];

            if (string.Compare(Path.GetExtension(archivo), ".wav", StringComparison.OrdinalIgnoreCase) != 0)
                return;

            try
            {
                LeerWavPcm16(archivo);
                Disponible = muestrasAudio.Length > 0;
            }
            catch
            {
                Disponible = false;
                muestrasAudio = new float[0];
            }
        }

        public void Limpiar()
        {
            muestrasAudio = new float[0];
            Disponible = false;
        }

        public float ObtenerEnergia(int posicionMs)
        {
            if (!Disponible || muestrasAudio.Length == 0) return -1f;

            int posicion = ObtenerIndiceMuestra(posicionMs);
            int ventana  = Math.Min(2048, muestrasAudio.Length);
            int inicio   = Math.Max(0, posicion - ventana / 2);
            int fin      = Math.Min(muestrasAudio.Length, inicio + ventana);
            if (fin <= inicio) return 0f;

            double sumaCuadrados = 0;
            for (int i = inicio; i < fin; i++)
                sumaCuadrados += muestrasAudio[i] * muestrasAudio[i];

            double rms = Math.Sqrt(sumaCuadrados / (fin - inicio));
            return Limitar01((float)(rms * 4.5));
        }

        public float[] ObtenerBandasCompletas(int cantidad, int posicionMs, float energia, float fase)
        {
            return Disponible ? ObtenerBandas(cantidad, posicionMs) : ObtenerBandasMatematicas(cantidad, energia, fase);
        }

        // ── Implementación privada ────────────────────────────────────────────────

        private float[] ObtenerBandas(int cantidad, int posicionMs)
        {
            float[] bandas  = new float[cantidad];
            int posicion    = ObtenerIndiceMuestra(posicionMs);
            int ventana     = 1024;
            int inicio      = Math.Max(0, posicion - ventana / 2);
            if (inicio + ventana >= muestrasAudio.Length)
                inicio = Math.Max(0, muestrasAudio.Length - ventana - 1);

            const double freqMin = 40.0;
            const double freqMax = 18000.0;

            for (int banda = 0; banda < cantidad; banda++)
            {
                double freqCentral = freqMin * Math.Pow(freqMax / freqMin, banda / (double)(cantidad - 1));
                int bin = Math.Max(1, (int)(freqCentral * ventana / frecuenciaMuestreo));
                bin = Math.Min(bin, ventana / 2 - 1);

                double real = 0, imaginario = 0;
                for (int n = 0; n < ventana && inicio + n < muestrasAudio.Length; n++)
                {
                    double vent  = 0.5 - 0.5 * Math.Cos(2.0 * Math.PI * n / (ventana - 1));
                    double muestra = muestrasAudio[inicio + n] * vent;
                    double angulo  = 2.0 * Math.PI * bin * n / ventana;
                    real      += muestra * Math.Cos(angulo);
                    imaginario -= muestra * Math.Sin(angulo);
                }

                double magnitud = Math.Sqrt(real * real + imaginario * imaginario) / ventana;
                float boost = 1.0f + (banda / (float)(cantidad - 1)) * 3.5f;
                bandas[banda] = Limitar01((float)(magnitud * 18.0 * boost));
            }

            return bandas;
        }

        public float[] ObtenerBandasMatematicas(int cantidad, float energia, float fase)
        {
            float[] bandas = new float[cantidad];
            for (int i = 0; i < cantidad; i++)
            {
                double t     = i / (double)(cantidad - 1);
                double onda  = Math.Abs(Math.Sin(fase * 1.7 + i * 0.43));
                double pulso = Math.Abs(Math.Sin(fase * 0.55 + i * 0.18));
                float boost  = 0.5f + (float)t * 1.2f;
                bandas[i] = Limitar01((float)((energia * 0.45 + onda * 0.38 + pulso * 0.22) * boost));
            }
            return bandas;
        }

        private int ObtenerIndiceMuestra(int posicionMs)
        {
            long indice = (long)posicionMs * frecuenciaMuestreo / 1000;
            if (indice < 0) return 0;
            if (indice >= muestrasAudio.Length) return Math.Max(0, muestrasAudio.Length - 1);
            return (int)indice;
        }

        private void LeerWavPcm16(string archivo)
        {
            using (BinaryReader lector = new BinaryReader(File.OpenRead(archivo)))
            {
                string riff = new string(lector.ReadChars(4));
                lector.ReadInt32();
                string wave = new string(lector.ReadChars(4));

                if (riff != "RIFF" || wave != "WAVE")
                    throw new InvalidDataException("El archivo no es WAV RIFF.");

                short canales = 0, bitsPorMuestra = 0, formatoAudio = 0;
                byte[] datos = null;

                while (lector.BaseStream.Position < lector.BaseStream.Length)
                {
                    string chunkId   = new string(lector.ReadChars(4));
                    int    chunkSize = lector.ReadInt32();

                    if (chunkId == "fmt ")
                    {
                        formatoAudio   = lector.ReadInt16();
                        canales        = lector.ReadInt16();
                        frecuenciaMuestreo = lector.ReadInt32();
                        lector.ReadInt32();
                        lector.ReadInt16();
                        bitsPorMuestra = lector.ReadInt16();
                        if (chunkSize > 16) lector.BaseStream.Position += chunkSize - 16;
                    }
                    else if (chunkId == "data")
                    {
                        datos = lector.ReadBytes(chunkSize);
                    }
                    else
                    {
                        lector.BaseStream.Position += chunkSize;
                    }
                }

                if (formatoAudio != 1 || bitsPorMuestra != 16 || canales <= 0 || datos == null)
                    throw new InvalidDataException("Solo se analiza WAV PCM de 16 bits.");

                int totalFrames = datos.Length / (2 * canales);
                muestrasAudio = new float[totalFrames];

                for (int frame = 0; frame < totalFrames; frame++)
                {
                    int suma = 0;
                    for (int canal = 0; canal < canales; canal++)
                    {
                        int   indice = (frame * canales + canal) * 2;
                        short muestra = BitConverter.ToInt16(datos, indice);
                        suma += muestra;
                    }
                    muestrasAudio[frame] = (suma / (float)canales) / 32768f;
                }
            }
        }

        private static float Limitar01(float v)
        {
            return v < 0f ? 0f : v > 1f ? 1f : v;
        }
    }
}

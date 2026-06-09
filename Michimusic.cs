using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace ReproductorMusical
{
    public partial class Michimusic : Form
    {
        private readonly Color cremaRetro = Color.FromArgb(245, 230, 189);
        private readonly Color mostazaSuave = Color.FromArgb(223, 160, 93);
        private readonly Color rojoLadrillo = Color.FromArgb(172, 80, 69);
        private readonly Color verdeVintage = Color.FromArgb(101, 135, 97);
        private readonly Color azulPetroleo = Color.FromArgb(2, 108, 128);
        private readonly Color negroSuave = Color.FromArgb(26, 31, 37);
        private readonly Color amarilloRetro = Color.FromArgb(249, 162, 4);

        private readonly List<string> canciones = new List<string>();
        private readonly Timer timerReproduccion = new Timer();
        private readonly Timer timerAnimacion = new Timer();
        private readonly Random aleatorio = new Random();
        private readonly List<ParticulaVisual> particulas = new List<ParticulaVisual>();

        private dynamic reproductor;
        private bool reproductorDisponible;
        private int indiceCancionActual = -1;
        private int duracionActualMs;
        private bool cancionAbierta;
        private bool reproduciendo;
        private bool enPausa;
        private float faseAnimacion;
        private float[] muestrasAudio = new float[0];
        private float[] bandasAudio = new float[32];
        private int frecuenciaMuestreo = 44100;
        private bool analisisAudioDisponible;

        public Michimusic()
        {
            InitializeComponent();
            InicializarInterfaz();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            DetenerTimer();
            timerAnimacion.Stop();
            CerrarCancionActual();
            LiberarReproductor();
            base.OnFormClosing(e);
        }

        private void InicializarInterfaz()
        {
            ConfigurarEstilos();
            ConfigurarPanelVisualizador();
            ConfigurarReproductor();

            cmbModoVisual.SelectedIndex = 0;
            trackVolumen.Value = 50;
            ActualizarVolumen();
            CargarCancionesDesdeCarpeta();
        }

        private void ConfigurarEstilos()
        {
            BackColor = cremaRetro;

            panelHeader.BackColor = Color.FromArgb(122, 38, 28);
            panelSelectorVisual.BackColor = cremaRetro;
            panelListaCanciones.BackColor = negroSuave;
            panelControles.BackColor = cremaRetro;
            panelFooter.BackColor = negroSuave;
            panelMarcoVisualizador.BackColor = negroSuave;
            panelVisualizador.BackColor = Color.FromArgb(1, 82, 98);

            lblTitulo.ForeColor = cremaRetro;
            lblSubtitulo.ForeColor = Color.FromArgb(255, 218, 151);
            lblModoVisual.ForeColor = negroSuave;
            lblListaCanciones.ForeColor = cremaRetro;
            lblVolumen.ForeColor = negroSuave;
            lblTiempo.ForeColor = negroSuave;
            lblCancionActual.ForeColor = cremaRetro;
            lblEstado.ForeColor = cremaRetro;

            picLogo.BackColor = cremaRetro;
            picLogo.BorderStyle = BorderStyle.FixedSingle;

            CrearBotonPixel(btnCargar, mostazaSuave, amarilloRetro);
            CrearBotonPixel(btnAnterior, azulPetroleo, Color.FromArgb(5, 132, 154));
            CrearBotonPixel(btnPlay, verdeVintage, Color.FromArgb(120, 156, 112));
            CrearBotonPixel(btnPause, amarilloRetro, mostazaSuave);
            CrearBotonPixel(btnStop, rojoLadrillo, Color.FromArgb(191, 94, 82));
            CrearBotonPixel(btnSiguiente, azulPetroleo, Color.FromArgb(5, 132, 154));

            btnAnterior.ForeColor = cremaRetro;
            btnPlay.ForeColor = cremaRetro;
            btnStop.ForeColor = cremaRetro;
            btnSiguiente.ForeColor = cremaRetro;
            cmbModoVisual.BackColor = Color.FromArgb(255, 241, 204);
            cmbModoVisual.ForeColor = negroSuave;
            lstCanciones.BackColor = Color.FromArgb(255, 241, 204);
            lstCanciones.ForeColor = negroSuave;
            lstCanciones.HorizontalScrollbar = true;
            lstCancionesMp3.BackColor = Color.FromArgb(255, 241, 204);
            lstCancionesMp3.ForeColor = negroSuave;
            lstCancionesMp3.HorizontalScrollbar = true;
            lblListaMp3.ForeColor = cremaRetro;
        }

        private void ConfigurarReproductor()
        {
            CrearReproductorWindowsMedia();

            timerReproduccion.Interval = 250;
            timerReproduccion.Tick += timerReproduccion_Tick;

            timerAnimacion.Interval = 33;
            timerAnimacion.Tick += timerAnimacion_Tick;
            timerAnimacion.Start();

            btnCargar.Click += btnCargar_Click;
            btnAnterior.Click += btnAnterior_Click;
            btnPlay.Click += btnPlay_Click;
            btnPause.Click += btnPause_Click;
            btnStop.Click += btnStop_Click;
            btnSiguiente.Click += btnSiguiente_Click;
            lstCanciones.DoubleClick += lstCanciones_DoubleClick;
            lstCancionesMp3.DoubleClick += lstCancionesMp3_DoubleClick;
        }

        private void CrearReproductorWindowsMedia()
        {
            try
            {
                Type tipoReproductor = Type.GetTypeFromProgID("WMPlayer.OCX");

                if (tipoReproductor == null)
                {
                    lblEstado.Text = "Estado: Windows Media no disponible";
                    return;
                }

                reproductor = Activator.CreateInstance(tipoReproductor);
                reproductor.settings.autoStart = false;
                reproductorDisponible = true;
            }
            catch
            {
                reproductorDisponible = false;
                lblEstado.Text = "Estado: Error al iniciar reproductor";
            }
        }

        private void CrearBotonPixel(Button boton, Color colorBase, Color colorHover)
        {
            boton.BackColor = colorBase;
            boton.ForeColor = negroSuave;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderColor = negroSuave;
            boton.FlatAppearance.BorderSize = 3;
            boton.FlatAppearance.MouseOverBackColor = colorHover;
            boton.FlatAppearance.MouseDownBackColor = Color.FromArgb(245, 185, 76);
            boton.ImageAlign = ContentAlignment.MiddleCenter;
            boton.TextAlign = ContentAlignment.MiddleCenter;
            boton.TextImageRelation = TextImageRelation.Overlay;
        }

        private void ConfigurarPanelVisualizador()
        {
            ActivarDobleBuffer(panelVisualizador);
            panelVisualizador.Paint += panelVisualizador_Paint;
            panelVisualizador.Resize += panelVisualizador_Resize;
            InicializarParticulas();
            panelMarcoVisualizador.Invalidate();
        }

        private void ActivarDobleBuffer(Control control)
        {
            System.Reflection.PropertyInfo propiedad = typeof(Control).GetProperty(
                "DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            if (propiedad != null)
            {
                propiedad.SetValue(control, true, null);
            }
        }

        private void CargarCancionesDesdeCarpeta()
        {
            string carpetaCanciones = ObtenerCarpetaCanciones();

            if (!Directory.Exists(carpetaCanciones))
            {
                Directory.CreateDirectory(carpetaCanciones);
            }

            canciones.Clear();
            canciones.AddRange(Directory.GetFiles(carpetaCanciones, "*.wav"));
            canciones.AddRange(Directory.GetFiles(carpetaCanciones, "*.mp3"));
            canciones.AddRange(Directory.GetFiles(carpetaCanciones, "*.wma"));
            canciones.AddRange(Directory.GetFiles(carpetaCanciones, "*.mid"));

            if (canciones.Count > 0)
            {
                indiceCancionActual = 0;
                lblCancionActual.Text = "Canción actual: " + Path.GetFileName(canciones[indiceCancionActual]);
                lblEstado.Text = "Estado: " + canciones.Count + " canción(es) en carpeta";
                ActualizarListaCanciones();
                SeleccionarCancionEnLista();
            }
            else
            {
                indiceCancionActual = -1;
                lblCancionActual.Text = "Canción actual: Ninguna canción cargada";
                lblEstado.Text = "Estado: Listo";
                ActualizarListaCanciones();
            }
        }

        private string ObtenerCarpetaCanciones()
        {
            string carpetaDelProyecto = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\Canciones"));

            if (Directory.Exists(carpetaDelProyecto))
            {
                return carpetaDelProyecto;
            }

            return Path.Combine(Application.StartupPath, "Canciones");
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialogo = new OpenFileDialog())
            {
                dialogo.Title = "Cargar canciones";
                dialogo.Filter = "Archivos de audio|*.mp3;*.wav;*.wma;*.mid|Todos los archivos|*.*";
                dialogo.Multiselect = true;

                if (dialogo.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                DetenerTimer();
                CerrarCancionActual();

                canciones.Clear();
                canciones.AddRange(dialogo.FileNames);
                indiceCancionActual = 0;
                ActualizarListaCanciones();

                AbrirCancionActual();
                SeleccionarCancionEnLista();
                lblEstado.Text = cancionAbierta ? "Estado: Canción cargada" : "Estado: No se pudo cargar";
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Reproducir();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (!cancionAbierta || !reproduciendo || !reproductorDisponible)
            {
                return;
            }

            if (enPausa)
            {
                reproductor.controls.play();
                enPausa = false;
                lblEstado.Text = "Estado: Reproduciendo";
            }
            else
            {
                reproductor.controls.pause();
                enPausa = true;
                lblEstado.Text = "Estado: Pausado";
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            DetenerReproduccion();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            CambiarCancion(-1);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            CambiarCancion(1);
        }

        private void lstCanciones_DoubleClick(object sender, EventArgs e)
        {
            int indice = ObtenerIndiceCancionPorExtension(".wav", lstCanciones.SelectedIndex);

            if (indice < 0)
            {
                return;
            }

            DetenerTimer();
            CerrarCancionActual();
            indiceCancionActual = indice;
            SeleccionarCancionEnLista();
            AbrirCancionActual();
            Reproducir();
        }

        private void lstCancionesMp3_DoubleClick(object sender, EventArgs e)
        {
            int indice = ObtenerIndiceCancionPorExtension(".mp3", lstCancionesMp3.SelectedIndex);

            if (indice < 0)
            {
                return;
            }

            DetenerTimer();
            CerrarCancionActual();
            indiceCancionActual = indice;
            SeleccionarCancionEnLista();
            AbrirCancionActual();
            Reproducir();
        }

        private void trackVolumen_ValueChanged(object sender, EventArgs e)
        {
            ActualizarVolumen();
            AplicarVolumen();
        }

        private void timerReproduccion_Tick(object sender, EventArgs e)
        {
            if (!cancionAbierta || !reproductorDisponible)
            {
                return;
            }

            int posicion = ObtenerPosicionActualMs();
            duracionActualMs = ObtenerDuracionActualMs();
            lblTiempo.Text = FormatearTiempo(posicion) + " / " + FormatearTiempo(duracionActualMs);

            if (reproduciendo && !enPausa && EsFinDeCancion(posicion))
            {
                CambiarCancion(1);
            }
        }

        private void timerAnimacion_Tick(object sender, EventArgs e)
        {
            faseAnimacion += reproduciendo && !enPausa ? 0.13f : 0.035f;
            ActualizarParticulas();
            panelVisualizador.Invalidate();
        }

        private void Reproducir()
        {
            if (!reproductorDisponible)
            {
                lblEstado.Text = "Estado: Reproductor no disponible";
                return;
            }

            if (canciones.Count == 0)
            {
                CargarCancionesDesdeCarpeta();
            }

            if (canciones.Count == 0)
            {
                lblEstado.Text = "Estado: Sin canciones";
                return;
            }

            if (indiceCancionActual < 0)
            {
                indiceCancionActual = 0;
            }

            if (!cancionAbierta)
            {
                AbrirCancionActual();
            }

            if (!cancionAbierta)
            {
                return;
            }

            reproductor.controls.play();
            reproduciendo = true;
            enPausa = false;
            timerReproduccion.Start();
            lblEstado.Text = "Estado: Reproduciendo";
        }

        private void DetenerReproduccion()
        {
            if (!cancionAbierta || !reproductorDisponible)
            {
                lblTiempo.Text = "00:00 / 00:00";
                lblEstado.Text = "Estado: Listo";
                return;
            }

            reproductor.controls.stop();
            reproductor.controls.currentPosition = 0;
            reproduciendo = false;
            enPausa = false;
            lblTiempo.Text = "00:00 / " + FormatearTiempo(duracionActualMs);
            lblEstado.Text = "Estado: Detenido";
        }

        private void CambiarCancion(int direccion)
        {
            if (canciones.Count == 0)
            {
                CargarCancionesDesdeCarpeta();
            }

            if (canciones.Count == 0)
            {
                lblEstado.Text = "Estado: Sin canciones";
                return;
            }

            bool reproducirLuego = reproduciendo && !enPausa;
            indiceCancionActual += direccion;

            if (indiceCancionActual < 0)
            {
                indiceCancionActual = canciones.Count - 1;
            }
            else if (indiceCancionActual >= canciones.Count)
            {
                indiceCancionActual = 0;
            }

            CerrarCancionActual();
            AbrirCancionActual();
            SeleccionarCancionEnLista();

            if (reproducirLuego)
            {
                Reproducir();
            }
        }

        private void AbrirCancionActual()
        {
            if (indiceCancionActual < 0 || indiceCancionActual >= canciones.Count)
            {
                return;
            }

            string archivo = canciones[indiceCancionActual];

            if (!File.Exists(archivo))
            {
                lblEstado.Text = "Estado: Archivo no encontrado";
                return;
            }

            if (!reproductorDisponible)
            {
                lblEstado.Text = "Estado: Reproductor no disponible";
                return;
            }

            try
            {
                reproductor.URL = archivo;
                AplicarVolumen();
                CargarAnalisisAudio(archivo);

                cancionAbierta = true;
                duracionActualMs = ObtenerDuracionActualMs();
                lblCancionActual.Text = "Canción actual: " + Path.GetFileName(archivo);
                lblTiempo.Text = "00:00 / " + FormatearTiempo(duracionActualMs);
                SeleccionarCancionEnLista();
            }
            catch
            {
                cancionAbierta = false;
                lblEstado.Text = "Estado: No se pudo abrir el audio";
            }
        }

        private void CerrarCancionActual()
        {
            if (reproductorDisponible && reproductor != null)
            {
                try
                {
                    reproductor.controls.stop();
                    reproductor.URL = string.Empty;
                }
                catch
                {
                    // Cierre defensivo del componente de audio.
                }
            }

            cancionAbierta = false;
            reproduciendo = false;
            enPausa = false;
            duracionActualMs = 0;
            analisisAudioDisponible = false;
            muestrasAudio = new float[0];
            bandasAudio = new float[32];
        }

        private void AplicarVolumen()
        {
            if (reproductorDisponible && reproductor != null)
            {
                reproductor.settings.volume = trackVolumen.Value;
            }
        }

        private void ActualizarVolumen()
        {
            lblVolumen.Text = "Volumen: " + trackVolumen.Value + "%";
        }

        private void CargarAnalisisAudio(string archivo)
        {
            analisisAudioDisponible = false;
            muestrasAudio = new float[0];
            bandasAudio = new float[32];

            if (Path.GetExtension(archivo).ToLowerInvariant() != ".wav")
            {
                return;
            }

            try
            {
                LeerWavPcm16(archivo);
                analisisAudioDisponible = muestrasAudio.Length > 0;
            }
            catch
            {
                analisisAudioDisponible = false;
                muestrasAudio = new float[0];
            }
        }

        private void LeerWavPcm16(string archivo)
        {
            using (BinaryReader lector = new BinaryReader(File.OpenRead(archivo)))
            {
                string riff = new string(lector.ReadChars(4));
                lector.ReadInt32();
                string wave = new string(lector.ReadChars(4));

                if (riff != "RIFF" || wave != "WAVE")
                {
                    throw new InvalidDataException("El archivo no es WAV RIFF.");
                }

                short canales = 0;
                short bitsPorMuestra = 0;
                short formatoAudio = 0;
                byte[] datos = null;

                while (lector.BaseStream.Position < lector.BaseStream.Length)
                {
                    string chunkId = new string(lector.ReadChars(4));
                    int chunkSize = lector.ReadInt32();

                    if (chunkId == "fmt ")
                    {
                        formatoAudio = lector.ReadInt16();
                        canales = lector.ReadInt16();
                        frecuenciaMuestreo = lector.ReadInt32();
                        lector.ReadInt32();
                        lector.ReadInt16();
                        bitsPorMuestra = lector.ReadInt16();

                        if (chunkSize > 16)
                        {
                            lector.BaseStream.Position += chunkSize - 16;
                        }
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
                {
                    throw new InvalidDataException("Solo se analiza WAV PCM de 16 bits.");
                }

                int totalFrames = datos.Length / (2 * canales);
                muestrasAudio = new float[totalFrames];

                for (int frame = 0; frame < totalFrames; frame++)
                {
                    int suma = 0;

                    for (int canal = 0; canal < canales; canal++)
                    {
                        int indice = (frame * canales + canal) * 2;
                        short muestra = BitConverter.ToInt16(datos, indice);
                        suma += muestra;
                    }

                    muestrasAudio[frame] = (suma / (float)canales) / 32768f;
                }
            }
        }

        private float ObtenerEnergiaAudioReal()
        {
            if (!analisisAudioDisponible || muestrasAudio.Length == 0)
            {
                return -1f;
            }

            int posicion = ObtenerIndiceMuestraActual();
            int ventana = Math.Min(2048, muestrasAudio.Length);
            int inicio = Math.Max(0, posicion - ventana / 2);
            int fin = Math.Min(muestrasAudio.Length, inicio + ventana);

            if (fin <= inicio)
            {
                return 0f;
            }

            double sumaCuadrados = 0;

            for (int i = inicio; i < fin; i++)
            {
                sumaCuadrados += muestrasAudio[i] * muestrasAudio[i];
            }

            double rms = Math.Sqrt(sumaCuadrados / (fin - inicio));
            return Limitar01((float)(rms * 4.5));
        }

        private float[] ObtenerBandasAudio(int cantidadBandas)
        {
            if (!analisisAudioDisponible || muestrasAudio.Length == 0)
            {
                return ObtenerBandasMatematicas(cantidadBandas);
            }

            float[] bandas = new float[cantidadBandas];
            int posicion = ObtenerIndiceMuestraActual();
            int ventana = 1024;
            int inicio = Math.Max(0, posicion - ventana / 2);

            if (inicio + ventana >= muestrasAudio.Length)
            {
                inicio = Math.Max(0, muestrasAudio.Length - ventana - 1);
            }

            for (int banda = 0; banda < cantidadBandas; banda++)
            {
                int bin = 2 + banda * 2;
                double real = 0;
                double imaginario = 0;

                for (int n = 0; n < ventana && inicio + n < muestrasAudio.Length; n++)
                {
                    double ventanaHann = 0.5 - 0.5 * Math.Cos(2.0 * Math.PI * n / (ventana - 1));
                    double muestra = muestrasAudio[inicio + n] * ventanaHann;
                    double angulo = 2.0 * Math.PI * bin * n / ventana;
                    real += muestra * Math.Cos(angulo);
                    imaginario -= muestra * Math.Sin(angulo);
                }

                double magnitud = Math.Sqrt(real * real + imaginario * imaginario) / ventana;
                bandas[banda] = Limitar01((float)(magnitud * 18.0));
            }

            bandasAudio = bandas;
            return bandas;
        }

        private float[] ObtenerBandasMatematicas(int cantidadBandas)
        {
            float[] bandas = new float[cantidadBandas];
            float energia = ObtenerEnergiaVisual();

            for (int i = 0; i < cantidadBandas; i++)
            {
                double onda = Math.Abs(Math.Sin(faseAnimacion * 1.7 + i * 0.43));
                double pulso = Math.Abs(Math.Sin(faseAnimacion * 0.55 + i * 0.18));
                bandas[i] = Limitar01((float)(energia * 0.45 + onda * 0.38 + pulso * 0.22));
            }

            return bandas;
        }

        private int ObtenerIndiceMuestraActual()
        {
            int posicionMs = ObtenerPosicionActualMs();
            long indice = (long)posicionMs * frecuenciaMuestreo / 1000;

            if (indice < 0)
            {
                return 0;
            }

            if (indice >= muestrasAudio.Length)
            {
                return Math.Max(0, muestrasAudio.Length - 1);
            }

            return (int)indice;
        }

        private void ActualizarListaCanciones()
        {
            lstCanciones.Items.Clear();
            lstCancionesMp3.Items.Clear();

            int contadorWav = 1;
            int contadorMp3 = 1;

            for (int i = 0; i < canciones.Count; i++)
            {
                string extension = Path.GetExtension(canciones[i]).ToLowerInvariant();
                string nombre = Path.GetFileNameWithoutExtension(canciones[i]);

                if (extension == ".wav")
                {
                    lstCanciones.Items.Add(contadorWav.ToString("00") + "  " + nombre);
                    contadorWav++;
                }
                else if (extension == ".mp3")
                {
                    lstCancionesMp3.Items.Add(contadorMp3.ToString("00") + "  " + nombre);
                    contadorMp3++;
                }
            }
        }

        private void SeleccionarCancionEnLista()
        {
            lstCanciones.ClearSelected();
            lstCancionesMp3.ClearSelected();

            if (indiceCancionActual < 0 || indiceCancionActual >= canciones.Count)
            {
                return;
            }

            string extension = Path.GetExtension(canciones[indiceCancionActual]).ToLowerInvariant();

            if (extension == ".wav")
            {
                int indiceWav = ObtenerIndiceFiltrado(".wav", indiceCancionActual);

                if (indiceWav >= 0 && indiceWav < lstCanciones.Items.Count)
                {
                    lstCanciones.SelectedIndex = indiceWav;
                }
            }
            else if (extension == ".mp3")
            {
                int indiceMp3 = ObtenerIndiceFiltrado(".mp3", indiceCancionActual);

                if (indiceMp3 >= 0 && indiceMp3 < lstCancionesMp3.Items.Count)
                {
                    lstCancionesMp3.SelectedIndex = indiceMp3;
                }
            }
        }

        private int ObtenerIndiceCancionPorExtension(string extensionBuscada, int indiceFiltrado)
        {
            if (indiceFiltrado < 0)
            {
                return -1;
            }

            int contador = 0;

            for (int i = 0; i < canciones.Count; i++)
            {
                if (Path.GetExtension(canciones[i]).ToLowerInvariant() == extensionBuscada)
                {
                    if (contador == indiceFiltrado)
                    {
                        return i;
                    }

                    contador++;
                }
            }

            return -1;
        }

        private int ObtenerIndiceFiltrado(string extensionBuscada, int indiceGeneral)
        {
            int contador = 0;

            for (int i = 0; i < canciones.Count && i <= indiceGeneral; i++)
            {
                if (Path.GetExtension(canciones[i]).ToLowerInvariant() == extensionBuscada)
                {
                    if (i == indiceGeneral)
                    {
                        return contador;
                    }

                    contador++;
                }
            }

            return -1;
        }

        private int ObtenerPosicionActualMs()
        {
            try
            {
                return (int)(reproductor.controls.currentPosition * 1000);
            }
            catch
            {
                return 0;
            }
        }

        private int ObtenerDuracionActualMs()
        {
            try
            {
                return (int)(reproductor.currentMedia.duration * 1000);
            }
            catch
            {
                return duracionActualMs;
            }
        }

        private bool EsFinDeCancion(int posicionMs)
        {
            try
            {
                int estado = reproductor.playState;

                if (estado == 8)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }

            return duracionActualMs > 0 && posicionMs >= duracionActualMs - 400;
        }

        private string FormatearTiempo(int milisegundos)
        {
            if (milisegundos < 0)
            {
                milisegundos = 0;
            }

            TimeSpan tiempo = TimeSpan.FromMilliseconds(milisegundos);
            return ((int)tiempo.TotalMinutes).ToString("00") + ":" + tiempo.Seconds.ToString("00");
        }

        private void DetenerTimer()
        {
            timerReproduccion.Stop();
        }

        private void LiberarReproductor()
        {
            if (reproductorDisponible && reproductor != null)
            {
                try
                {
                    reproductor.close();
                }
                catch
                {
                    // Cierre defensivo del componente COM.
                }
            }
        }

        private void panelMarcoVisualizador_Paint(object sender, PaintEventArgs e)
        {
            using (Pen bordeClaro = new Pen(mostazaSuave, 4))
            using (Pen bordeRosa = new Pen(amarilloRetro, 2))
            using (SolidBrush detalle = new SolidBrush(rojoLadrillo))
            {
                Rectangle area = panelMarcoVisualizador.ClientRectangle;
                area.Inflate(-8, -8);

                e.Graphics.DrawRectangle(bordeClaro, area);

                Rectangle segundoBorde = area;
                segundoBorde.Inflate(-8, -8);
                e.Graphics.DrawRectangle(bordeRosa, segundoBorde);

                e.Graphics.FillRectangle(detalle, 22, 22, 18, 18);
                e.Graphics.FillRectangle(detalle, panelMarcoVisualizador.Width - 42, 22, 18, 18);
                e.Graphics.FillRectangle(detalle, 22, panelMarcoVisualizador.Height - 42, 18, 18);
                e.Graphics.FillRectangle(detalle, panelMarcoVisualizador.Width - 42, panelMarcoVisualizador.Height - 42, 18, 18);
            }
        }

        private void panelVisualizador_Resize(object sender, EventArgs e)
        {
            InicializarParticulas();
            panelVisualizador.Invalidate();
        }

        private void panelVisualizador_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.None;
            e.Graphics.Clear(Color.FromArgb(1, 82, 98));
            DibujarCuadriculaRetro(e.Graphics);

            switch (cmbModoVisual.SelectedIndex)
            {
                case 1:
                    DibujarOndaMusical(e.Graphics);
                    break;
                case 2:
                    DibujarParticulas(e.Graphics);
                    break;
                case 3:
                    DibujarFigurasGeometricas(e.Graphics);
                    break;
                case 4:
                    DibujarEspectroCircular(e.Graphics);
                    break;
                default:
                    DibujarBarrasEspectro(e.Graphics);
                    break;
            }
        }

        private void DibujarCuadriculaRetro(Graphics g)
        {
            using (Pen linea = new Pen(Color.FromArgb(22, 112, 130), 1))
            {
                for (int x = 0; x < panelVisualizador.Width; x += 24)
                {
                    g.DrawLine(linea, x, 0, x, panelVisualizador.Height);
                }

                for (int y = 0; y < panelVisualizador.Height; y += 24)
                {
                    g.DrawLine(linea, 0, y, panelVisualizador.Width, y);
                }
            }
        }

        private void DibujarBarrasEspectro(Graphics g)
        {
            int ancho = Math.Max(1, panelVisualizador.Width);
            int alto = Math.Max(1, panelVisualizador.Height);
            int cantidadBarras = 32;
            int separacion = 5;
            int anchoBarra = Math.Max(6, (ancho - 48 - (cantidadBarras - 1) * separacion) / cantidadBarras);
            int inicioX = 24;
            float energia = ObtenerEnergiaVisual();
            float[] bandas = ObtenerBandasAudio(cantidadBarras);

            for (int i = 0; i < cantidadBarras; i++)
            {
                int altura = (int)(24 + bandas[i] * (alto - 72) + energia * 38);
                altura = Math.Min(alto - 38, altura);

                int x = inicioX + i * (anchoBarra + separacion);
                int y = alto - altura - 24;
                Color color = Color.FromArgb(
                    245,
                    Mezclar(160, 230, i / (float)cantidadBarras),
                    Mezclar(4, 96, energia));

                using (SolidBrush relleno = new SolidBrush(color))
                using (Pen borde = new Pen(negroSuave, 2))
                {
                    g.FillRectangle(relleno, x, y, anchoBarra, altura);
                    g.DrawRectangle(borde, x, y, anchoBarra, altura);
                }
            }
        }

        private void DibujarOndaMusical(Graphics g)
        {
            int ancho = Math.Max(1, panelVisualizador.Width);
            int alto = Math.Max(1, panelVisualizador.Height);
            float energia = ObtenerEnergiaVisual();
            int centroY = alto / 2;
            int centroX = ancho / 2;
            int muestras = 104;
            int paso = Math.Max(5, (ancho - 56) / muestras);
            float[] bandas = ObtenerBandasAudio(muestras);

            using (Pen lineaCentro = new Pen(Color.FromArgb(70, cremaRetro), 1))
            using (SolidBrush punto = new SolidBrush(cremaRetro))
            using (SolidBrush acento = new SolidBrush(amarilloRetro))
            {
                g.DrawLine(lineaCentro, 24, centroY, ancho - 24, centroY);

                for (int i = 0; i < muestras; i++)
                {
                    int x = 28 + i * paso;
                    double distanciaNormal = Math.Abs((x - centroX) / (double)Math.Max(1, centroX));
                    double envolvente = Math.Exp(-distanciaNormal * 3.1);
                    double pulsoLocal = 0.65 + 0.35 * Math.Abs(Math.Sin(faseAnimacion * 0.85 + i * 0.11));
                    int amplitud = (int)((10 + bandas[i] * 96 + energia * 30) * envolvente * pulsoLocal);
                    int tamanoPunto = amplitud > 12 ? 5 : 4;

                    if (amplitud > 8)
                    {
                        g.FillRectangle(acento, x - 2, centroY - amplitud, 4, amplitud * 2);
                    }

                    g.FillEllipse(punto, x - tamanoPunto / 2, centroY - tamanoPunto / 2, tamanoPunto, tamanoPunto);
                }
            }
        }

        private void DibujarEspectroCircular(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int ancho = Math.Max(1, panelVisualizador.Width);
            int alto = Math.Max(1, panelVisualizador.Height);
            int centroX = ancho / 2;
            int centroY = alto / 2;
            int radioBase = Math.Min(ancho, alto) / 5;
            int cantidadLineas = 96;
            float energia = ObtenerEnergiaVisual();
            float[] bandas = ObtenerBandasAudio(cantidadLineas);

            using (Pen anillo = new Pen(Color.FromArgb(140, cremaRetro), 2))
            using (Pen puntoAnillo = new Pen(Color.FromArgb(160, amarilloRetro), 2))
            {
                g.DrawEllipse(anillo, centroX - radioBase, centroY - radioBase, radioBase * 2, radioBase * 2);

                for (int i = 0; i < cantidadLineas; i++)
                {
                    double angulo = (Math.PI * 2 * i / cantidadLineas) - Math.PI / 2;
                    double envolvente = 0.45 + 0.55 * Math.Abs(Math.Sin(angulo * 2.0 + faseAnimacion * 0.35));
                    int largo = (int)((10 + bandas[i] * 120 + energia * 25) * envolvente);

                    int x1 = centroX + (int)(Math.Cos(angulo) * radioBase);
                    int y1 = centroY + (int)(Math.Sin(angulo) * radioBase);
                    int x2 = centroX + (int)(Math.Cos(angulo) * (radioBase + largo));
                    int y2 = centroY + (int)(Math.Sin(angulo) * (radioBase + largo));

                    Color colorLinea = i % 4 == 0 ? amarilloRetro : Color.FromArgb(89, 229, 128);
                    using (Pen barra = new Pen(colorLinea, i % 6 == 0 ? 3 : 2))
                    {
                        g.DrawLine(barra, x1, y1, x2, y2);
                    }

                    if (i % 3 == 0)
                    {
                        g.DrawEllipse(puntoAnillo, x1 - 1, y1 - 1, 2, 2);
                    }
                }
            }
        }

        private void DibujarParticulas(Graphics g)
        {
            float energia = ObtenerEnergiaVisual();

            foreach (ParticulaVisual particula in particulas)
            {
                int tamano = (int)(particula.Tamano + energia * 10);
                Color color = Color.FromArgb(
                    particula.Alfa,
                    particula.ColorBase.R,
                    particula.ColorBase.G,
                    particula.ColorBase.B);

                using (SolidBrush relleno = new SolidBrush(color))
                using (Pen borde = new Pen(negroSuave, 1))
                {
                    Rectangle rect = new Rectangle((int)particula.X, (int)particula.Y, tamano, tamano);
                    g.FillRectangle(relleno, rect);
                    g.DrawRectangle(borde, rect);
                }
            }
        }

        private void DibujarFigurasGeometricas(Graphics g)
        {
            int ancho = Math.Max(1, panelVisualizador.Width);
            int alto = Math.Max(1, panelVisualizador.Height);
            float energia = ObtenerEnergiaVisual();
            int centroX = ancho / 2;
            int centroY = alto / 2;

            for (int i = 0; i < 8; i++)
            {
                double angulo = faseAnimacion * 0.75 + i * Math.PI / 4;
                int distancia = (int)(58 + energia * 110 + i * 12);
                int x = centroX + (int)(Math.Cos(angulo) * distancia);
                int y = centroY + (int)(Math.Sin(angulo) * distancia);
                int tamano = (int)(26 + energia * 28 + Math.Sin(faseAnimacion + i) * 8);

                Color color = i % 3 == 0 ? amarilloRetro : (i % 3 == 1 ? mostazaSuave : rojoLadrillo);
                using (SolidBrush relleno = new SolidBrush(color))
                using (Pen borde = new Pen(negroSuave, 3))
                {
                    Rectangle rect = new Rectangle(x - tamano / 2, y - tamano / 2, tamano, tamano);

                    if (i % 2 == 0)
                    {
                        g.FillRectangle(relleno, rect);
                        g.DrawRectangle(borde, rect);
                    }
                    else
                    {
                        g.FillEllipse(relleno, rect);
                        g.DrawEllipse(borde, rect);
                    }
                }
            }

            DibujarViniloCentral(g, centroX, centroY, energia);
        }

        private void DibujarViniloCentral(Graphics g, int centroX, int centroY, float energia)
        {
            int radio = (int)(62 + energia * 30);
            Rectangle disco = new Rectangle(centroX - radio, centroY - radio, radio * 2, radio * 2);
            Rectangle centro = new Rectangle(centroX - 14, centroY - 14, 28, 28);

            using (SolidBrush discoBrush = new SolidBrush(negroSuave))
            using (SolidBrush centroBrush = new SolidBrush(amarilloRetro))
            using (Pen surco = new Pen(Color.FromArgb(55, 65, 74), 2))
            {
                g.FillEllipse(discoBrush, disco);

                for (int r = 18; r < radio; r += 14)
                {
                    g.DrawEllipse(surco, centroX - r, centroY - r, r * 2, r * 2);
                }

                g.FillEllipse(centroBrush, centro);
            }
        }

        private void InicializarParticulas()
        {
            particulas.Clear();

            int ancho = Math.Max(1, panelVisualizador.Width);
            int alto = Math.Max(1, panelVisualizador.Height);

            for (int i = 0; i < 46; i++)
            {
                Color color = i % 3 == 0 ? amarilloRetro : (i % 3 == 1 ? mostazaSuave : cremaRetro);
                particulas.Add(new ParticulaVisual(
                    aleatorio.Next(ancho),
                    aleatorio.Next(alto),
                    (float)(aleatorio.NextDouble() * 2.4 - 1.2),
                    (float)(aleatorio.NextDouble() * 2.4 - 1.2),
                    aleatorio.Next(5, 13),
                    aleatorio.Next(120, 230),
                    color));
            }
        }

        private void ActualizarParticulas()
        {
            if (particulas.Count == 0 || panelVisualizador.Width <= 0 || panelVisualizador.Height <= 0)
            {
                return;
            }

            float energia = ObtenerEnergiaVisual();

            foreach (ParticulaVisual particula in particulas)
            {
                particula.X += particula.VelocidadX * (1.0f + energia * 2.3f);
                particula.Y += particula.VelocidadY * (1.0f + energia * 2.3f);

                if (particula.X < 0 || particula.X > panelVisualizador.Width - particula.Tamano)
                {
                    particula.VelocidadX *= -1;
                }

                if (particula.Y < 0 || particula.Y > panelVisualizador.Height - particula.Tamano)
                {
                    particula.VelocidadY *= -1;
                }
            }
        }

        private float ObtenerEnergiaVisual()
        {
            float volumen = trackVolumen.Value / 100f;

            if (reproduciendo && !enPausa)
            {
                float energiaReal = ObtenerEnergiaAudioReal();

                if (energiaReal >= 0f)
                {
                    return Limitar01(energiaReal * (0.35f + volumen * 0.65f));
                }
            }

            if (!reproduciendo || enPausa)
            {
                return 0.18f + volumen * 0.12f;
            }

            int posicion = ObtenerPosicionActualMs();
            double tiempo = posicion / 1000.0;
            double pulso = Math.Abs(Math.Sin(tiempo * 2.8));
            double subPulso = Math.Abs(Math.Sin(tiempo * 0.9 + Math.Sin(tiempo * 0.35)));
            return Limitar01((float)((0.28 + pulso * 0.48 + subPulso * 0.24) * volumen));
        }

        private int Mezclar(int inicio, int fin, float cantidad)
        {
            cantidad = Limitar01(cantidad);
            return inicio + (int)((fin - inicio) * cantidad);
        }

        private float Limitar01(float valor)
        {
            if (valor < 0f)
            {
                return 0f;
            }

            if (valor > 1f)
            {
                return 1f;
            }

            return valor;
        }

        private class ParticulaVisual
        {
            public float X;
            public float Y;
            public float VelocidadX;
            public float VelocidadY;
            public int Tamano;
            public int Alfa;
            public Color ColorBase;

            public ParticulaVisual(float x, float y, float velocidadX, float velocidadY, int tamano, int alfa, Color colorBase)
            {
                X = x;
                Y = y;
                VelocidadX = velocidadX;
                VelocidadY = velocidadY;
                Tamano = tamano;
                Alfa = alfa;
                ColorBase = colorBase;
            }
        }
    }
}

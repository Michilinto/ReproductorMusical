using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ReproductorMusical
{
    internal class VisualizadorBarras : VisualizadorBase
    {
        public VisualizadorBarras(ContextoVisualizacion contexto) : base(contexto) { }

        public override void Dibujar(Graphics g)
        {
            int W = Math.Max(1, Contexto.Ancho);
            int H = Math.Max(1, Contexto.Alto);
            const int margenX = 12;
            const int margenY = 12;
            const int nBarras = 48;
            const int sep     = 3;
            int halfBars      = nBarras / 2;

            float[] bandas = Contexto.Analizador.ObtenerBandasCompletas(
                nBarras, Contexto.PosicionMs, Contexto.Energia, Contexto.FaseAnimacion);
            float energia = Contexto.Energia;

            int espacio    = W - margenX * 2;
            int wBarra     = Math.Max(4, (espacio - (nBarras - 1) * sep) / nBarras);
            int anchoUsado = nBarras * wBarra + (nBarras - 1) * sep;
            int startX     = margenX + (espacio - anchoUsado) / 2;
            int baseY      = H - margenY;

            for (int i = 0; i < nBarras; i++)
            {
                // Mapeo simétrico: dist=0 = centro (bajos), dist=halfBars-1 = bordes (agudos)
                int dist    = i < halfBars ? (halfBars - 1 - i) : (i - halfBars);
                int bandIdx = dist * (bandas.Length - 1) / Math.Max(1, halfBars - 1);
                bandIdx     = Math.Min(bandIdx, bandas.Length - 1);
                float t     = dist / (float)(halfBars - 1);

                int barH = (int)(margenY + bandas[bandIdx] * (H - margenY * 2 - 16) + energia * 28f);
                barH = Math.Max(4, Math.Min(H - margenY * 2, barH));

                int x = startX + i * (wBarra + sep);
                int y = baseY  - barH;

                // Degradado: centro=amarillo → bordes=cyan brillante
                Color col = Color.FromArgb(255,
                    Mezclar(249, 45,  t),
                    Mezclar(162, 200, t),
                    Mezclar(4,   230, t));

                using (SolidBrush glow    = new SolidBrush(Color.FromArgb(35, col)))
                    g.FillRectangle(glow, x - 2, y, wBarra + 4, barH);
                using (SolidBrush relleno = new SolidBrush(col))
                    g.FillRectangle(relleno, x, y, wBarra, barH);
                using (SolidBrush tope    = new SolidBrush(Color.FromArgb(230, ContextoVisualizacion.Crema)))
                    g.FillRectangle(tope, x, y, wBarra, 3);
            }
        }
    }
}

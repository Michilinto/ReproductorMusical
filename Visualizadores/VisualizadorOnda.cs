using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ReproductorMusical
{
    internal class VisualizadorOnda : VisualizadorBase
    {
        public VisualizadorOnda(ContextoVisualizacion contexto) : base(contexto) { }

        public override void Dibujar(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int W  = Math.Max(2, Contexto.Ancho);
            int H  = Math.Max(2, Contexto.Alto);
            int cY = H / 2;
            float energia = Contexto.Energia;
            float fase    = Contexto.FaseAnimacion;
            const int nPuntos = 220;

            float[] bandas = Contexto.Analizador.ObtenerBandasCompletas(
                nPuntos, Contexto.PosicionMs, energia, fase);

            using (Pen lc = new Pen(Color.FromArgb(40, ContextoVisualizacion.Crema), 1))
                g.DrawLine(lc, 0, cY, W, cY);

            var top = new PointF[nPuntos];
            var bot = new PointF[nPuntos];

            for (int i = 0; i < nPuntos; i++)
            {
                float  x   = i * (W - 1) / (float)(nPuntos - 1);
                double t   = i / (double)(nPuntos - 1);
                double env = Math.Exp(-Math.Pow((t - 0.5) * 2.8, 2));

                double a1  = Math.Sin(fase * 2.1 + t * Math.PI * 8.0);
                double a2  = Math.Sin(fase * 0.9 + t * Math.PI * 16.0) * 0.4;
                double a3  = Math.Sin(fase * 3.7 + t * Math.PI * 4.0)  * 0.22;

                float amp = (float)((12 + bandas[i] * 90 + energia * 42)
                    * env * (0.5 + 0.5 * Math.Abs(a1 + a2 + a3)) + 6);

                top[i] = new PointF(x, cY - amp);
                bot[i] = new PointF(x, cY + amp);
            }

            // Relleno semitransparente entre las dos curvas
            var poly = new PointF[nPuntos * 2];
            for (int i = 0; i < nPuntos; i++) poly[i]           = top[i];
            for (int i = 0; i < nPuntos; i++) poly[nPuntos + i] = bot[nPuntos - 1 - i];
            using (SolidBrush fill = new SolidBrush(Color.FromArgb(30, ContextoVisualizacion.Amarillo)))
                g.FillPolygon(fill, poly);

            // Paleta retro cíclica: rojoLadrillo → amarillo → azulPetroleo → mostaza
            int[] palR = { 172, 249,   2, 223 };
            int[] palG = {  80, 162, 108, 160 };
            int[] palB = {  69,   4, 128,  93 };
            float despColor = fase * 0.28f;

            for (int i = 0; i < nPuntos - 1; i++)
            {
                float ampNorm = Limitar01((cY - top[i].Y) / Math.Max(1f, cY * 0.88f));
                float posH    = i / (float)(nPuntos - 1);
                float colorT  = (posH + despColor) % 1.0f;
                if (colorT < 0) colorT += 1.0f;
                float scaled  = colorT * 4f;
                int   s0      = (int)scaled % 4;
                int   s1      = (s0 + 1) % 4;
                float fr      = scaled - (float)Math.Floor(scaled);

                int br = palR[s0] + (int)((palR[s1] - palR[s0]) * fr);
                int bg = palG[s0] + (int)((palG[s1] - palG[s0]) * fr);
                int bb = palB[s0] + (int)((palB[s1] - palB[s0]) * fr);

                int r  = Mezclar(br, 245, ampNorm * 0.65f);
                int gv = Mezclar(bg, 230, ampNorm * 0.65f);
                int b  = Mezclar(bb, 189, ampNorm * 0.65f);
                Color col = Color.FromArgb(255, r, gv, b);

                using (Pen glowPen = new Pen(Color.FromArgb((int)(55 * ampNorm + 12), col), 7f))
                    g.DrawLine(glowPen, top[i], top[i + 1]);
                using (Pen mainPen = new Pen(col, 2.5f))
                    g.DrawLine(mainPen, top[i], top[i + 1]);
            }

            // Reflejo inferior
            for (int i = 0; i < nPuntos - 1; i++)
            {
                float ampNorm = Limitar01((bot[i].Y - cY) / Math.Max(1f, cY * 0.88f)) * 0.6f;
                float posH    = i / (float)(nPuntos - 1);
                float colorT  = (posH + despColor) % 1.0f;
                if (colorT < 0) colorT += 1.0f;
                float scaled  = colorT * 4f;
                int   s0      = (int)scaled % 4;
                int   s1      = (s0 + 1) % 4;
                float fr      = scaled - (float)Math.Floor(scaled);

                int r  = (palR[s0] + (int)((palR[s1] - palR[s0]) * fr)) / 2;
                int gv = (palG[s0] + (int)((palG[s1] - palG[s0]) * fr)) / 2;
                int b  = (palB[s0] + (int)((palB[s1] - palB[s0]) * fr)) / 2;
                r  = Mezclar(r,  180, ampNorm * 0.5f);
                gv = Mezclar(gv, 160, ampNorm * 0.5f);
                b  = Mezclar(b,  140, ampNorm * 0.5f);

                using (Pen refPen = new Pen(Color.FromArgb(145, r, gv, b), 1.5f))
                    g.DrawLine(refPen, bot[i], bot[i + 1]);
            }
        }
    }
}

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ReproductorMusical
{
    internal class VisualizadorCircular : VisualizadorBase
    {
        public VisualizadorCircular(ContextoVisualizacion contexto) : base(contexto) { }

        public override void Dibujar(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int W  = Math.Max(1, Contexto.Ancho);
            int H  = Math.Max(1, Contexto.Alto);
            int cX = W / 2;
            int cY = H / 2;
            int radioBase = Math.Min(W, H) / 4;
            int maxLargo  = Math.Min(W, H) / 2 - radioBase - 12;
            float energia = Contexto.Energia;
            float fase    = Contexto.FaseAnimacion;
            const int nLineas = 128;

            float[] bandas = Contexto.Analizador.ObtenerBandasCompletas(
                nLineas, Contexto.PosicionMs, energia, fase);
            double rotacion = fase * 0.12;

            using (Pen anilloExt = new Pen(Color.FromArgb(100, ContextoVisualizacion.Mostaza), 2))
            using (Pen anilloInt = new Pen(Color.FromArgb(50,  ContextoVisualizacion.Crema),   1))
            {
                g.DrawEllipse(anilloExt, cX - radioBase, cY - radioBase, radioBase * 2, radioBase * 2);
                g.DrawEllipse(anilloInt, cX - radioBase + 5, cY - radioBase + 5,
                    (radioBase - 5) * 2, (radioBase - 5) * 2);
            }

            for (int i = 0; i < nLineas; i++)
            {
                double angulo = 2.0 * Math.PI * i / nLineas - Math.PI / 2 + rotacion;
                float  t      = i / (float)nLineas;

                int largo = Math.Max(3, Math.Min(maxLargo,
                    (int)(6 + bandas[i] * maxLargo * 0.9f + energia * 20f)));

                float cosA = (float)Math.Cos(angulo);
                float sinA = (float)Math.Sin(angulo);
                int x1 = cX + (int)(cosA * radioBase);
                int y1 = cY + (int)(sinA * radioBase);
                int x2 = cX + (int)(cosA * (radioBase + largo));
                int y2 = cY + (int)(sinA * (radioBase + largo));

                Color col = Color.FromArgb(255,
                    Mezclar(249, 101, t),
                    Mezclar(162, 135, t),
                    Mezclar(4,    97, t));

                using (Pen barra = new Pen(col, i % 4 == 0 ? 3f : 1.5f))
                    g.DrawLine(barra, x1, y1, x2, y2);

                int largoInt = Math.Min(largo / 3, radioBase - 10);
                if (largoInt > 2)
                {
                    int xInt = cX + (int)(cosA * (radioBase - largoInt));
                    int yInt = cY + (int)(sinA * (radioBase - largoInt));
                    using (Pen barraInt = new Pen(Color.FromArgb(120, col), 1f))
                        g.DrawLine(barraInt, x1, y1, xInt, yInt);
                }

                if (i % 2 == 0)
                {
                    int dot = i % 8 == 0 ? 5 : 3;
                    using (SolidBrush dotBrush = new SolidBrush(Color.FromArgb(220, col)))
                        g.FillEllipse(dotBrush, x2 - dot / 2, y2 - dot / 2, dot, dot);
                }
            }

            // Anillo exterior de puntos decorativos
            int radioDots = radioBase + maxLargo + 8;
            radioDots = Math.Min(radioDots, Math.Min(W, H) / 2 - 4);
            for (int i = 0; i < 64; i++)
            {
                double ang = 2.0 * Math.PI * i / 64 + rotacion * 0.5;
                float td   = i / 64f;
                Color dotCol = Color.FromArgb(160,
                    Mezclar(249, 2,   td),
                    Mezclar(162, 108, td),
                    Mezclar(4,   128, td));
                int dx = cX + (int)(Math.Cos(ang) * radioDots);
                int dy = cY + (int)(Math.Sin(ang) * radioDots);
                int ds = i % 8 == 0 ? 5 : 3;
                using (SolidBrush db = new SolidBrush(dotCol))
                    g.FillEllipse(db, dx - ds / 2, dy - ds / 2, ds, ds);
            }

            // Disco central con surcos de vinilo
            int rC = radioBase / 3;
            using (SolidBrush fc = new SolidBrush(Color.FromArgb(120, ContextoVisualizacion.NegroSuave)))
                g.FillEllipse(fc, cX - rC, cY - rC, rC * 2, rC * 2);
            for (int r = rC / 3; r < rC; r += rC / 4)
            {
                using (Pen surco = new Pen(Color.FromArgb(60, ContextoVisualizacion.Mostaza), 1))
                    g.DrawEllipse(surco, cX - r, cY - r, r * 2, r * 2);
            }
            using (Pen pc = new Pen(ContextoVisualizacion.Amarillo, 2))
                g.DrawEllipse(pc, cX - rC, cY - rC, rC * 2, rC * 2);
            using (SolidBrush centroPin = new SolidBrush(ContextoVisualizacion.Amarillo))
                g.FillEllipse(centroPin, cX - 4, cY - 4, 8, 8);
        }
    }
}

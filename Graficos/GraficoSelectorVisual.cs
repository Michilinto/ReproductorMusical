using System.Drawing;

namespace ReproductorMusical
{
    // Dial de sintonía de radio con aguja que apunta a la canción activa.
    internal class GraficoSelectorVisual
    {
        private readonly ContextoUI ctx;
        public GraficoSelectorVisual(ContextoUI ctx) { this.ctx = ctx; }

        public void Dibujar(Graphics g, int w, int h)
        {
            int bandX = 560, bandW = w - bandX - 55, bandY = h / 2 + 4;

            using (Font fLabel = new Font("Consolas", 9f, FontStyle.Bold))
            using (Font fFreq  = new Font("Consolas", 7f))
            using (SolidBrush dorado     = new SolidBrush(ctx.AmarilloRetro))
            using (SolidBrush cremaTenue = new SolidBrush(Color.FromArgb(160, ctx.CremaRetro)))
            using (Pen lineaBanda = new Pen(ctx.CremaRetro, 2))
            using (Pen tick       = new Pen(Color.FromArgb(180, ctx.AmarilloRetro), 1))
            {
                g.DrawString("AM", fLabel, dorado, bandX,              bandY - 14);
                g.DrawString("FM", fLabel, dorado, bandX + bandW - 28, bandY - 14);

                int ls = bandX + 36, le = bandX + bandW - 36;
                g.DrawLine(lineaBanda, ls, bandY, le, bandY);

                string[] freqs    = { "530", "700", "900", "1100", "1300", "1600" };
                int      nTicks   = 15;
                for (int i = 0; i <= nTicks; i++)
                {
                    int  x     = ls + i * (le - ls) / nTicks;
                    bool major = i % 3 == 0;
                    g.DrawLine(tick, x, bandY - (major ? 10 : 5), x, bandY + 4);
                    if (major && i / 3 < freqs.Length)
                        g.DrawString(freqs[i / 3], fFreq, cremaTenue, x - 10, bandY + 7);
                }

                if (ctx.Canciones != null && ctx.Canciones.Count > 0 && ctx.IndiceCancionActual >= 0)
                {
                    float pos = ctx.Canciones.Count > 1
                        ? ctx.IndiceCancionActual / (float)(ctx.Canciones.Count - 1)
                        : 0.5f;
                    int nx = ls + (int)(pos * (le - ls));
                    using (Pen aguja  = new Pen(ctx.RojoLadrillo, 3))
                    using (SolidBrush cabeza = new SolidBrush(ctx.RojoLadrillo))
                    {
                        g.DrawLine(aguja, nx, bandY - 18, nx, bandY + 8);
                        g.FillEllipse(cabeza, nx - 5, bandY - 23, 10, 10);
                    }
                }
            }
        }
    }
}

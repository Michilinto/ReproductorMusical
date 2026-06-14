using System.Drawing;
using System.Drawing.Drawing2D;

namespace ReproductorMusical
{
    internal class GraficoFooter
    {
        private readonly ContextoUI ctx;
        public GraficoFooter(ContextoUI ctx) { this.ctx = ctx; }

        public void Dibujar(Graphics g, int w, int h)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int cy = h / 2;

            using (Pen scan = new Pen(Color.FromArgb(12, 249, 162, 4), 1))
                for (int y = 0; y < h; y += 3)
                    g.DrawLine(scan, 0, y, w, y);

            using (Pen topSep  = new Pen(Color.FromArgb(210, ctx.AmarilloRetro), 1)) g.DrawLine(topSep,  0, 0, w, 0);
            using (Pen topGlow = new Pen(Color.FromArgb( 45, ctx.AmarilloRetro), 5)) g.DrawLine(topGlow, 0, 2, w, 2);

            for (int i = 0; i < 18; i++)
            {
                int alfa = (int)((1.0 - i / 18.0) * 60);
                using (SolidBrush v = new SolidBrush(Color.FromArgb(alfa, 0, 0, 0)))
                {
                    g.FillRectangle(v, 0,         0, i + 1, h);
                    g.FillRectangle(v, w - i - 1, 0, i + 1, h);
                }
            }

            // LED de estado: rojo=reproduciendo, amarillo=pausado, verde=detenido
            bool actReproduciendo = ctx.Reproduciendo && !ctx.EnPausa;
            bool actPausa         = ctx.Reproduciendo &&  ctx.EnPausa;
            Color ledCol = actReproduciendo
                ? Color.FromArgb(235, ctx.RojoLadrillo)
                : actPausa
                    ? Color.FromArgb(235, ctx.AmarilloRetro)
                    : Color.FromArgb(235, 72, 210, 72);

            using (SolidBrush ledGlow   = new SolidBrush(Color.FromArgb(50,  ledCol)))           g.FillEllipse(ledGlow,   10, cy - 9, 18, 18);
            using (SolidBrush ledCore   = new SolidBrush(ledCol))                                 g.FillEllipse(ledCore,   13, cy - 6, 12, 12);
            using (SolidBrush ledHi     = new SolidBrush(Color.FromArgb(120, ctx.CremaRetro)))   g.FillEllipse(ledHi,     15, cy - 4,  4,  4);
            using (Pen        ledBorder = new Pen(Color.FromArgb(90, ctx.CremaRetro), 1))         g.DrawEllipse(ledBorder, 13, cy - 6, 12, 12);

            int mx = w / 2;
            using (Pen ml = new Pen(Color.FromArgb(22, ctx.AmarilloRetro), 1))
            {
                g.DrawLine(ml, mx - 60, cy,     mx + 60, cy);
                g.DrawLine(ml, mx - 60, cy - 6, mx - 60, cy + 6);
                g.DrawLine(ml, mx + 60, cy - 6, mx + 60, cy + 6);
            }
            using (SolidBrush md = new SolidBrush(Color.FromArgb(45, ctx.MostazaSuave)))
                g.FillEllipse(md, mx - 4, cy - 4, 8, 8);
        }
    }
}

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ReproductorMusical
{
    internal class GraficoVolumen
    {
        private readonly ContextoUI ctx;
        public GraficoVolumen(ContextoUI ctx) { this.ctx = ctx; }

        public void Dibujar(Graphics g, int w, int h)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int margin = 8, trackLen = w - margin * 2;
            int trackY = h / 2 - 3, trackH = 6;

            using (SolidBrush sh = new SolidBrush(Color.FromArgb( 8,  5,  2)))
                g.FillRectangle(sh, margin - 1, trackY - 1, trackLen + 2, trackH + 2);
            using (SolidBrush bg = new SolidBrush(Color.FromArgb(35, 25, 12)))
                g.FillRectangle(bg, margin, trackY, trackLen, trackH);

            int fillW = (int)(trackLen * ctx.VolumenValor / 100f);
            if (fillW > 0)
            {
                using (SolidBrush glow = new SolidBrush(Color.FromArgb(55, ctx.AmarilloRetro)))
                    g.FillRectangle(glow, margin, trackY - 2, fillW, trackH + 4);
                using (SolidBrush fill = new SolidBrush(ctx.AmarilloRetro))
                    g.FillRectangle(fill, margin, trackY, fillW, trackH);
            }
            using (Pen border = new Pen(Color.FromArgb(90, ctx.MostazaSuave), 1))
                g.DrawRectangle(border, margin, trackY, trackLen, trackH);

            using (Pen tick = new Pen(Color.FromArgb(65, ctx.MostazaSuave), 1))
                for (int t = 0; t <= 10; t++)
                {
                    int tx = margin + t * trackLen / 10;
                    g.DrawLine(tick, tx, trackY + trackH + 2, tx, trackY + trackH + (t % 5 == 0 ? 6 : 4));
                }

            int thumbX = Math.Max(margin, Math.Min(margin + trackLen, margin + fillW));
            Rectangle thumb = new Rectangle(thumbX - 5, 2, 11, h - 4);
            int t3 = thumb.Height / 3;
            using (SolidBrush b1 = new SolidBrush(Color.FromArgb(162, 148, 112))) g.FillRectangle(b1, thumb.Left, thumb.Top,         thumb.Width, t3);
            using (SolidBrush b2 = new SolidBrush(Color.FromArgb(108,  98,  70))) g.FillRectangle(b2, thumb.Left, thumb.Top + t3,     thumb.Width, t3);
            using (SolidBrush b3 = new SolidBrush(Color.FromArgb( 52,  45,  28))) g.FillRectangle(b3, thumb.Left, thumb.Top + t3 * 2, thumb.Width, thumb.Height - t3 * 2);
            using (Pen hi = new Pen(Color.FromArgb(205, 190, 145), 1))
            {
                g.DrawLine(hi, thumb.Left, thumb.Top, thumb.Right - 1, thumb.Top);
                g.DrawLine(hi, thumb.Left, thumb.Top, thumb.Left,      thumb.Bottom);
            }
            using (Pen sd = new Pen(Color.FromArgb(18, 14, 6), 1))
            {
                g.DrawLine(sd, thumb.Left, thumb.Bottom, thumb.Right, thumb.Bottom);
                g.DrawLine(sd, thumb.Right, thumb.Top,  thumb.Right, thumb.Bottom);
            }
            int cx = thumb.Left + thumb.Width / 2;
            using (Pen notch = new Pen(Color.FromArgb(140, ctx.MostazaSuave), 1))
                g.DrawLine(notch, cx, thumb.Top + 3, cx, thumb.Bottom - 3);
        }
    }
}

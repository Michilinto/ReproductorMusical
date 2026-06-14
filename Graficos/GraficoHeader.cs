using System.Drawing;
using System.Drawing.Drawing2D;

namespace ReproductorMusical
{
    internal class GraficoHeader
    {
        private readonly ContextoUI ctx;
        public GraficoHeader(ContextoUI ctx) { this.ctx = ctx; }

        public void Dibujar(Graphics g, int w, int h)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen lineaDorada = new Pen(Color.FromArgb(190, ctx.AmarilloRetro), 2))
            using (Pen lineaTenue  = new Pen(Color.FromArgb( 70, ctx.AmarilloRetro), 1))
            {
                g.DrawLine(lineaDorada, 16, 14,    w - 16, 14);
                g.DrawLine(lineaTenue,  16, 18,    w - 16, 18);
                g.DrawLine(lineaDorada, 16, h - 5, w - 16, h - 5);
                g.DrawLine(lineaTenue,  16, h - 9, w - 16, h - 9);
            }

            using (Font fModelo = new Font("Consolas", 9.5f, FontStyle.Bold))
            using (SolidBrush textoModelo = new SolidBrush(Color.FromArgb(235, ctx.CremaRetro)))
            {
                string txt = "✦  M a D a L ú   ◈   S t u d i o   M K · 2 0 2 6   ◈   S t e r e o   H i - F i  ✦";
                SizeF  sz  = g.MeasureString(txt, fModelo);
                float  tx  = (w - sz.Width) / 2f;
                float  ty  = h - 28f;
                using (SolidBrush bgTxt = new SolidBrush(Color.FromArgb(100, 35, 20, 8)))
                    g.FillRectangle(bgTxt, tx - 6, ty - 2, sz.Width + 12, sz.Height + 4);
                g.DrawString(txt, fModelo, textoModelo, tx, ty);
            }

            using (Pen bordCirc  = new Pen(Color.FromArgb(150, ctx.AmarilloRetro), 2))
            using (SolidBrush fondCirc = new SolidBrush(Color.FromArgb(35, ctx.AmarilloRetro)))
            {
                int cy  = h / 2;
                int c1x = w - 230, c2x = w - 178;
                g.FillEllipse(fondCirc, c1x,      cy - 24, 48, 48);
                g.DrawEllipse(bordCirc, c1x,      cy - 24, 48, 48);
                g.FillEllipse(fondCirc, c1x + 12, cy - 12, 24, 24);
                g.DrawEllipse(bordCirc, c1x + 12, cy - 12, 24, 24);
                g.FillEllipse(fondCirc, c2x,      cy - 24, 48, 48);
                g.DrawEllipse(bordCirc, c2x,      cy - 24, 48, 48);
                g.FillEllipse(fondCirc, c2x + 12, cy - 12, 24, 24);
                g.DrawEllipse(bordCirc, c2x + 12, cy - 12, 24, 24);
            }
        }
    }
}

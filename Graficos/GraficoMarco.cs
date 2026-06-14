using System.Drawing;
using System.Drawing.Drawing2D;

namespace ReproductorMusical
{
    // Marco decorativo con tornillos en las esquinas del panel visualizador.
    internal class GraficoMarco
    {
        private readonly ContextoUI ctx;
        public GraficoMarco(ContextoUI ctx) { this.ctx = ctx; }

        public void Dibujar(Graphics g, int w, int h)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen bordeClaro  = new Pen(ctx.MostazaSuave, 5))
            using (Pen bordeInner  = new Pen(Color.FromArgb(75, ctx.AmarilloRetro), 1))
            using (SolidBrush relleno     = new SolidBrush(Color.FromArgb(200, ctx.MostazaSuave)))
            using (Pen        bordeTornillo = new Pen(ctx.AmarilloRetro, 2))
            {
                Rectangle area = new Rectangle(0, 0, w, h);
                area.Inflate(-8, -8);
                g.DrawRectangle(bordeClaro, area);

                Rectangle segundoBorde = area;
                segundoBorde.Inflate(-8, -8);
                g.DrawRectangle(bordeInner, segundoBorde);

                DibujarTornillo(g, relleno, bordeTornillo, 13,      13,      22);
                DibujarTornillo(g, relleno, bordeTornillo, w - 37,  13,      22);
                DibujarTornillo(g, relleno, bordeTornillo, 13,      h - 37,  22);
                DibujarTornillo(g, relleno, bordeTornillo, w - 37,  h - 37,  22);
            }
        }

        private void DibujarTornillo(Graphics g, SolidBrush relleno, Pen borde, int x, int y, int size)
        {
            g.FillEllipse(relleno, x, y, size, size);
            g.DrawEllipse(borde,   x, y, size, size);
            int cx = x + size / 2, cy = y + size / 2, slot = size / 3;
            using (Pen ranura = new Pen(Color.FromArgb(70, 45, 15), 2))
            {
                g.DrawLine(ranura, cx - slot, cy,       cx + slot, cy);
                g.DrawLine(ranura, cx,        cy - slot, cx,       cy + slot);
            }
        }
    }
}

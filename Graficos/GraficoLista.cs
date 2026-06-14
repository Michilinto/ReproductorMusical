using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ReproductorMusical
{
    internal class GraficoLista
    {
        private readonly ContextoUI ctx;
        public GraficoLista(ContextoUI ctx) { this.ctx = ctx; }

        public void DibujarPanel(Graphics g, int w, int h)
        {
            using (SolidBrush cabeceraFondo = new SolidBrush(Color.FromArgb(35, 22, 10)))
                g.FillRectangle(cabeceraFondo, 3, 3, w - 6, 39);

            using (Pen bordeExt = new Pen(ctx.MostazaSuave, 2))
            using (Pen bordeInt = new Pen(Color.FromArgb(90, ctx.AmarilloRetro), 1))
            {
                g.DrawRectangle(bordeExt, 2, 2, w - 5, h - 5);
                g.DrawRectangle(bordeInt, 6, 6, w - 13, h - 13);
            }

            using (SolidBrush esquina = new SolidBrush(ctx.MostazaSuave))
            {
                const int s = 6;
                g.FillRectangle(esquina, 2,         2,         s, s);
                g.FillRectangle(esquina, w - 2 - s, 2,         s, s);
                g.FillRectangle(esquina, 2,         h - 2 - s, s, s);
                g.FillRectangle(esquina, w - 2 - s, h - 2 - s, s, s);
            }

            using (Pen sep = new Pen(Color.FromArgb(160, ctx.AmarilloRetro), 1))
                g.DrawLine(sep, 8, 42, w - 9, 42);
        }

        public void DibujarItem(DrawItemEventArgs e)
        {
            if (ctx.Canciones == null || e.Index < 0 || e.Index >= ctx.Canciones.Count) return;

            Graphics  g          = e.Graphics;
            Rectangle bounds     = e.Bounds;
            bool      seleccionado = (e.State & DrawItemState.Selected) != 0;
            bool      esActual    = ctx.IndiceCancionActual >= 0 && e.Index == ctx.IndiceCancionActual;
            bool      activo      = seleccionado || esActual;

            Color bgColor = activo
                ? ctx.AmarilloRetro
                : (e.Index % 2 == 0 ? Color.FromArgb(16, 20, 26) : Color.FromArgb(20, 25, 32));
            using (SolidBrush bgBrush = new SolidBrush(bgColor))
                g.FillRectangle(bgBrush, bounds);

            string ext    = Path.GetExtension(ctx.Canciones[e.Index]).ToLowerInvariant();
            string nombre = Path.GetFileNameWithoutExtension(ctx.Canciones[e.Index]);
            string numero = (e.Index + 1).ToString("00");
            bool   esWav  = ext == ".wav";
            int    cy     = bounds.Y + bounds.Height / 2;

            Color colorNumero    = activo ? Color.FromArgb(90, 60, 10)  : Color.FromArgb(110, 90, 50);
            Color colorBadge     = activo ? Color.FromArgb(50, 35,  5)  : (esWav ? Color.FromArgb(22, 48, 22) : Color.FromArgb(8, 35, 52));
            Color colorTipo      = activo ? ctx.NegroSuave               : (esWav ? ctx.VerdeVintage : Color.FromArgb(0, 170, 210));
            Color colorNombre    = activo ? ctx.NegroSuave               : ctx.CremaRetro;

            using (Font fPequena = new Font("Consolas", 8f, FontStyle.Bold))
            using (Font fNombre  = new Font("Consolas", 9f, FontStyle.Bold))
            {
                SizeF szNum = g.MeasureString(numero, fPequena);
                using (SolidBrush b = new SolidBrush(colorNumero))
                    g.DrawString(numero, fPequena, b, bounds.X + 6, cy - szNum.Height / 2f);

                Rectangle badge = new Rectangle(bounds.X + 32, bounds.Y + 4, 20, bounds.Height - 8);
                using (SolidBrush b = new SolidBrush(colorBadge))
                    g.FillRectangle(b, badge);

                string tipoTexto = esWav ? "W" : "M";
                SizeF  szTipo    = g.MeasureString(tipoTexto, fPequena);
                using (SolidBrush b = new SolidBrush(colorTipo))
                    g.DrawString(tipoTexto, fPequena, b, badge.X + (badge.Width - szTipo.Width) / 2f, cy - szTipo.Height / 2f);

                SizeF szNom = g.MeasureString(nombre, fNombre);
                using (SolidBrush b = new SolidBrush(colorNombre))
                    g.DrawString(nombre, fNombre, b, bounds.X + 58, cy - szNom.Height / 2f);
            }
        }
    }
}

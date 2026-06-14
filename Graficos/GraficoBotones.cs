using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ReproductorMusical
{
    // Encapsula el estilo visual y los estados hover/pressed de todos los botones.
    internal class GraficoBotones
    {
        private readonly ContextoUI       ctx;
        private readonly HashSet<Button>  _hover    = new HashSet<Button>();
        private readonly HashSet<Button>  _pulsados = new HashSet<Button>();
        private readonly HashSet<Button>  _modoHover = new HashSet<Button>();

        public GraficoBotones(ContextoUI ctx) { this.ctx = ctx; }

        // ── Registro de botones ───────────────────────────────────────────────────

        public void AplicarEstiloBotonRetro(Button btn, string simbolo, string etiqueta)
        {
            btn.Tag    = simbolo + "§" + etiqueta;
            btn.Cursor = Cursors.Hand;
            btn.Paint     += BotonRetro_Paint;
            btn.MouseEnter += (s, e) => { _hover.Add((Button)s);       ((Button)s).Invalidate(); };
            btn.MouseLeave += (s, e) => { _hover.Remove((Button)s);    ((Button)s).Invalidate(); };
            btn.MouseDown  += (s, e) => { _pulsados.Add((Button)s);    ((Button)s).Invalidate(); };
            btn.MouseUp    += (s, e) => { _pulsados.Remove((Button)s); ((Button)s).Invalidate(); };
        }

        public void AplicarEstiloBotonModo(Button btn, string texto)
        {
            btn.Tag    = texto;
            btn.Cursor = Cursors.Hand;
            btn.Paint     += BtnModo_Paint;
            btn.MouseEnter += (s, e) => { _modoHover.Add((Button)s);    ((Button)s).Invalidate(); };
            btn.MouseLeave += (s, e) => { _modoHover.Remove((Button)s); ((Button)s).Invalidate(); };
        }

        // ── Paint: botones de control retro ──────────────────────────────────────

        private void BotonRetro_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int  w       = btn.Width;
            int  h       = btn.Height;
            bool hover   = _hover.Contains(btn);
            bool pressed = _pulsados.Contains(btn);

            string tag      = btn.Tag as string ?? "§";
            int    sep      = tag.IndexOf('§');
            string simbolo  = sep >= 0 ? tag.Substring(0, sep)     : tag;
            string etiqueta = sep >= 0 ? tag.Substring(sep + 1) : "";

            using (SolidBrush bg = new SolidBrush(Color.FromArgb(22, 14, 8)))
                g.FillRectangle(bg, 0, 0, w, h);

            int       labelH = 13;
            int       margin = 2;
            Rectangle body   = new Rectangle(margin, margin, w - margin * 2, h - margin * 2 - labelH);

            Color topColor = hover ? Color.FromArgb(170, 155, 120) : Color.FromArgb(140, 127, 98);
            Color midColor = hover ? Color.FromArgb(118, 107,  80) : Color.FromArgb( 96,  87, 64);
            Color botColor = hover ? Color.FromArgb( 60,  52,  36) : Color.FromArgb( 48,  42, 28);

            int third = body.Height / 3;
            using (SolidBrush b1 = new SolidBrush(topColor)) g.FillRectangle(b1, body.Left, body.Top,             body.Width, third);
            using (SolidBrush b2 = new SolidBrush(midColor)) g.FillRectangle(b2, body.Left, body.Top + third,     body.Width, third);
            using (SolidBrush b3 = new SolidBrush(botColor)) g.FillRectangle(b3, body.Left, body.Top + third * 2, body.Width, body.Height - third * 2);

            Color hiCol = pressed ? Color.FromArgb( 40,  35,  20) : Color.FromArgb(210, 195, 150);
            Color shCol = pressed ? Color.FromArgb(210, 195, 150) : Color.FromArgb( 25,  20,  10);
            using (Pen hiPen = new Pen(hiCol, 1.5f))
            {
                g.DrawLine(hiPen, body.Left, body.Top, body.Right - 1, body.Top);
                g.DrawLine(hiPen, body.Left, body.Top, body.Left,      body.Bottom);
            }
            using (Pen shPen = new Pen(shCol, 1.5f))
            {
                g.DrawLine(shPen, body.Left + 1, body.Bottom, body.Right - 1, body.Bottom);
                g.DrawLine(shPen, body.Right - 1, body.Top,   body.Right - 1, body.Bottom);
            }

            int       im      = 5;
            Rectangle inner   = new Rectangle(body.Left + im, body.Top + im, body.Width - im * 2, body.Height - im * 2);
            Color     innerCol = pressed ? Color.FromArgb(55, 44, 28) : Color.FromArgb(30, 22, 12);
            using (SolidBrush ib = new SolidBrush(innerCol)) g.FillRectangle(ib, inner);

            using (Pen inSh = new Pen(Color.FromArgb(10, 8, 4), 1f))
            {
                g.DrawLine(inSh, inner.Left, inner.Top, inner.Right, inner.Top);
                g.DrawLine(inSh, inner.Left, inner.Top, inner.Left,  inner.Bottom);
            }
            using (Pen inHi = new Pen(Color.FromArgb(65, 58, 38), 1f))
            {
                g.DrawLine(inHi, inner.Left, inner.Bottom, inner.Right, inner.Bottom);
                g.DrawLine(inHi, inner.Right, inner.Top,   inner.Right, inner.Bottom);
            }

            float symSize = Math.Min(inner.Height * 0.52f, 13f);
            using (Font fSym = new Font("Consolas", symSize, FontStyle.Bold, GraphicsUnit.Pixel))
            using (SolidBrush symBrush = new SolidBrush(Color.FromArgb(235, ctx.CremaRetro)))
            {
                SizeF sz = g.MeasureString(simbolo, fSym);
                float tx = inner.Left + (inner.Width  - sz.Width)  / 2f;
                float ty = inner.Top  + (inner.Height - sz.Height) / 2f;
                if (pressed) { tx += 1; ty += 1; }
                g.DrawString(simbolo, fSym, symBrush, tx, ty);
            }

            using (Font fLbl = new Font("Consolas", 6.5f, FontStyle.Bold, GraphicsUnit.Point))
            using (SolidBrush lblBrush = new SolidBrush(Color.FromArgb(170, ctx.MostazaSuave)))
            {
                SizeF sz = g.MeasureString(etiqueta, fLbl);
                g.DrawString(etiqueta, fLbl, lblBrush, (w - sz.Width) / 2f, body.Bottom + 2f);
            }
        }

        // ── Paint: botones de modo de visualización ───────────────────────────────

        private void BtnModo_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int    w      = btn.Width;
            int    h      = btn.Height;
            bool   hover  = _modoHover.Contains(btn);
            bool   activo = btn == ctx.ModoActivo;
            string texto  = btn.Tag as string ?? "";

            using (SolidBrush bg = new SolidBrush(Color.FromArgb(22, 14, 8)))
                g.FillRectangle(bg, 0, 0, w, h);

            int       m    = 2;
            Rectangle body = new Rectangle(m, m, w - m * 2, h - m * 2);
            int       third = body.Height / 3;

            if (activo)
            {
                Color c1 = hover ? Color.FromArgb(255, 198, 72) : Color.FromArgb(249, 178, 38);
                Color c2 = hover ? Color.FromArgb(215, 148, 16) : Color.FromArgb(190, 128,  6);
                Color c3 = hover ? Color.FromArgb(145,  98,  4) : Color.FromArgb(120,  80,  2);
                using (SolidBrush b1 = new SolidBrush(c1)) g.FillRectangle(b1, body.Left, body.Top,             body.Width, third);
                using (SolidBrush b2 = new SolidBrush(c2)) g.FillRectangle(b2, body.Left, body.Top + third,     body.Width, third);
                using (SolidBrush b3 = new SolidBrush(c3)) g.FillRectangle(b3, body.Left, body.Top + third * 2, body.Width, body.Height - third * 2);
                using (Pen hi = new Pen(Color.FromArgb( 40,  28,  4), 1.5f)) { g.DrawLine(hi, body.Left, body.Top, body.Right - 1, body.Top); g.DrawLine(hi, body.Left, body.Top, body.Left, body.Bottom); }
                using (Pen sh = new Pen(Color.FromArgb(255, 225, 130), 1.5f)) { g.DrawLine(sh, body.Left + 1, body.Bottom, body.Right - 1, body.Bottom); g.DrawLine(sh, body.Right - 1, body.Top, body.Right - 1, body.Bottom); }
                using (Font f = new Font("Consolas", 8.5f, FontStyle.Bold, GraphicsUnit.Point))
                using (SolidBrush tb = new SolidBrush(Color.FromArgb(28, 18, 3)))
                { SizeF sz = g.MeasureString(texto, f); g.DrawString(texto, f, tb, (w - sz.Width) / 2f, (h - sz.Height) / 2f); }
            }
            else
            {
                Color c1 = hover ? Color.FromArgb(122, 110, 82) : Color.FromArgb(95, 86, 62);
                Color c2 = hover ? Color.FromArgb( 80,  72, 52) : Color.FromArgb(62, 55, 38);
                Color c3 = hover ? Color.FromArgb( 46,  40, 26) : Color.FromArgb(34, 30, 18);
                using (SolidBrush b1 = new SolidBrush(c1)) g.FillRectangle(b1, body.Left, body.Top,             body.Width, third);
                using (SolidBrush b2 = new SolidBrush(c2)) g.FillRectangle(b2, body.Left, body.Top + third,     body.Width, third);
                using (SolidBrush b3 = new SolidBrush(c3)) g.FillRectangle(b3, body.Left, body.Top + third * 2, body.Width, body.Height - third * 2);
                using (Pen hi = new Pen(Color.FromArgb(168, 152, 112), 1.5f)) { g.DrawLine(hi, body.Left, body.Top, body.Right - 1, body.Top); g.DrawLine(hi, body.Left, body.Top, body.Left, body.Bottom); }
                using (Pen sh = new Pen(Color.FromArgb( 18,  14,   6), 1.5f)) { g.DrawLine(sh, body.Left + 1, body.Bottom, body.Right - 1, body.Bottom); g.DrawLine(sh, body.Right - 1, body.Top, body.Right - 1, body.Bottom); }
                using (Font f = new Font("Consolas", 8.5f, FontStyle.Bold, GraphicsUnit.Point))
                using (SolidBrush tb = new SolidBrush(Color.FromArgb(190, ctx.CremaRetro)))
                { SizeF sz = g.MeasureString(texto, f); g.DrawString(texto, f, tb, (w - sz.Width) / 2f, (h - sz.Height) / 2f); }
            }
        }
    }
}

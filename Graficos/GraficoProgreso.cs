using System;
using System.Drawing;

namespace ReproductorMusical
{
    internal class GraficoProgreso
    {
        private readonly ContextoUI ctx;
        public GraficoProgreso(ContextoUI ctx) { this.ctx = ctx; }

        public void Dibujar(Graphics g, int w, int h)
        {
            int posMs = ctx.PosicionMs;
            int durMs = ctx.DuracionActualMs;

            const int labelW = 80;
            int barX = labelW + 10, barW = w - labelW * 2 - 20;
            int barY = h / 2 - 5;
            const int barH = 10;

            using (Font fTiempo  = new Font("Consolas", 11f, FontStyle.Bold))
            using (SolidBrush dorado      = new SolidBrush(ctx.AmarilloRetro))
            using (SolidBrush cremaBrush  = new SolidBrush(Color.FromArgb(160, ctx.CremaRetro)))
            using (SolidBrush fondoBarra  = new SolidBrush(Color.FromArgb(45, 32, 18)))
            using (SolidBrush relleno     = new SolidBrush(ctx.AmarilloRetro))
            using (Pen        bordeBarra  = new Pen(ctx.MostazaSuave, 1))
            {
                string txtAct = ctx.FormatearTiempo(posMs), txtTot = ctx.FormatearTiempo(durMs);
                SizeF szAct = g.MeasureString(txtAct, fTiempo);
                SizeF szTot = g.MeasureString(txtTot, fTiempo);
                g.DrawString(txtAct, fTiempo, dorado,    labelW - szAct.Width - 4, (h - szAct.Height) / 2f);
                g.DrawString(txtTot, fTiempo, cremaBrush, w - labelW + 4,          (h - szTot.Height) / 2f);

                g.FillRectangle(fondoBarra, barX, barY, barW, barH);
                g.DrawRectangle(bordeBarra, barX, barY, barW, barH);

                if (durMs > 0 && posMs > 0)
                {
                    int fillW = (int)(barW * Math.Min(1f, posMs / (float)durMs));
                    if (fillW > 0)
                    {
                        g.FillRectangle(relleno, barX, barY, fillW, barH);
                        using (SolidBrush cursor = new SolidBrush(ctx.CremaRetro))
                            g.FillRectangle(cursor, barX + fillW - 2, barY - 3, 4, barH + 6);
                    }
                }

                using (Pen sep = new Pen(Color.FromArgb(22, 14, 8), 1))
                    for (int x = barX + 10; x < barX + barW; x += 10)
                        g.DrawLine(sep, x, barY, x, barY + barH);
            }
        }
    }
}

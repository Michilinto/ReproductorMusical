using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ReproductorMusical
{
    // Modelo atómico: núcleo central + 3 órbitas elípticas giradas con R(θ) + electrones + rayos de energía.
    // Cada punto orbital: lx = rx·cos t,  ly = ry·sin t  →  R(φ): wx = lx·cosφ − ly·sinφ,  wy = lx·sinφ + ly·cosφ
    internal class VisualizadorFiguras : VisualizadorBase
    {
        public VisualizadorFiguras(ContextoVisualizacion contexto) : base(contexto) { }

        public override void Dibujar(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int W  = Math.Max(1, Contexto.Ancho);
            int H  = Math.Max(1, Contexto.Alto);
            float energia = Contexto.Energia;
            float fase    = Contexto.FaseAnimacion;
            int cX = W / 2, cY = H / 2;
            int rOrb = Math.Min(W, H) / 3;

            float beatBoost = Contexto.BeatTransiente ? 1.0f : 0f;

            // ── 1. RAYOS DE ENERGÍA radiales ─────────────────────────────────────
            int nRayos = 40;
            float rayMaxLen = rOrb * (0.55f + energia * 0.85f + beatBoost * 0.5f);
            for (int k = 0; k < nRayos; k++)
            {
                double ang    = k * 2.0 * Math.PI / nRayos + fase * 0.18;
                float startR  = rOrb * 0.12f;
                float len     = rayMaxLen * (0.4f + 0.6f * (float)Math.Abs(Math.Sin(fase * 0.7 + k)));
                float x1 = cX + (float)(Math.Cos(ang) * startR);
                float y1 = cY + (float)(Math.Sin(ang) * startR);
                float x2 = cX + (float)(Math.Cos(ang) * (startR + len));
                float y2 = cY + (float)(Math.Sin(ang) * (startR + len));
                int alfaRayo = (int)((energia * 110 + beatBoost * 80) * (k % 3 == 0 ? 1.0 : 0.55));
                if (alfaRayo < 5) continue;

                Color rc;
                switch (k % 4)
                {
                    case 0:  rc = ContextoVisualizacion.Crema;        break;
                    case 1:  rc = ContextoVisualizacion.Amarillo;     break;
                    case 2:  rc = ContextoVisualizacion.RojoLadrillo; break;
                    default: rc = ContextoVisualizacion.AzulPetroleo; break;
                }
                using (Pen rp = new Pen(Color.FromArgb(alfaRayo, rc), k % 6 == 0 ? 2.0f : 0.8f))
                    g.DrawLine(rp, x1, y1, x2, y2);
            }

            // ── 2. ÓRBITAS ELÍPTICAS con R(φ) explícito ──────────────────────────
            float[] orbRx   = { rOrb * 1.00f,  rOrb * 0.90f,  rOrb * 0.75f };
            float[] orbRy   = { rOrb * 0.30f,  rOrb * 0.28f,  rOrb * 0.32f };
            float[] orbPhi0 = { 0f, (float)(Math.PI / 3), (float)(Math.PI * 2 / 3) };
            float[] orbVel  = { 0.28f, -0.42f, 0.35f };
            float[] eVel    = { 1.8f, -2.2f, 1.5f };
            Color[] orbCols = { ContextoVisualizacion.AzulPetroleo, ContextoVisualizacion.RojoLadrillo, ContextoVisualizacion.Mostaza };
            const int nEll  = 80;
            float orbScale  = 1.0f + energia * 0.10f + beatBoost * 0.07f;

            for (int oi = 0; oi < 3; oi++)
            {
                float  rx     = orbRx[oi] * orbScale;
                float  ry     = orbRy[oi] * orbScale;
                float  phi    = orbPhi0[oi] + fase * orbVel[oi];
                double cosPhi = Math.Cos(phi), sinPhi = Math.Sin(phi);
                Color  oc     = orbCols[oi];

                var ellPts = new PointF[nEll + 1];
                for (int k = 0; k <= nEll; k++)
                {
                    double t  = k * 2.0 * Math.PI / nEll;
                    double lx = rx * Math.Cos(t), ly = ry * Math.Sin(t);
                    ellPts[k] = new PointF(cX + (float)(lx * cosPhi - ly * sinPhi),
                                           cY + (float)(lx * sinPhi + ly * cosPhi));
                }
                using (Pen orbGlow = new Pen(Color.FromArgb(40,  oc), 5f))   g.DrawLines(orbGlow, ellPts);
                using (Pen orbLine = new Pen(Color.FromArgb(160, oc), 1.5f)) g.DrawLines(orbLine, ellPts);

                // Electrón
                double eAng  = fase * eVel[oi] + oi * Math.PI * 0.66;
                double elx   = rx * Math.Cos(eAng), ely = ry * Math.Sin(eAng);
                float  ex    = cX + (float)(elx * cosPhi - ely * sinPhi);
                float  ey    = cY + (float)(elx * sinPhi + ely * cosPhi);
                int    eTam  = (int)(9 + energia * 11 + beatBoost * 6);
                using (SolidBrush eg = new SolidBrush(Color.FromArgb(55,  oc)))  g.FillEllipse(eg, ex - eTam,     ey - eTam,     eTam * 2, eTam * 2);
                using (SolidBrush eb = new SolidBrush(Color.FromArgb(230, oc)))  g.FillEllipse(eb, ex - eTam / 2, ey - eTam / 2, eTam,     eTam);
                using (SolidBrush ec = new SolidBrush(Color.FromArgb(245, ContextoVisualizacion.Crema)))
                    g.FillEllipse(ec, ex - 3, ey - 3, 6, 6);
            }

            // ── 3. NÚCLEO con capas de glow y figura geométrica cambiante ─────────
            int rNuc = (int)(rOrb * 0.20f + energia * rOrb * 0.08f + beatBoost * 12);

            int[]   glowAlfa = { 18, 28, 40, 55, 70 };
            Color[] glowCols = { ContextoVisualizacion.RojoLadrillo, ContextoVisualizacion.RojoLadrillo,
                                  ContextoVisualizacion.Amarillo,     ContextoVisualizacion.Amarillo,
                                  ContextoVisualizacion.Crema };
            for (int layer = 0; layer < 5; layer++)
            {
                int lr   = rNuc + (4 - layer) * (int)(8 + energia * 10);
                int alfa = (int)(glowAlfa[layer] * (0.7f + energia * 0.5f + beatBoost * 0.4f));
                using (SolidBrush lb = new SolidBrush(Color.FromArgb(Math.Min(255, alfa), glowCols[layer])))
                    g.FillEllipse(lb, cX - lr, cY - lr, lr * 2, lr * 2);
            }
            using (SolidBrush nucBrush = new SolidBrush(Color.FromArgb(210, ContextoVisualizacion.RojoLadrillo)))
                g.FillEllipse(nucBrush, cX - rNuc, cY - rNuc, rNuc * 2, rNuc * 2);

            // Figura central: triángulo → cuadrado → pentágono cada ~1.7 s
            float tForma    = (float)((fase * 0.18) % 3.0);
            int   nLados    = tForma < 1f ? 3 : tForma < 2f ? 4 : 5;
            int   nLadosSig = nLados == 3 ? 4 : nLados == 4 ? 5 : 3;
            float blend     = tForma % 1.0f;

            DibujarPoligonoTransformado(g, cX, cY, nLados,
                radio:   (int)(rNuc * 0.78f + energia * 6),
                angulo:  fase * 2.8f,
                escalaX: 1f + energia * 0.2f, escalaY: 1f + energia * 0.2f,
                color:   Color.FromArgb((int)(215 * (1 - blend * 0.5f)), ContextoVisualizacion.Crema), grosor: 2);

            if (blend > 0.45f)
            {
                float t2 = (blend - 0.45f) / 0.55f;
                DibujarPoligonoTransformado(g, cX, cY, nLadosSig,
                    radio:   (int)(rNuc * 0.55f * t2 + energia * 4),
                    angulo:  -fase * 2.2f,
                    escalaX: 1f, escalaY: 1f,
                    color:   Color.FromArgb((int)(180 * t2), ContextoVisualizacion.Amarillo), grosor: 1);
            }

            int rCore = (int)(rNuc * 0.38f + energia * 6 + beatBoost * 4);
            using (SolidBrush coreBrush = new SolidBrush(Color.FromArgb(220, ContextoVisualizacion.Crema)))
                g.FillEllipse(coreBrush, cX - rCore, cY - rCore, rCore * 2, rCore * 2);
            using (SolidBrush whiteDot = new SolidBrush(Color.White))
                g.FillEllipse(whiteDot, cX - 4, cY - 4, 8, 8);
        }

        // Polígono regular con R(θ)·S aplicado a cada vértice:
        //   | cos θ  -sin θ |   | escalaX · cos α · radio |
        //   | sin θ   cos θ | × | escalaY · sin α · radio |
        private static void DibujarPoligonoTransformado(Graphics g, int cx, int cy, int lados,
            int radio, float angulo, float escalaX, float escalaY, Color color, int grosor)
        {
            double cosT = Math.Cos(angulo);
            double sinT = Math.Sin(angulo);
            var pts = new PointF[lados];

            for (int i = 0; i < lados; i++)
            {
                double alfa = i * 2.0 * Math.PI / lados;
                double lx   = Math.Cos(alfa) * radio * escalaX;
                double ly   = Math.Sin(alfa) * radio * escalaY;
                pts[i] = new PointF(cx + (float)(lx * cosT - ly * sinT),
                                    cy + (float)(lx * sinT + ly * cosT));
            }

            using (SolidBrush fill = new SolidBrush(Color.FromArgb(18, color.R, color.G, color.B)))
                g.FillPolygon(fill, pts);
            using (Pen p = new Pen(color, grosor))
                g.DrawPolygon(p, pts);
        }
    }
}

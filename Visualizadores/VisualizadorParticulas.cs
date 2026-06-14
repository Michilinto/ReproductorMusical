using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ReproductorMusical
{
    internal class VisualizadorParticulas : VisualizadorBase
    {
        private readonly List<ParticulaVisual> particulas = new List<ParticulaVisual>();
        private readonly List<AnilloOnda>      anillos    = new List<AnilloOnda>();
        private readonly Random                aleatorio  = new Random();

        public VisualizadorParticulas(ContextoVisualizacion contexto) : base(contexto) { }

        public override void Inicializar()
        {
            InicializarParticulas();
        }

        public override void AlRedimensionar()
        {
            InicializarParticulas();
        }

        public override void Actualizar()
        {
            if (Contexto.Ancho <= 0 || Contexto.Alto <= 0) return;

            int   W             = Contexto.Ancho;
            int   H             = Contexto.Alto;
            float energia       = Contexto.Energia;
            bool  beatTransiente = Contexto.BeatTransiente;

            int idx = 0;
            foreach (ParticulaVisual p in particulas)
            {
                float speed = 0.8f + energia * 2.8f + (beatTransiente ? 2.5f : 0f);
                p.X       += p.VX * speed;
                p.Y       += p.VY * speed;
                p.Rotacion += p.VelRotacion * (1f + energia * 4f);

                if (p.X < -20)    p.X = W + 20;
                if (p.X > W + 20) p.X = -20;
                if (p.Y > H + 30) { p.X = (float)aleatorio.NextDouble() * W; p.Y = -20; }

                float intervaloActual = Math.Max(12f, p.IntervaloAnillo * (1.0f - energia * 0.55f));

                if (beatTransiente && idx % 2 == 0)
                {
                    anillos.Add(new AnilloOnda(p.X, p.Y,
                        radioMax:  p.Tamano * 7 + energia * 55 + 30,
                        colorBase: p.ColorBase));
                    p.TimerAnillo = intervaloActual;
                }
                else
                {
                    p.TimerAnillo--;
                    if (p.TimerAnillo <= 0)
                    {
                        anillos.Add(new AnilloOnda(p.X, p.Y,
                            radioMax:  p.Tamano * 5 + energia * 40 + 18,
                            colorBase: p.ColorBase));
                        p.TimerAnillo = intervaloActual;
                    }
                }

                float destello = beatTransiente ? 0.35f : 0f;
                p.Alfa = Limitar01(0.65f + energia * 0.35f
                    + (float)Math.Sin(Contexto.FaseAnimacion * 1.5 + p.X * 0.01) * 0.2f + destello);
                idx++;
            }

            // Shockwave central en beats intensos
            if (beatTransiente && energia > Math.Max(0.05f, Contexto.EnergiaAnterior) * 1.5f)
            {
                anillos.Add(new AnilloOnda(W / 2f, H / 2f,
                    radioMax:  Math.Min(W, H) * 0.38f,
                    colorBase: ContextoVisualizacion.Amarillo));
            }

            // Expandir y eliminar anillos expirados
            for (int i = anillos.Count - 1; i >= 0; i--)
            {
                AnilloOnda a = anillos[i];
                a.Radio += 1.5f + energia * 2.2f;
                a.Alfa   = Limitar01(1.0f - a.Radio / a.RadioMax);
                if (a.Alfa <= 0.01f) anillos.RemoveAt(i);
            }
        }

        public override void Dibujar(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            float energia = Contexto.Energia;

            // 1. Anillos de onda expansivos
            foreach (AnilloOnda anillo in anillos)
            {
                int r = (int)anillo.Radio;
                if (r <= 0) continue;
                int alfaAnillo = (int)(anillo.Alfa * 255);
                if (alfaAnillo <= 2) continue;

                using (Pen halo = new Pen(Color.FromArgb(alfaAnillo / 5, anillo.ColorBase), 8f))
                    g.DrawEllipse(halo, anillo.CX - r - 4, anillo.CY - r - 4, (r + 4) * 2, (r + 4) * 2);
                using (Pen aro = new Pen(Color.FromArgb(alfaAnillo, anillo.ColorBase), 2.5f))
                    g.DrawEllipse(aro, anillo.CX - r, anillo.CY - r, r * 2, r * 2);
                int r2 = Math.Max(1, r - 8);
                using (Pen aroInt = new Pen(Color.FromArgb(alfaAnillo / 3, anillo.ColorBase), 1f))
                    g.DrawEllipse(aroInt, anillo.CX - r2, anillo.CY - r2, r2 * 2, r2 * 2);
            }

            // 2. Estrellas cayendo con estela
            foreach (ParticulaVisual p in particulas)
            {
                int alfa = (int)(p.Alfa * 255);
                if (alfa <= 0) continue;
                Color col = Color.FromArgb(alfa, p.ColorBase);

                int trailLen = (int)(p.Tamano * 4 + energia * 30);
                using (Pen trail = new Pen(Color.FromArgb(alfa / 4, p.ColorBase), 2f))
                    g.DrawLine(trail, p.X, p.Y - p.Tamano, p.X, p.Y - p.Tamano - trailLen);
                using (Pen trailFade = new Pen(Color.FromArgb(alfa / 10, p.ColorBase), 1f))
                    g.DrawLine(trailFade, p.X, p.Y - p.Tamano - trailLen, p.X, p.Y - p.Tamano - trailLen * 2);

                DibujarEstrella5Puntas(g, p.X, p.Y, p.Tamano, p.Rotacion, col, alfa, energia);
            }
        }

        // ── Helpers privados ──────────────────────────────────────────────────────

        private void InicializarParticulas()
        {
            particulas.Clear();
            anillos.Clear();

            int ancho = Math.Max(200, Contexto.Ancho);
            int alto  = Math.Max(200, Contexto.Alto);

            Color[] paleta =
            {
                ContextoVisualizacion.Amarillo,
                ContextoVisualizacion.Mostaza,
                ContextoVisualizacion.Crema,
                Color.FromArgb(255, 210, 100, 80),
                ContextoVisualizacion.AzulPetroleo,
            };

            for (int i = 0; i < 28; i++)
            {
                Color color     = paleta[i % paleta.Length];
                float tamano    = (float)(aleatorio.NextDouble() * 12 + 5);
                float vx        = (float)(aleatorio.NextDouble() * 1.2 - 0.6);
                float vy        = (float)(aleatorio.NextDouble() * 1.5 + 0.4);
                float velRot    = (float)(aleatorio.NextDouble() * 0.06 - 0.03);
                float intervalo = (float)(aleatorio.NextDouble() * 80 + 40);
                particulas.Add(new ParticulaVisual(
                    x: (float)aleatorio.NextDouble() * ancho,
                    y: (float)aleatorio.NextDouble() * alto,
                    vx: vx, vy: vy,
                    tamano: tamano, colorBase: color,
                    velRotacion: velRot, intervaloAnillo: intervalo));
            }
        }

        // Estrella de 5 puntas con R(θ)·S aplicado a cada vértice:
        //   wx = lx·cos(θ) - ly·sin(θ),   wy = lx·sin(θ) + ly·cos(θ)
        private void DibujarEstrella5Puntas(Graphics g, float cx, float cy, float radio,
            float angulo, Color col, int alfa, float energia)
        {
            double cosT   = Math.Cos(angulo);
            double sinT   = Math.Sin(angulo);
            const int nPuntas = 5;
            float radioInt = radio / 2.4f;
            var pts = new PointF[nPuntas * 2];

            for (int k = 0; k < nPuntas * 2; k++)
            {
                float  r  = (k % 2 == 0) ? radio : radioInt;
                double a  = -Math.PI / 2.0 + k * Math.PI / nPuntas;
                double lx = Math.Cos(a) * r;
                double ly = Math.Sin(a) * r;
                pts[k] = new PointF(cx + (float)(lx * cosT - ly * sinT),
                                    cy + (float)(lx * sinT + ly * cosT));
            }

            float gr = radio * (1.8f + energia * 2.0f);
            using (SolidBrush glow = new SolidBrush(Color.FromArgb(Math.Min(40, alfa / 5), col)))
                g.FillEllipse(glow, cx - gr, cy - gr, gr * 2, gr * 2);
            float gm = radio * (1.1f + energia * 0.8f);
            using (SolidBrush glow2 = new SolidBrush(Color.FromArgb(alfa / 4, col)))
                g.FillEllipse(glow2, cx - gm, cy - gm, gm * 2, gm * 2);
            using (SolidBrush fill = new SolidBrush(Color.FromArgb((int)(alfa * 0.75f), col)))
                g.FillPolygon(fill, pts);
            using (Pen outline = new Pen(Color.FromArgb(alfa, col), 1.5f))
                g.DrawPolygon(outline, pts);
            float ray = radio * (1.4f + energia * 0.8f);
            using (Pen rayo = new Pen(Color.FromArgb(alfa / 2, col), 1f))
            {
                g.DrawLine(rayo, cx, cy - ray, cx, cy + ray);
                g.DrawLine(rayo, cx - ray, cy, cx + ray, cy);
            }
            using (SolidBrush centro = new SolidBrush(Color.FromArgb(alfa, Color.White)))
                g.FillEllipse(centro, cx - 2.5f, cy - 2.5f, 5f, 5f);
        }
    }
}

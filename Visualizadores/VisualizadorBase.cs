using System.Drawing;

namespace ReproductorMusical
{
    // Contrato de polimorfismo: todo visualizador debe saber dibujarse y
    // actualizarse. Expone helpers de color compartidos como métodos protegidos.
    internal abstract class VisualizadorBase
    {
        protected readonly ContextoVisualizacion Contexto;

        protected VisualizadorBase(ContextoVisualizacion contexto)
        {
            Contexto = contexto;
        }

        // Llamado una vez al activar el modo (p. ej. inicializar partículas)
        public virtual void Inicializar() { }

        // Llamado cuando el panel cambia de tamaño
        public virtual void AlRedimensionar() { }

        // Llamado cada tick del timer de animación (física, beat detection, etc.)
        public virtual void Actualizar() { }

        // Dibuja el frame actual sobre el Graphics entregado
        public abstract void Dibujar(Graphics g);

        // ── Utilidades compartidas ────────────────────────────────────────────────
        protected static int Mezclar(int inicio, int fin, float t)
        {
            t = t < 0f ? 0f : t > 1f ? 1f : t;
            return inicio + (int)((fin - inicio) * t);
        }

        protected static float Limitar01(float v)
        {
            return v < 0f ? 0f : v > 1f ? 1f : v;
        }
    }
}

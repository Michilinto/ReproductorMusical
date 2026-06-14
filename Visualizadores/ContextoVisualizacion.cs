using System.Drawing;

namespace ReproductorMusical
{
    // Objeto de contexto compartido entre Michimusic y los visualizadores.
    // Michimusic lo actualiza cada tick; los visualizadores solo lo leen.
    internal class ContextoVisualizacion
    {
        // Dimensiones del panel de dibujo
        public int Ancho { get; set; }
        public int Alto  { get; set; }

        // Estado de animación
        public float FaseAnimacion   { get; set; }
        public float Energia         { get; set; }
        public int   PosicionMs      { get; set; }

        // Beat detection (calculado en Michimusic.timerAnimacion_Tick)
        public float EnergiaAnterior { get; set; }
        public bool  BeatTransiente  { get; set; }

        // Analizador de audio (referencia compartida, no cambia en tiempo de ejecución)
        public AnalizadorAudio Analizador { get; set; }

        // ── Paleta retro (constantes estáticas, accesibles desde cualquier visualizador) ──
        public static readonly Color Crema        = Color.FromArgb(245, 230, 189);
        public static readonly Color Mostaza      = Color.FromArgb(223, 160,  93);
        public static readonly Color RojoLadrillo = Color.FromArgb(172,  80,  69);
        public static readonly Color AzulPetroleo = Color.FromArgb(  2, 108, 128);
        public static readonly Color Amarillo     = Color.FromArgb(249, 162,   4);
        public static readonly Color NegroSuave   = Color.FromArgb( 26,  31,  37);
        public static readonly Color FondoRadio   = Color.FromArgb( 22,  14,   8);
    }
}

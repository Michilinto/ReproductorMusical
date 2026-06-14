using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ReproductorMusical
{
    // Estado compartido que todos los graficadores de interfaz leen al dibujar.
    internal class ContextoUI
    {
        // ── Paleta de colores de la interfaz (solo lectura) ───────────────────────
        public readonly Color CremaRetro    = Color.FromArgb(245, 230, 189);
        public readonly Color MostazaSuave  = Color.FromArgb(223, 160,  93);
        public readonly Color RojoLadrillo  = Color.FromArgb(172,  80,  69);
        public readonly Color VerdeVintage  = Color.FromArgb(101, 135,  97);
        public readonly Color AzulPetroleo  = Color.FromArgb(  2, 108, 128);
        public readonly Color NegroSuave    = Color.FromArgb( 26,  31,  37);
        public readonly Color AmarilloRetro = Color.FromArgb(249, 162,   4);

        // ── Estado de reproducción (Michimusic sincroniza antes de cada Paint) ────
        public bool         Reproduciendo      { get; set; }
        public bool         EnPausa            { get; set; }
        public int          VolumenValor        { get; set; }
        public int          DuracionActualMs    { get; set; }
        public int          PosicionMs          { get; set; }
        public int          IndiceCancionActual { get; set; }
        public List<string> Canciones           { get; set; }
        public Button       ModoActivo          { get; set; }

        public string FormatearTiempo(int ms)
        {
            if (ms < 0) ms = 0;
            TimeSpan t = TimeSpan.FromMilliseconds(ms);
            return ((int)t.TotalMinutes).ToString("00") + ":" + t.Seconds.ToString("00");
        }
    }
}

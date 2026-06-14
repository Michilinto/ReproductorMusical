using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace ReproductorMusical
{
    public partial class Michimusic : Form
    {
        // ── Datos de canciones y timers ───────────────────────────────────────────
        private readonly List<string> canciones         = new List<string>();
        private readonly Timer        timerReproduccion = new Timer();
        private readonly Timer        timerAnimacion    = new Timer();

        // ── Reproductor ───────────────────────────────────────────────────────────
        private dynamic reproductor;
        private bool    reproductorDisponible;
        private bool    cancionAbierta;
        private bool    reproduciendo;
        private bool    enPausa;
        private int     duracionActualMs;
        private int     indiceCancionActual = -1;

        // ── Animación y volumen ───────────────────────────────────────────────────
        private float faseAnimacion;
        private int   modoVisualActual;
        private int   volumenValor = 50;

        // ── Beat detection ────────────────────────────────────────────────────────
        private float energiaAnterior;
        private int   p_beatCooldown;

        // ── Subsistemas de audio y visualización ──────────────────────────────────
        private readonly AnalizadorAudio       analizador = new AnalizadorAudio();
        private readonly ContextoVisualizacion contexto   = new ContextoVisualizacion();
        private VisualizadorBase               visualizadorActual;

        // ── Contexto compartido para los graficadores de UI ───────────────────────
        private readonly ContextoUI contextoUI = new ContextoUI();

        // ── Clases de graficado de paneles ────────────────────────────────────────
        private GraficoBotones        graficoBotones;
        private GraficoHeader         graficoHeader;
        private GraficoFooter         graficoFooter;
        private GraficoProgreso       graficoProgreso;
        private GraficoVolumen        graficoVolumen;
        private GraficoLista          graficoLista;
        private GraficoMarco          graficoMarco;
        private GraficoSelectorVisual graficoSelectorVisual;

        // ─────────────────────────────────────────────────────────────────────────
        public Michimusic()
        {
            InitializeComponent();
            InicializarInterfaz();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            DetenerTimer();
            timerAnimacion.Stop();
            CerrarCancionActual();
            LiberarReproductor();
            base.OnFormClosing(e);
        }

        private void InicializarInterfaz()
        {
            contexto.Analizador   = analizador;
            contextoUI.Canciones  = canciones;
            contextoUI.IndiceCancionActual = -1;
            contextoUI.VolumenValor        = volumenValor;

            graficoBotones        = new GraficoBotones(contextoUI);
            graficoHeader         = new GraficoHeader(contextoUI);
            graficoFooter         = new GraficoFooter(contextoUI);
            graficoProgreso       = new GraficoProgreso(contextoUI);
            graficoVolumen        = new GraficoVolumen(contextoUI);
            graficoLista          = new GraficoLista(contextoUI);
            graficoMarco          = new GraficoMarco(contextoUI);
            graficoSelectorVisual = new GraficoSelectorVisual(contextoUI);

            ConfigurarEstilos();
            ConfigurarPanelVisualizador();
            ConfigurarReproductor();
            ActualizarModoVisual(0);
            ActualizarVolumen();
            CargarCancionesDesdeCarpeta();
        }

        // ── Configuración de estilos ──────────────────────────────────────────────
        private void ConfigurarEstilos()
        {
            graficoBotones.AplicarEstiloBotonRetro(btnCargar,    "▲",   "C A R G A R");
            graficoBotones.AplicarEstiloBotonRetro(btnAnterior,  "|◀◀", "R E W");
            graficoBotones.AplicarEstiloBotonRetro(btnPlay,      "▶",   "P L A Y");
            graficoBotones.AplicarEstiloBotonRetro(btnPause,     "‖",   "P A U S E");
            graficoBotones.AplicarEstiloBotonRetro(btnStop,      "■",   "S T O P");
            graficoBotones.AplicarEstiloBotonRetro(btnSiguiente, "▶▶|", "F . F .");

            contextoUI.ModoActivo = btnModoBarras;
            graficoBotones.AplicarEstiloBotonModo(btnModoBarras,     "BARRAS");
            graficoBotones.AplicarEstiloBotonModo(btnModoOnda,       "ONDA");
            graficoBotones.AplicarEstiloBotonModo(btnModoParticulas, "PARTIC.");
            graficoBotones.AplicarEstiloBotonModo(btnModoFiguras,    "FIGURAS");
            graficoBotones.AplicarEstiloBotonModo(btnModoCircular,   "CIRC.");
        }

        private void ConfigurarPanelVisualizador()
        {
            ActivarDobleBuffer(panelVisualizador);
            ActivarDobleBuffer(panelVolumen);
            ActivarDobleBuffer(panelFooter);
            panelVisualizador.Paint  += panelVisualizador_Paint;
            panelVisualizador.Resize += panelVisualizador_Resize;
            panelMarcoVisualizador.Invalidate();
        }

        private void ConfigurarReproductor()
        {
            CrearReproductorWindowsMedia();

            timerReproduccion.Interval = 250;
            timerReproduccion.Tick    += timerReproduccion_Tick;

            timerAnimacion.Interval = 33;
            timerAnimacion.Tick    += timerAnimacion_Tick;
            timerAnimacion.Start();

            btnCargar.Click    += btnCargar_Click;
            btnAnterior.Click  += btnAnterior_Click;
            btnPlay.Click      += btnPlay_Click;
            btnPause.Click     += btnPause_Click;
            btnStop.Click      += btnStop_Click;
            btnSiguiente.Click += btnSiguiente_Click;
            lstCancionesUnificada.DoubleClick += lstCancionesUnificada_DoubleClick;

            btnModoBarras.Click     += (s, e) => ActualizarModoVisual(0);
            btnModoOnda.Click       += (s, e) => ActualizarModoVisual(1);
            btnModoParticulas.Click += (s, e) => ActualizarModoVisual(2);
            btnModoFiguras.Click    += (s, e) => ActualizarModoVisual(3);
            btnModoCircular.Click   += (s, e) => ActualizarModoVisual(4);
        }

        private void CrearReproductorWindowsMedia()
        {
            try
            {
                Type tipo = Type.GetTypeFromProgID("WMPlayer.OCX");
                if (tipo == null) { lblEstado.Text = "Estado: Windows Media no disponible"; return; }
                reproductor = Activator.CreateInstance(tipo);
                reproductor.settings.autoStart = false;
                reproductorDisponible = true;
            }
            catch
            {
                reproductorDisponible = false;
                lblEstado.Text = "Estado: Error al iniciar reproductor";
            }
        }

        private void ActivarDobleBuffer(Control control)
        {
            System.Reflection.PropertyInfo p = typeof(Control).GetProperty(
                "DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (p != null) p.SetValue(control, true, null);
        }

        // ── Canciones ─────────────────────────────────────────────────────────────
        private void CargarCancionesDesdeCarpeta()
        {
            string carpeta = ObtenerCarpetaCanciones();
            if (!Directory.Exists(carpeta)) Directory.CreateDirectory(carpeta);

            canciones.Clear();
            canciones.AddRange(Directory.GetFiles(carpeta, "*.wav"));
            canciones.AddRange(Directory.GetFiles(carpeta, "*.mp3"));
            canciones.AddRange(Directory.GetFiles(carpeta, "*.wma"));
            canciones.AddRange(Directory.GetFiles(carpeta, "*.mid"));

            if (canciones.Count > 0)
            {
                indiceCancionActual = 0;
                lblCancionActual.Text = "Canción actual: " + Path.GetFileName(canciones[0]);
                lblEstado.Text = "Estado: " + canciones.Count + " canción(es) en carpeta";
                ActualizarListaCanciones();
                SeleccionarCancionEnLista();
            }
            else
            {
                indiceCancionActual = -1;
                lblCancionActual.Text = "Canción actual: Ninguna canción cargada";
                lblEstado.Text = "Estado: Listo";
                ActualizarListaCanciones();
            }
        }

        private string ObtenerCarpetaCanciones()
        {
            string carpetaProyecto = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\Canciones"));
            return Directory.Exists(carpetaProyecto) ? carpetaProyecto : Path.Combine(Application.StartupPath, "Canciones");
        }

        private void ActualizarListaCanciones()
        {
            lstCancionesUnificada.BeginUpdate();
            lstCancionesUnificada.Items.Clear();
            for (int i = 0; i < canciones.Count; i++)
            {
                string ext    = Path.GetExtension(canciones[i]).ToLowerInvariant();
                string nombre = Path.GetFileNameWithoutExtension(canciones[i]);
                string tipo   = ext == ".wav" ? "[W]" : "[M]";
                lstCancionesUnificada.Items.Add((i + 1).ToString("00") + " " + tipo + "  " + nombre);
            }
            lstCancionesUnificada.EndUpdate();
        }

        private void SeleccionarCancionEnLista()
        {
            lstCancionesUnificada.ClearSelected();
            if (indiceCancionActual >= 0 && indiceCancionActual < lstCancionesUnificada.Items.Count)
                lstCancionesUnificada.SelectedIndex = indiceCancionActual;
            lstCancionesUnificada.Invalidate();
        }

        // ── Reproducción ──────────────────────────────────────────────────────────
        private void btnCargar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title       = "Cargar canciones";
                dlg.Filter      = "Archivos de audio|*.mp3;*.wav;*.wma;*.mid|Todos los archivos|*.*";
                dlg.Multiselect = true;
                if (dlg.ShowDialog() != DialogResult.OK) return;

                int primera = canciones.Count;
                foreach (string archivo in dlg.FileNames)
                    if (!canciones.Contains(archivo)) canciones.Add(archivo);
                ActualizarListaCanciones();

                if (!cancionAbierta && canciones.Count > 0)
                {
                    DetenerTimer();
                    CerrarCancionActual();
                    indiceCancionActual = primera;
                    AbrirCancionActual();
                    SeleccionarCancionEnLista();
                    lblEstado.Text = cancionAbierta ? "Estado: Canción cargada" : "Estado: No se pudo cargar";
                }
                else
                {
                    lblEstado.Text = "Estado: " + dlg.FileNames.Length + " canción(es) agregada(s)";
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)      { Reproducir(); }
        private void btnStop_Click(object sender, EventArgs e)      { DetenerReproduccion(); }
        private void btnAnterior_Click(object sender, EventArgs e)  { CambiarCancion(-1); }
        private void btnSiguiente_Click(object sender, EventArgs e) { CambiarCancion(1); }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (!cancionAbierta || !reproduciendo || !reproductorDisponible) return;
            if (enPausa)
            {
                reproductor.controls.play();
                enPausa = false;
                lblEstado.Text = "Estado: Reproduciendo";
            }
            else
            {
                reproductor.controls.pause();
                enPausa = true;
                lblEstado.Text = "Estado: Pausado";
            }
            panelFooter.Invalidate();
        }

        private void lstCancionesUnificada_DoubleClick(object sender, EventArgs e)
        {
            int idx = lstCancionesUnificada.SelectedIndex;
            if (idx < 0 || idx >= canciones.Count) return;
            DetenerTimer();
            CerrarCancionActual();
            indiceCancionActual = idx;
            SeleccionarCancionEnLista();
            AbrirCancionActual();
            Reproducir();
        }

        private void Reproducir()
        {
            if (!reproductorDisponible) { lblEstado.Text = "Estado: Reproductor no disponible"; return; }
            if (canciones.Count == 0) CargarCancionesDesdeCarpeta();
            if (canciones.Count == 0) { lblEstado.Text = "Estado: Sin canciones"; return; }
            if (indiceCancionActual < 0) indiceCancionActual = 0;
            if (!cancionAbierta) AbrirCancionActual();
            if (!cancionAbierta) return;

            reproductor.controls.play();
            reproduciendo = true;
            enPausa = false;
            timerReproduccion.Start();
            lblEstado.Text = "Estado: Reproduciendo";
            panelFooter.Invalidate();
        }

        private void DetenerReproduccion()
        {
            if (!cancionAbierta || !reproductorDisponible)
            {
                panelProgreso.Invalidate();
                lblEstado.Text = "Estado: Listo";
                return;
            }
            reproductor.controls.stop();
            reproductor.controls.currentPosition = 0;
            reproduciendo = false;
            enPausa = false;
            panelProgreso.Invalidate();
            lblEstado.Text = "Estado: Detenido";
            panelFooter.Invalidate();
        }

        private void CambiarCancion(int direccion)
        {
            if (canciones.Count == 0) CargarCancionesDesdeCarpeta();
            if (canciones.Count == 0) { lblEstado.Text = "Estado: Sin canciones"; return; }

            bool reproducirLuego = reproduciendo && !enPausa;
            indiceCancionActual += direccion;
            if (indiceCancionActual < 0)                     indiceCancionActual = canciones.Count - 1;
            else if (indiceCancionActual >= canciones.Count)  indiceCancionActual = 0;

            CerrarCancionActual();
            AbrirCancionActual();
            SeleccionarCancionEnLista();
            if (reproducirLuego) Reproducir();
        }

        private void AbrirCancionActual()
        {
            if (indiceCancionActual < 0 || indiceCancionActual >= canciones.Count) return;
            string archivo = canciones[indiceCancionActual];
            if (!File.Exists(archivo))       { lblEstado.Text = "Estado: Archivo no encontrado";    return; }
            if (!reproductorDisponible)      { lblEstado.Text = "Estado: Reproductor no disponible"; return; }

            try
            {
                reproductor.URL = archivo;
                AplicarVolumen();
                analizador.CargarArchivo(archivo);
                cancionAbierta   = true;
                duracionActualMs = ObtenerDuracionActualMs();
                lblCancionActual.Text = "Canción actual: " + Path.GetFileName(archivo);
                SeleccionarCancionEnLista();
                panelProgreso.Invalidate();
                panelSelectorVisual.Invalidate();
            }
            catch
            {
                cancionAbierta = false;
                lblEstado.Text = "Estado: No se pudo abrir el audio";
            }
        }

        private void CerrarCancionActual()
        {
            if (reproductorDisponible && reproductor != null)
                try { reproductor.controls.stop(); reproductor.URL = string.Empty; } catch { }
            analizador.Limpiar();
            cancionAbierta   = false;
            reproduciendo    = false;
            enPausa          = false;
            duracionActualMs = 0;
        }

        private void AplicarVolumen()
        {
            if (reproductorDisponible && reproductor != null) reproductor.settings.volume = volumenValor;
        }

        private void ActualizarVolumen() { lblVolumen.Text = "Volumen: " + volumenValor + "%"; }

        private void LiberarReproductor()
        {
            if (reproductorDisponible && reproductor != null) try { reproductor.close(); } catch { }
        }

        private void DetenerTimer() { timerReproduccion.Stop(); }

        // ── Timers ────────────────────────────────────────────────────────────────
        private void timerReproduccion_Tick(object sender, EventArgs e)
        {
            if (!cancionAbierta || !reproductorDisponible) return;
            duracionActualMs = ObtenerDuracionActualMs();
            panelProgreso.Invalidate();
            if (reproduciendo && !enPausa && EsFinDeCancion(ObtenerPosicionActualMs())) CambiarCancion(1);
        }

        private void timerAnimacion_Tick(object sender, EventArgs e)
        {
            faseAnimacion += reproduciendo && !enPausa ? 0.13f : 0.035f;

            float energia = ObtenerEnergiaVisual();
            int   posMs   = cancionAbierta ? ObtenerPosicionActualMs() : 0;

            energiaAnterior = energiaAnterior * 0.94f + energia * 0.06f;
            float mediaLocal     = Math.Max(0.05f, energiaAnterior);
            bool  beatTransiente = energia > mediaLocal * 1.40f && energia > 0.18f;
            if (beatTransiente)
            {
                if (p_beatCooldown > 0) beatTransiente = false;
                else p_beatCooldown = 4;
            }
            if (p_beatCooldown > 0) p_beatCooldown--;

            contexto.Ancho           = panelVisualizador.Width;
            contexto.Alto            = panelVisualizador.Height;
            contexto.FaseAnimacion   = faseAnimacion;
            contexto.Energia         = energia;
            contexto.PosicionMs      = posMs;
            contexto.EnergiaAnterior = energiaAnterior;
            contexto.BeatTransiente  = beatTransiente;

            if (visualizadorActual != null) visualizadorActual.Actualizar();
            panelVisualizador.Invalidate();
        }

        // ── Modo de visualización ─────────────────────────────────────────────────
        private void ActualizarModoVisual(int modo)
        {
            modoVisualActual = modo;
            Button[] btnsModo = { btnModoBarras, btnModoOnda, btnModoParticulas, btnModoFiguras, btnModoCircular };
            contextoUI.ModoActivo = btnsModo[Math.Max(0, Math.Min(4, modo))];
            foreach (Button b in btnsModo) b.Invalidate();

            contexto.Ancho = panelVisualizador.Width;
            contexto.Alto  = panelVisualizador.Height;

            switch (modo)
            {
                case 1:  visualizadorActual = new VisualizadorOnda(contexto);        break;
                case 2:  visualizadorActual = new VisualizadorParticulas(contexto);  break;
                case 3:  visualizadorActual = new VisualizadorFiguras(contexto);     break;
                case 4:  visualizadorActual = new VisualizadorCircular(contexto);    break;
                default: visualizadorActual = new VisualizadorBarras(contexto);      break;
            }
            visualizadorActual.Inicializar();
        }

        // ── Helpers de reproducción ───────────────────────────────────────────────
        private float ObtenerEnergiaVisual()
        {
            float volumen = volumenValor / 100f;
            if (reproduciendo && !enPausa)
            {
                int   posMs      = ObtenerPosicionActualMs();
                float energiaReal = analizador.ObtenerEnergia(posMs);
                if (energiaReal >= 0f) return Limitar01(energiaReal * (0.35f + volumen * 0.65f));
            }
            if (!reproduciendo || enPausa) return 0.18f + volumen * 0.12f;
            int    posicion  = ObtenerPosicionActualMs();
            double tiempo    = posicion / 1000.0;
            double pulso     = Math.Abs(Math.Sin(tiempo * 2.8));
            double subPulso  = Math.Abs(Math.Sin(tiempo * 0.9 + Math.Sin(tiempo * 0.35)));
            return Limitar01((float)((0.28 + pulso * 0.48 + subPulso * 0.24) * volumen));
        }

        private int ObtenerPosicionActualMs()
        {
            try   { return (int)(reproductor.controls.currentPosition * 1000); }
            catch { return 0; }
        }

        private int ObtenerDuracionActualMs()
        {
            try   { return (int)(reproductor.currentMedia.duration * 1000); }
            catch { return duracionActualMs; }
        }

        private bool EsFinDeCancion(int posicionMs)
        {
            try { if (reproductor.playState == 8) return true; } catch { return false; }
            return duracionActualMs > 0 && posicionMs >= duracionActualMs - 400;
        }

        private static float Limitar01(float v) { return v < 0f ? 0f : v > 1f ? 1f : v; }

        // ── Handlers de Paint — cada uno sincroniza el estado y delega ────────────
        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {
            graficoHeader.Dibujar(e.Graphics, panelHeader.Width, panelHeader.Height);
        }

        private void panelFooter_Paint(object sender, PaintEventArgs e)
        {
            contextoUI.Reproduciendo = reproduciendo;
            contextoUI.EnPausa       = enPausa;
            graficoFooter.Dibujar(e.Graphics, panelFooter.Width, panelFooter.Height);
        }

        private void panelProgreso_Paint(object sender, PaintEventArgs e)
        {
            contextoUI.PosicionMs       = cancionAbierta ? ObtenerPosicionActualMs() : 0;
            contextoUI.DuracionActualMs = duracionActualMs;
            graficoProgreso.Dibujar(e.Graphics, panelProgreso.Width, panelProgreso.Height);
        }

        private void panelVolumen_Paint(object sender, PaintEventArgs e)
        {
            contextoUI.VolumenValor = volumenValor;
            graficoVolumen.Dibujar(e.Graphics, panelVolumen.Width, panelVolumen.Height);
        }

        private void panelListaCanciones_Paint(object sender, PaintEventArgs e)
        {
            graficoLista.DibujarPanel(e.Graphics, panelListaCanciones.Width, panelListaCanciones.Height);
        }

        private void lstCancionesUnificada_DrawItem(object sender, DrawItemEventArgs e)
        {
            contextoUI.IndiceCancionActual = indiceCancionActual;
            graficoLista.DibujarItem(e);
        }

        private void panelMarcoVisualizador_Paint(object sender, PaintEventArgs e)
        {
            graficoMarco.Dibujar(e.Graphics, panelMarcoVisualizador.Width, panelMarcoVisualizador.Height);
        }

        private void panelSelectorVisual_Paint(object sender, PaintEventArgs e)
        {
            contextoUI.IndiceCancionActual = indiceCancionActual;
            graficoSelectorVisual.Dibujar(e.Graphics, panelSelectorVisual.Width, panelSelectorVisual.Height);
        }

        // ── Visualizador ──────────────────────────────────────────────────────────
        private void panelVisualizador_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.None;
            e.Graphics.Clear(Color.FromArgb(22, 14, 8));
            DibujarCuadriculaRetro(e.Graphics);
            if (visualizadorActual != null) visualizadorActual.Dibujar(e.Graphics);
        }

        private void panelVisualizador_Resize(object sender, EventArgs e)
        {
            contexto.Ancho = panelVisualizador.Width;
            contexto.Alto  = panelVisualizador.Height;
            if (visualizadorActual != null) visualizadorActual.AlRedimensionar();
            panelVisualizador.Invalidate();
        }

        private void DibujarCuadriculaRetro(Graphics g)
        {
            int w = panelVisualizador.Width;
            int h = panelVisualizador.Height;
            for (int borde = 0; borde < 18; borde++)
            {
                int alfa = (int)((1.0 - borde / 18.0) * 60);
                using (Pen vig = new Pen(Color.FromArgb(alfa, 0, 0, 0), 1))
                    g.DrawRectangle(vig, borde, borde, w - borde * 2 - 1, h - borde * 2 - 1);
            }
            using (Pen lineaGrilla = new Pen(Color.FromArgb(22, 140, 80, 20), 1))
                for (int y = 14; y < h - 6; y += 20)
                    g.DrawLine(lineaGrilla, 8, y, w - 8, y);
            using (SolidBrush perforacion = new SolidBrush(Color.FromArgb(35, 80, 45, 8)))
                for (int y = 14; y < h - 6; y += 20)
                    for (int x = 22; x < w - 6; x += 30)
                        g.FillEllipse(perforacion, x - 4, y + 7, 7, 7);
        }

        // ── Volumen (slider personalizado) ────────────────────────────────────────
        private void panelVolumen_Mouse(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            int margin = 8, trackLen = panelVolumen.Width - margin * 2;
            float pos = (e.X - margin) / (float)trackLen;
            volumenValor = Math.Max(0, Math.Min(100, (int)(pos * 100 + 0.5f)));
            ActualizarVolumen();
            AplicarVolumen();
            panelVolumen.Invalidate();
        }

        // ── Progreso: clic para saltar a posición ─────────────────────────────────
        private void panelProgreso_MouseDown(object sender, MouseEventArgs e)
        {
            if (!cancionAbierta || !reproductorDisponible || duracionActualMs <= 0) return;
            const int labelW = 80;
            int barX = labelW + 10, barW = panelProgreso.Width - labelW * 2 - 20;
            if (e.X < barX || e.X > barX + barW) return;
            float pos = (e.X - barX) / (float)barW;
            try { reproductor.controls.currentPosition = pos * (duracionActualMs / 1000.0); } catch { }
            panelProgreso.Invalidate();
        }
    }
}

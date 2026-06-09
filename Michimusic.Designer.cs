namespace ReproductorMusical
{
    partial class Michimusic
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Codigo generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelSelectorVisual = new System.Windows.Forms.Panel();
            this.lblModoVisual = new System.Windows.Forms.Label();
            this.cmbModoVisual = new System.Windows.Forms.ComboBox();
            this.panelListaCanciones = new System.Windows.Forms.Panel();
            this.lstCanciones = new System.Windows.Forms.ListBox();
            this.lblListaCanciones = new System.Windows.Forms.Label();
            this.lstCancionesMp3 = new System.Windows.Forms.ListBox();
            this.lblListaMp3 = new System.Windows.Forms.Label();
            this.panelMarcoVisualizador = new System.Windows.Forms.Panel();
            this.panelVisualizador = new System.Windows.Forms.Panel();
            this.panelControles = new System.Windows.Forms.Panel();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.lblVolumen = new System.Windows.Forms.Label();
            this.trackVolumen = new System.Windows.Forms.TrackBar();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnCargar = new System.Windows.Forms.Button();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblCancionActual = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panelSelectorVisual.SuspendLayout();
            this.panelListaCanciones.SuspendLayout();
            this.panelMarcoVisualizador.SuspendLayout();
            this.panelControles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackVolumen)).BeginInit();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(38)))), ((int)(((byte)(28)))));
            this.panelHeader.Controls.Add(this.picLogo);
            this.panelHeader.Controls.Add(this.lblSubtitulo);
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(37, 20, 37, 20);
            this.panelHeader.Size = new System.Drawing.Size(1467, 143);
            this.panelHeader.TabIndex = 0;
            // 
            // picLogo
            // 
            this.picLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(189)))));
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLogo.Location = new System.Drawing.Point(1332, 27);
            this.picLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(95, 88);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 2;
            this.picLogo.TabStop = false;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(43, 89);
            this.lblSubtitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(600, 26);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Reproductor musical con animaciones sincronizadas";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Consolas", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(189)))));
            this.lblTitulo.Location = new System.Drawing.Point(37, 22);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(295, 59);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Michimusic";
            // 
            // panelSelectorVisual
            // 
            this.panelSelectorVisual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(189)))));
            this.panelSelectorVisual.Controls.Add(this.lblModoVisual);
            this.panelSelectorVisual.Controls.Add(this.cmbModoVisual);
            this.panelSelectorVisual.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSelectorVisual.Location = new System.Drawing.Point(0, 143);
            this.panelSelectorVisual.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelSelectorVisual.Name = "panelSelectorVisual";
            this.panelSelectorVisual.Padding = new System.Windows.Forms.Padding(37, 15, 37, 10);
            this.panelSelectorVisual.Size = new System.Drawing.Size(1467, 71);
            this.panelSelectorVisual.TabIndex = 1;
            // 
            // lblModoVisual
            // 
            this.lblModoVisual.AutoSize = true;
            this.lblModoVisual.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModoVisual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(37)))));
            this.lblModoVisual.Location = new System.Drawing.Point(40, 22);
            this.lblModoVisual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblModoVisual.Name = "lblModoVisual";
            this.lblModoVisual.Size = new System.Drawing.Size(120, 22);
            this.lblModoVisual.TabIndex = 0;
            this.lblModoVisual.Text = "Modo visual";
            // 
            // cmbModoVisual
            // 
            this.cmbModoVisual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(204)))));
            this.cmbModoVisual.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModoVisual.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbModoVisual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(37)))));
            this.cmbModoVisual.FormattingEnabled = true;
            this.cmbModoVisual.Items.AddRange(new object[] {
            "Barras de espectro",
            "Onda musical",
            "Partículas",
            "Figuras geométricas",
            "Espectro circular"});
            this.cmbModoVisual.Location = new System.Drawing.Point(205, 18);
            this.cmbModoVisual.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbModoVisual.Name = "cmbModoVisual";
            this.cmbModoVisual.Size = new System.Drawing.Size(325, 30);
            this.cmbModoVisual.TabIndex = 1;
            // 
            // panelListaCanciones
            // 
            this.panelListaCanciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelListaCanciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(37)))));
            this.panelListaCanciones.Controls.Add(this.lstCancionesMp3);
            this.panelListaCanciones.Controls.Add(this.lblListaMp3);
            this.panelListaCanciones.Controls.Add(this.lstCanciones);
            this.panelListaCanciones.Controls.Add(this.lblListaCanciones);
            this.panelListaCanciones.Location = new System.Drawing.Point(37, 214);
            this.panelListaCanciones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelListaCanciones.Name = "panelListaCanciones";
            this.panelListaCanciones.Padding = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.panelListaCanciones.Size = new System.Drawing.Size(293, 517);
            this.panelListaCanciones.TabIndex = 2;
            // 
            // lstCanciones
            // 
            this.lstCanciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCanciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(204)))));
            this.lstCanciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstCanciones.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCanciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(37)))));
            this.lstCanciones.FormattingEnabled = true;
            this.lstCanciones.HorizontalScrollbar = true;
            this.lstCanciones.ItemHeight = 19;
            this.lstCanciones.Location = new System.Drawing.Point(16, 47);
            this.lstCanciones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstCanciones.Name = "lstCanciones";
            this.lstCanciones.Size = new System.Drawing.Size(261, 173);
            this.lstCanciones.TabIndex = 1;
            // 
            // lblListaCanciones
            // 
            this.lblListaCanciones.AutoSize = true;
            this.lblListaCanciones.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaCanciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(189)))));
            this.lblListaCanciones.Location = new System.Drawing.Point(16, 18);
            this.lblListaCanciones.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblListaCanciones.Name = "lblListaCanciones";
            this.lblListaCanciones.Size = new System.Drawing.Size(180, 22);
            this.lblListaCanciones.TabIndex = 0;
            this.lblListaCanciones.Text = "WAV - análisis real";
            // 
            // lstCancionesMp3
            // 
            this.lstCancionesMp3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCancionesMp3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(204)))));
            this.lstCancionesMp3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstCancionesMp3.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCancionesMp3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(37)))));
            this.lstCancionesMp3.FormattingEnabled = true;
            this.lstCancionesMp3.HorizontalScrollbar = true;
            this.lstCancionesMp3.ItemHeight = 19;
            this.lstCancionesMp3.Location = new System.Drawing.Point(16, 281);
            this.lstCancionesMp3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstCancionesMp3.Name = "lstCancionesMp3";
            this.lstCancionesMp3.Size = new System.Drawing.Size(261, 173);
            this.lstCancionesMp3.TabIndex = 3;
            // 
            // lblListaMp3
            // 
            this.lblListaMp3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblListaMp3.AutoSize = true;
            this.lblListaMp3.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaMp3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(189)))));
            this.lblListaMp3.Location = new System.Drawing.Point(16, 241);
            this.lblListaMp3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblListaMp3.Name = "lblListaMp3";
            this.lblListaMp3.Size = new System.Drawing.Size(160, 22);
            this.lblListaMp3.TabIndex = 2;
            this.lblListaMp3.Text = "MP3 - simulación";
            // 
            // panelMarcoVisualizador
            // 
            this.panelMarcoVisualizador.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMarcoVisualizador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(37)))));
            this.panelMarcoVisualizador.Controls.Add(this.panelVisualizador);
            this.panelMarcoVisualizador.Location = new System.Drawing.Point(357, 214);
            this.panelMarcoVisualizador.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelMarcoVisualizador.Name = "panelMarcoVisualizador";
            this.panelMarcoVisualizador.Padding = new System.Windows.Forms.Padding(48, 44, 48, 44);
            this.panelMarcoVisualizador.Size = new System.Drawing.Size(1072, 517);
            this.panelMarcoVisualizador.TabIndex = 3;
            this.panelMarcoVisualizador.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMarcoVisualizador_Paint);
            // 
            // panelVisualizador
            // 
            this.panelVisualizador.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelVisualizador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(82)))), ((int)(((byte)(98)))));
            this.panelVisualizador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelVisualizador.Location = new System.Drawing.Point(75, 59);
            this.panelVisualizador.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelVisualizador.Name = "panelVisualizador";
            this.panelVisualizador.Size = new System.Drawing.Size(922, 398);
            this.panelVisualizador.TabIndex = 0;
            // 
            // panelControles
            // 
            this.panelControles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(189)))));
            this.panelControles.Controls.Add(this.lblTiempo);
            this.panelControles.Controls.Add(this.lblVolumen);
            this.panelControles.Controls.Add(this.trackVolumen);
            this.panelControles.Controls.Add(this.btnSiguiente);
            this.panelControles.Controls.Add(this.btnStop);
            this.panelControles.Controls.Add(this.btnPause);
            this.panelControles.Controls.Add(this.btnPlay);
            this.panelControles.Controls.Add(this.btnAnterior);
            this.panelControles.Controls.Add(this.btnCargar);
            this.panelControles.Location = new System.Drawing.Point(0, 731);
            this.panelControles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelControles.Name = "panelControles";
            this.panelControles.Padding = new System.Windows.Forms.Padding(37, 10, 37, 10);
            this.panelControles.Size = new System.Drawing.Size(1467, 69);
            this.panelControles.TabIndex = 4;
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(37)))));
            this.lblTiempo.Location = new System.Drawing.Point(1012, 22);
            this.lblTiempo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(181, 28);
            this.lblTiempo.TabIndex = 8;
            this.lblTiempo.Text = "00:00 / 00:00";
            // 
            // lblVolumen
            // 
            this.lblVolumen.AutoSize = true;
            this.lblVolumen.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVolumen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(37)))));
            this.lblVolumen.Location = new System.Drawing.Point(675, 25);
            this.lblVolumen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVolumen.Name = "lblVolumen";
            this.lblVolumen.Size = new System.Drawing.Size(117, 20);
            this.lblVolumen.TabIndex = 6;
            this.lblVolumen.Text = "Volumen: 50%";
            // 
            // trackVolumen
            // 
            this.trackVolumen.Location = new System.Drawing.Point(823, 16);
            this.trackVolumen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackVolumen.Maximum = 100;
            this.trackVolumen.Name = "trackVolumen";
            this.trackVolumen.Size = new System.Drawing.Size(181, 56);
            this.trackVolumen.TabIndex = 7;
            this.trackVolumen.TickFrequency = 10;
            this.trackVolumen.Value = 50;
            this.trackVolumen.ValueChanged += new System.EventHandler(this.trackVolumen_ValueChanged);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(108)))), ((int)(((byte)(128)))));
            this.btnSiguiente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(37)))));
            this.btnSiguiente.FlatAppearance.BorderSize = 3;
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiguiente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(189)))));
            this.btnSiguiente.Location = new System.Drawing.Point(524, 10);
            this.btnSiguiente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(64, 49);
            this.btnSiguiente.TabIndex = 5;
            this.btnSiguiente.Text = ">>";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(80)))), ((int)(((byte)(69)))));
            this.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(37)))));
            this.btnStop.FlatAppearance.BorderSize = 3;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(189)))));
            this.btnStop.Location = new System.Drawing.Point(452, 10);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(64, 49);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "■";
            this.btnStop.UseVisualStyleBackColor = false;
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(162)))), ((int)(((byte)(4)))));
            this.btnPause.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(37)))));
            this.btnPause.FlatAppearance.BorderSize = 3;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(37)))));
            this.btnPause.Location = new System.Drawing.Point(380, 10);
            this.btnPause.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(64, 49);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "Ⅱ";
            this.btnPause.UseVisualStyleBackColor = false;
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(135)))), ((int)(((byte)(97)))));
            this.btnPlay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(37)))));
            this.btnPlay.FlatAppearance.BorderSize = 3;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(189)))));
            this.btnPlay.Location = new System.Drawing.Point(308, 10);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(64, 49);
            this.btnPlay.TabIndex = 2;
            this.btnPlay.Text = "▶";
            this.btnPlay.UseVisualStyleBackColor = false;
            // 
            // btnAnterior
            // 
            this.btnAnterior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(108)))), ((int)(((byte)(128)))));
            this.btnAnterior.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(37)))));
            this.btnAnterior.FlatAppearance.BorderSize = 3;
            this.btnAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnterior.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnterior.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(189)))));
            this.btnAnterior.Location = new System.Drawing.Point(236, 10);
            this.btnAnterior.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(64, 49);
            this.btnAnterior.TabIndex = 1;
            this.btnAnterior.Text = "<<";
            this.btnAnterior.UseVisualStyleBackColor = false;
            // 
            // btnCargar
            // 
            this.btnCargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(160)))), ((int)(((byte)(93)))));
            this.btnCargar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(37)))));
            this.btnCargar.FlatAppearance.BorderSize = 3;
            this.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargar.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(37)))));
            this.btnCargar.Location = new System.Drawing.Point(37, 10);
            this.btnCargar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(171, 49);
            this.btnCargar.TabIndex = 0;
            this.btnCargar.Text = "LOAD";
            this.btnCargar.UseVisualStyleBackColor = false;
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(37)))));
            this.panelFooter.Controls.Add(this.lblEstado);
            this.panelFooter.Controls.Add(this.lblCancionActual);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 800);
            this.panelFooter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Padding = new System.Windows.Forms.Padding(37, 0, 37, 0);
            this.panelFooter.Size = new System.Drawing.Size(1467, 62);
            this.panelFooter.TabIndex = 5;
            // 
            // lblEstado
            // 
            this.lblEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEstado.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(189)))));
            this.lblEstado.Location = new System.Drawing.Point(1125, 18);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(304, 22);
            this.lblEstado.TabIndex = 1;
            this.lblEstado.Text = "Estado: Listo";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCancionActual
            // 
            this.lblCancionActual.AutoSize = true;
            this.lblCancionActual.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancionActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(189)))));
            this.lblCancionActual.Location = new System.Drawing.Point(37, 18);
            this.lblCancionActual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCancionActual.Name = "lblCancionActual";
            this.lblCancionActual.Size = new System.Drawing.Size(400, 22);
            this.lblCancionActual.TabIndex = 0;
            this.lblCancionActual.Text = "Canción actual: Ninguna canción cargada";
            // 
            // Michimusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(189)))));
            this.ClientSize = new System.Drawing.Size(1467, 862);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelControles);
            this.Controls.Add(this.panelMarcoVisualizador);
            this.Controls.Add(this.panelListaCanciones);
            this.Controls.Add(this.panelSelectorVisual);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Michimusic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Michimusic - Reproductor Musical";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panelSelectorVisual.ResumeLayout(false);
            this.panelSelectorVisual.PerformLayout();
            this.panelListaCanciones.ResumeLayout(false);
            this.panelListaCanciones.PerformLayout();
            this.panelMarcoVisualizador.ResumeLayout(false);
            this.panelControles.ResumeLayout(false);
            this.panelControles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackVolumen)).EndInit();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel panelSelectorVisual;
        private System.Windows.Forms.Label lblModoVisual;
        private System.Windows.Forms.ComboBox cmbModoVisual;
        private System.Windows.Forms.Panel panelListaCanciones;
        private System.Windows.Forms.Label lblListaCanciones;
        private System.Windows.Forms.ListBox lstCanciones;
        private System.Windows.Forms.Label lblListaMp3;
        private System.Windows.Forms.ListBox lstCancionesMp3;
        private System.Windows.Forms.Panel panelMarcoVisualizador;
        private System.Windows.Forms.Panel panelVisualizador;
        private System.Windows.Forms.Panel panelControles;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.TrackBar trackVolumen;
        private System.Windows.Forms.Label lblVolumen;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblCancionActual;
        private System.Windows.Forms.Label lblEstado;
    }
}

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
            this.btnModoCircular = new System.Windows.Forms.Button();
            this.btnModoFiguras = new System.Windows.Forms.Button();
            this.btnModoParticulas = new System.Windows.Forms.Button();
            this.btnModoOnda = new System.Windows.Forms.Button();
            this.btnModoBarras = new System.Windows.Forms.Button();
            this.panelListaCanciones = new System.Windows.Forms.Panel();
            this.lstCancionesUnificada = new System.Windows.Forms.ListBox();
            this.lblPlaylist = new System.Windows.Forms.Label();
            this.panelMarcoVisualizador = new System.Windows.Forms.Panel();
            this.panelVisualizador = new System.Windows.Forms.Panel();
            this.panelProgreso = new System.Windows.Forms.Panel();
            this.panelControles = new System.Windows.Forms.Panel();
            this.lblVolumen = new System.Windows.Forms.Label();
            this.panelVolumen = new System.Windows.Forms.Panel();
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
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(36)))), ((int)(((byte)(18)))));
            this.panelHeader.Controls.Add(this.picLogo);
            this.panelHeader.Controls.Add(this.lblSubtitulo);
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(28, 16, 28, 16);
            this.panelHeader.Size = new System.Drawing.Size(1100, 116);
            this.panelHeader.TabIndex = 0;
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
            // 
            // picLogo
            // 
            this.picLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(36)))), ((int)(((byte)(18)))));
            this.picLogo.Location = new System.Drawing.Point(999, 22);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(71, 72);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 2;
            this.picLogo.TabStop = false;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(172)))), ((int)(((byte)(108)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(32, 67);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(400, 17);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Reproductor musical con animaciones sincronizadas";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Consolas", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(162)))), ((int)(((byte)(4)))));
            this.lblTitulo.Location = new System.Drawing.Point(28, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(240, 47);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Michimusic";
            // 
            // panelSelectorVisual
            // 
            this.panelSelectorVisual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.panelSelectorVisual.Controls.Add(this.btnModoCircular);
            this.panelSelectorVisual.Controls.Add(this.btnModoFiguras);
            this.panelSelectorVisual.Controls.Add(this.btnModoParticulas);
            this.panelSelectorVisual.Controls.Add(this.btnModoOnda);
            this.panelSelectorVisual.Controls.Add(this.btnModoBarras);
            this.panelSelectorVisual.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSelectorVisual.Location = new System.Drawing.Point(0, 116);
            this.panelSelectorVisual.Name = "panelSelectorVisual";
            this.panelSelectorVisual.Padding = new System.Windows.Forms.Padding(28, 10, 28, 8);
            this.panelSelectorVisual.Size = new System.Drawing.Size(1100, 58);
            this.panelSelectorVisual.TabIndex = 1;
            this.panelSelectorVisual.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSelectorVisual_Paint);
            // 
            // btnModoCircular
            // 
            this.btnModoCircular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnModoCircular.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnModoCircular.FlatAppearance.BorderSize = 0;
            this.btnModoCircular.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnModoCircular.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnModoCircular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModoCircular.Font = new System.Drawing.Font("Consolas", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModoCircular.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnModoCircular.Location = new System.Drawing.Point(322, 10);
            this.btnModoCircular.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnModoCircular.Name = "btnModoCircular";
            this.btnModoCircular.Size = new System.Drawing.Size(68, 38);
            this.btnModoCircular.TabIndex = 4;
            this.btnModoCircular.Text = "";
            this.btnModoCircular.UseVisualStyleBackColor = false;
            // 
            // btnModoFiguras
            // 
            this.btnModoFiguras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnModoFiguras.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnModoFiguras.FlatAppearance.BorderSize = 0;
            this.btnModoFiguras.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnModoFiguras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnModoFiguras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModoFiguras.Font = new System.Drawing.Font("Consolas", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModoFiguras.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnModoFiguras.Location = new System.Drawing.Point(248, 10);
            this.btnModoFiguras.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnModoFiguras.Name = "btnModoFiguras";
            this.btnModoFiguras.Size = new System.Drawing.Size(68, 38);
            this.btnModoFiguras.TabIndex = 3;
            this.btnModoFiguras.Text = "";
            this.btnModoFiguras.UseVisualStyleBackColor = false;
            // 
            // btnModoParticulas
            // 
            this.btnModoParticulas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnModoParticulas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnModoParticulas.FlatAppearance.BorderSize = 0;
            this.btnModoParticulas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnModoParticulas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnModoParticulas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModoParticulas.Font = new System.Drawing.Font("Consolas", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModoParticulas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnModoParticulas.Location = new System.Drawing.Point(175, 10);
            this.btnModoParticulas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnModoParticulas.Name = "btnModoParticulas";
            this.btnModoParticulas.Size = new System.Drawing.Size(68, 38);
            this.btnModoParticulas.TabIndex = 2;
            this.btnModoParticulas.Text = "";
            this.btnModoParticulas.UseVisualStyleBackColor = false;
            // 
            // btnModoOnda
            // 
            this.btnModoOnda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnModoOnda.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnModoOnda.FlatAppearance.BorderSize = 0;
            this.btnModoOnda.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnModoOnda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnModoOnda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModoOnda.Font = new System.Drawing.Font("Consolas", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModoOnda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnModoOnda.Location = new System.Drawing.Point(101, 10);
            this.btnModoOnda.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnModoOnda.Name = "btnModoOnda";
            this.btnModoOnda.Size = new System.Drawing.Size(68, 38);
            this.btnModoOnda.TabIndex = 1;
            this.btnModoOnda.Text = "";
            this.btnModoOnda.UseVisualStyleBackColor = false;
            // 
            // btnModoBarras
            // 
            this.btnModoBarras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnModoBarras.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnModoBarras.FlatAppearance.BorderSize = 0;
            this.btnModoBarras.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnModoBarras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnModoBarras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModoBarras.Font = new System.Drawing.Font("Consolas", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModoBarras.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnModoBarras.Location = new System.Drawing.Point(28, 10);
            this.btnModoBarras.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnModoBarras.Name = "btnModoBarras";
            this.btnModoBarras.Size = new System.Drawing.Size(68, 38);
            this.btnModoBarras.TabIndex = 0;
            this.btnModoBarras.Text = "";
            this.btnModoBarras.UseVisualStyleBackColor = false;
            // 
            // panelListaCanciones
            // 
            this.panelListaCanciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelListaCanciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.panelListaCanciones.Controls.Add(this.lstCancionesUnificada);
            this.panelListaCanciones.Controls.Add(this.lblPlaylist);
            this.panelListaCanciones.Location = new System.Drawing.Point(28, 174);
            this.panelListaCanciones.Name = "panelListaCanciones";
            this.panelListaCanciones.Padding = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.panelListaCanciones.Size = new System.Drawing.Size(220, 420);
            this.panelListaCanciones.TabIndex = 2;
            this.panelListaCanciones.Paint += new System.Windows.Forms.PaintEventHandler(this.panelListaCanciones_Paint);
            // 
            // lstCancionesUnificada
            // 
            this.lstCancionesUnificada.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCancionesUnificada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(20)))), ((int)(((byte)(26)))));
            this.lstCancionesUnificada.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstCancionesUnificada.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstCancionesUnificada.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCancionesUnificada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(189)))));
            this.lstCancionesUnificada.FormattingEnabled = true;
            this.lstCancionesUnificada.HorizontalScrollbar = true;
            this.lstCancionesUnificada.ItemHeight = 24;
            this.lstCancionesUnificada.Location = new System.Drawing.Point(12, 38);
            this.lstCancionesUnificada.Name = "lstCancionesUnificada";
            this.lstCancionesUnificada.Size = new System.Drawing.Size(196, 360);
            this.lstCancionesUnificada.TabIndex = 1;
            this.lstCancionesUnificada.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstCancionesUnificada_DrawItem);
            // 
            // lblPlaylist
            // 
            this.lblPlaylist.AutoSize = true;
            this.lblPlaylist.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaylist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(162)))), ((int)(((byte)(4)))));
            this.lblPlaylist.Location = new System.Drawing.Point(12, 15);
            this.lblPlaylist.Name = "lblPlaylist";
            this.lblPlaylist.Size = new System.Drawing.Size(104, 18);
            this.lblPlaylist.TabIndex = 0;
            this.lblPlaylist.Text = "◄ PLAYLIST ►";
            // 
            // panelMarcoVisualizador
            // 
            this.panelMarcoVisualizador.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMarcoVisualizador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(37)))));
            this.panelMarcoVisualizador.Controls.Add(this.panelVisualizador);
            this.panelMarcoVisualizador.Location = new System.Drawing.Point(268, 174);
            this.panelMarcoVisualizador.Name = "panelMarcoVisualizador";
            this.panelMarcoVisualizador.Padding = new System.Windows.Forms.Padding(36, 36, 36, 36);
            this.panelMarcoVisualizador.Size = new System.Drawing.Size(804, 420);
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
            this.panelVisualizador.Location = new System.Drawing.Point(56, 48);
            this.panelVisualizador.Name = "panelVisualizador";
            this.panelVisualizador.Size = new System.Drawing.Size(692, 324);
            this.panelVisualizador.TabIndex = 0;
            // 
            // panelProgreso
            // 
            this.panelProgreso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelProgreso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.panelProgreso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelProgreso.Location = new System.Drawing.Point(0, 594);
            this.panelProgreso.Name = "panelProgreso";
            this.panelProgreso.Size = new System.Drawing.Size(1100, 32);
            this.panelProgreso.TabIndex = 6;
            this.panelProgreso.Paint += new System.Windows.Forms.PaintEventHandler(this.panelProgreso_Paint);
            this.panelProgreso.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelProgreso_MouseDown);
            // 
            // panelControles
            // 
            this.panelControles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.panelControles.Controls.Add(this.lblVolumen);
            this.panelControles.Controls.Add(this.panelVolumen);
            this.panelControles.Controls.Add(this.btnSiguiente);
            this.panelControles.Controls.Add(this.btnStop);
            this.panelControles.Controls.Add(this.btnPause);
            this.panelControles.Controls.Add(this.btnPlay);
            this.panelControles.Controls.Add(this.btnAnterior);
            this.panelControles.Controls.Add(this.btnCargar);
            this.panelControles.Location = new System.Drawing.Point(0, 626);
            this.panelControles.Name = "panelControles";
            this.panelControles.Padding = new System.Windows.Forms.Padding(28, 8, 28, 8);
            this.panelControles.Size = new System.Drawing.Size(1100, 56);
            this.panelControles.TabIndex = 4;
            // 
            // lblVolumen
            // 
            this.lblVolumen.AutoSize = true;
            this.lblVolumen.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVolumen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(189)))));
            this.lblVolumen.Location = new System.Drawing.Point(732, 19);
            this.lblVolumen.Name = "lblVolumen";
            this.lblVolumen.Size = new System.Drawing.Size(130, 17);
            this.lblVolumen.TabIndex = 6;
            this.lblVolumen.Text = "Volumen: 50%";
            //
            // panelVolumen
            //
            this.panelVolumen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.panelVolumen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelVolumen.Location = new System.Drawing.Point(868, 14);
            this.panelVolumen.Name = "panelVolumen";
            this.panelVolumen.Size = new System.Drawing.Size(204, 28);
            this.panelVolumen.TabIndex = 7;
            this.panelVolumen.Paint += new System.Windows.Forms.PaintEventHandler(this.panelVolumen_Paint);
            this.panelVolumen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelVolumen_Mouse);
            this.panelVolumen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelVolumen_Mouse);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnSiguiente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSiguiente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnSiguiente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiguiente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnSiguiente.Location = new System.Drawing.Point(643, 4);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(54, 48);
            this.btnSiguiente.TabIndex = 5;
            this.btnSiguiente.Text = "";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            //
            // btnStop
            //
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnStop.Location = new System.Drawing.Point(583, 4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(54, 48);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "";
            this.btnStop.UseVisualStyleBackColor = false;
            //
            // btnPause
            //
            this.btnPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnPause.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnPause.FlatAppearance.BorderSize = 0;
            this.btnPause.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnPause.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnPause.Location = new System.Drawing.Point(523, 4);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(54, 48);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "";
            this.btnPause.UseVisualStyleBackColor = false;
            //
            // btnPlay
            //
            this.btnPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnPlay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnPlay.Location = new System.Drawing.Point(463, 4);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(54, 48);
            this.btnPlay.TabIndex = 2;
            this.btnPlay.Text = "";
            this.btnPlay.UseVisualStyleBackColor = false;
            //
            // btnAnterior
            //
            this.btnAnterior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnAnterior.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnAnterior.FlatAppearance.BorderSize = 0;
            this.btnAnterior.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnAnterior.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnterior.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnterior.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnAnterior.Location = new System.Drawing.Point(403, 4);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(54, 48);
            this.btnAnterior.TabIndex = 1;
            this.btnAnterior.Text = "";
            this.btnAnterior.UseVisualStyleBackColor = false;
            //
            // btnCargar
            //
            this.btnCargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnCargar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnCargar.FlatAppearance.BorderSize = 0;
            this.btnCargar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnCargar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargar.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.btnCargar.Location = new System.Drawing.Point(28, 4);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(130, 48);
            this.btnCargar.TabIndex = 0;
            this.btnCargar.Text = "";
            this.btnCargar.UseVisualStyleBackColor = false;
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.panelFooter.Controls.Add(this.lblEstado);
            this.panelFooter.Controls.Add(this.lblCancionActual);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 683);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Padding = new System.Windows.Forms.Padding(28, 0, 28, 0);
            this.panelFooter.Size = new System.Drawing.Size(1100, 50);
            this.panelFooter.TabIndex = 5;
            this.panelFooter.Paint += new System.Windows.Forms.PaintEventHandler(this.panelFooter_Paint);
            // 
            // lblEstado
            // 
            this.lblEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEstado.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(145)))), ((int)(((byte)(90)))));
            this.lblEstado.Location = new System.Drawing.Point(844, 15);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(228, 18);
            this.lblEstado.TabIndex = 1;
            this.lblEstado.Text = "Estado: Listo";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCancionActual
            // 
            this.lblCancionActual.AutoSize = true;
            this.lblCancionActual.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancionActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(189)))));
            this.lblCancionActual.Location = new System.Drawing.Point(42, 15);
            this.lblCancionActual.Name = "lblCancionActual";
            this.lblCancionActual.Size = new System.Drawing.Size(320, 18);
            this.lblCancionActual.TabIndex = 0;
            this.lblCancionActual.Text = "Canción actual: Ninguna canción cargada";
            // 
            // Michimusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(14)))), ((int)(((byte)(8)))));
            this.ClientSize = new System.Drawing.Size(1100, 733);
            this.Controls.Add(this.panelProgreso);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelControles);
            this.Controls.Add(this.panelMarcoVisualizador);
            this.Controls.Add(this.panelListaCanciones);
            this.Controls.Add(this.panelSelectorVisual);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Michimusic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Michimusic - Reproductor Musical";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panelSelectorVisual.ResumeLayout(false);
            this.panelListaCanciones.ResumeLayout(false);
            this.panelListaCanciones.PerformLayout();
            this.panelMarcoVisualizador.ResumeLayout(false);
            this.panelControles.ResumeLayout(false);
            this.panelControles.PerformLayout();
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
        private System.Windows.Forms.Button btnModoBarras;
        private System.Windows.Forms.Button btnModoOnda;
        private System.Windows.Forms.Button btnModoParticulas;
        private System.Windows.Forms.Button btnModoFiguras;
        private System.Windows.Forms.Button btnModoCircular;
        private System.Windows.Forms.Panel panelListaCanciones;
        private System.Windows.Forms.Label lblPlaylist;
        private System.Windows.Forms.ListBox lstCancionesUnificada;
        private System.Windows.Forms.Panel panelMarcoVisualizador;
        private System.Windows.Forms.Panel panelVisualizador;
        private System.Windows.Forms.Panel panelProgreso;
        private System.Windows.Forms.Panel panelControles;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Panel panelVolumen;
        private System.Windows.Forms.Label lblVolumen;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblCancionActual;
        private System.Windows.Forms.Label lblEstado;
    }
}

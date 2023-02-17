namespace ComputerVision
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelSource = new System.Windows.Forms.Panel();
            this.panelDestination = new System.Windows.Forms.Panel();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxSplit = new System.Windows.Forms.TextBox();
            this.buttonSplit = new System.Windows.Forms.Button();
            this.buttonGabor = new System.Windows.Forms.Button();
            this.buttonFreiChen = new System.Windows.Forms.Button();
            this.buttonPrewitt = new System.Windows.Forms.Button();
            this.buttonKirsch = new System.Windows.Forms.Button();
            this.buttonUnsharp = new System.Windows.Forms.Button();
            this.buttonFTS = new System.Windows.Forms.Button();
            this.buttonMarkov = new System.Windows.Forms.Button();
            this.buttonIntensitate = new System.Windows.Forms.Button();
            this.textBoxFTJ = new System.Windows.Forms.TextBox();
            this.buttonFTJ = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBoxReflection = new System.Windows.Forms.ComboBox();
            this.buttonReflexie = new System.Windows.Forms.Button();
            this.buttonHistograma = new System.Windows.Forms.Button();
            this.trackbarContrast = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarLuminosity = new System.Windows.Forms.TrackBar();
            this.buttonNegative = new System.Windows.Forms.Button();
            this.buttonGrayscale = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLuminosity)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSource
            // 
            this.panelSource.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSource.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panelSource.Location = new System.Drawing.Point(12, 12);
            this.panelSource.Name = "panelSource";
            this.panelSource.Size = new System.Drawing.Size(320, 240);
            this.panelSource.TabIndex = 0;
            this.panelSource.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSource_Paint);
            this.panelSource.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelSource_MouseClick);
            // 
            // panelDestination
            // 
            this.panelDestination.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelDestination.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDestination.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panelDestination.Location = new System.Drawing.Point(348, 12);
            this.panelDestination.Name = "panelDestination";
            this.panelDestination.Size = new System.Drawing.Size(320, 240);
            this.panelDestination.TabIndex = 1;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(12, 271);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBoxSplit);
            this.panel1.Controls.Add(this.buttonSplit);
            this.panel1.Controls.Add(this.buttonGabor);
            this.panel1.Controls.Add(this.buttonFreiChen);
            this.panel1.Controls.Add(this.buttonPrewitt);
            this.panel1.Controls.Add(this.buttonKirsch);
            this.panel1.Controls.Add(this.buttonUnsharp);
            this.panel1.Controls.Add(this.buttonFTS);
            this.panel1.Controls.Add(this.buttonMarkov);
            this.panel1.Controls.Add(this.buttonIntensitate);
            this.panel1.Controls.Add(this.textBoxFTJ);
            this.panel1.Controls.Add(this.buttonFTJ);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.comboBoxReflection);
            this.panel1.Controls.Add(this.buttonReflexie);
            this.panel1.Controls.Add(this.buttonHistograma);
            this.panel1.Controls.Add(this.trackbarContrast);
            this.panel1.Controls.Add(this.trackBar1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.trackBarLuminosity);
            this.panel1.Controls.Add(this.buttonNegative);
            this.panel1.Controls.Add(this.buttonGrayscale);
            this.panel1.Location = new System.Drawing.Point(348, 271);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 396);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // textBoxSplit
            // 
            this.textBoxSplit.Location = new System.Drawing.Point(229, 360);
            this.textBoxSplit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxSplit.Name = "textBoxSplit";
            this.textBoxSplit.Size = new System.Drawing.Size(66, 20);
            this.textBoxSplit.TabIndex = 32;
            // 
            // buttonSplit
            // 
            this.buttonSplit.Location = new System.Drawing.Point(118, 359);
            this.buttonSplit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSplit.Name = "buttonSplit";
            this.buttonSplit.Size = new System.Drawing.Size(96, 19);
            this.buttonSplit.TabIndex = 31;
            this.buttonSplit.Text = "Split and merge";
            this.buttonSplit.UseVisualStyleBackColor = true;
            this.buttonSplit.Click += new System.EventHandler(this.buttonSplit_Click);
            // 
            // buttonGabor
            // 
            this.buttonGabor.Location = new System.Drawing.Point(18, 360);
            this.buttonGabor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonGabor.Name = "buttonGabor";
            this.buttonGabor.Size = new System.Drawing.Size(86, 19);
            this.buttonGabor.TabIndex = 30;
            this.buttonGabor.Text = "Gabor";
            this.buttonGabor.UseVisualStyleBackColor = true;
            this.buttonGabor.Click += new System.EventHandler(this.buttonGabor_Click);
            // 
            // buttonFreiChen
            // 
            this.buttonFreiChen.Location = new System.Drawing.Point(189, 322);
            this.buttonFreiChen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonFreiChen.Name = "buttonFreiChen";
            this.buttonFreiChen.Size = new System.Drawing.Size(108, 19);
            this.buttonFreiChen.TabIndex = 29;
            this.buttonFreiChen.Text = "Frei-Chen";
            this.buttonFreiChen.UseVisualStyleBackColor = true;
            this.buttonFreiChen.Click += new System.EventHandler(this.buttonFreiChen_Click);
            // 
            // buttonPrewitt
            // 
            this.buttonPrewitt.Location = new System.Drawing.Point(118, 322);
            this.buttonPrewitt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonPrewitt.Name = "buttonPrewitt";
            this.buttonPrewitt.Size = new System.Drawing.Size(56, 19);
            this.buttonPrewitt.TabIndex = 28;
            this.buttonPrewitt.Text = "Prewitt";
            this.buttonPrewitt.UseVisualStyleBackColor = true;
            this.buttonPrewitt.Click += new System.EventHandler(this.buttonPrewitt_Click);
            // 
            // buttonKirsch
            // 
            this.buttonKirsch.Location = new System.Drawing.Point(19, 322);
            this.buttonKirsch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonKirsch.Name = "buttonKirsch";
            this.buttonKirsch.Size = new System.Drawing.Size(85, 19);
            this.buttonKirsch.TabIndex = 27;
            this.buttonKirsch.Text = "Kirsch";
            this.buttonKirsch.UseVisualStyleBackColor = true;
            this.buttonKirsch.Click += new System.EventHandler(this.buttonKirsch_Click);
            // 
            // buttonUnsharp
            // 
            this.buttonUnsharp.Location = new System.Drawing.Point(189, 284);
            this.buttonUnsharp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonUnsharp.Name = "buttonUnsharp";
            this.buttonUnsharp.Size = new System.Drawing.Size(108, 19);
            this.buttonUnsharp.TabIndex = 26;
            this.buttonUnsharp.Text = "Unsharp Masking";
            this.buttonUnsharp.UseVisualStyleBackColor = true;
            this.buttonUnsharp.Click += new System.EventHandler(this.buttonUnsharp_Click);
            // 
            // buttonFTS
            // 
            this.buttonFTS.Location = new System.Drawing.Point(118, 285);
            this.buttonFTS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonFTS.Name = "buttonFTS";
            this.buttonFTS.Size = new System.Drawing.Size(56, 19);
            this.buttonFTS.TabIndex = 25;
            this.buttonFTS.Text = "FTS";
            this.buttonFTS.UseVisualStyleBackColor = true;
            this.buttonFTS.Click += new System.EventHandler(this.buttonFTS_Click);
            // 
            // buttonMarkov
            // 
            this.buttonMarkov.Location = new System.Drawing.Point(19, 285);
            this.buttonMarkov.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonMarkov.Name = "buttonMarkov";
            this.buttonMarkov.Size = new System.Drawing.Size(85, 19);
            this.buttonMarkov.TabIndex = 24;
            this.buttonMarkov.Text = "Filtrul Markov";
            this.buttonMarkov.UseVisualStyleBackColor = true;
            this.buttonMarkov.Click += new System.EventHandler(this.buttonMarkov_Click);
            // 
            // buttonIntensitate
            // 
            this.buttonIntensitate.Location = new System.Drawing.Point(189, 248);
            this.buttonIntensitate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonIntensitate.Name = "buttonIntensitate";
            this.buttonIntensitate.Size = new System.Drawing.Size(108, 19);
            this.buttonIntensitate.TabIndex = 23;
            this.buttonIntensitate.Text = "Intensitate pixel";
            this.buttonIntensitate.UseVisualStyleBackColor = true;
            this.buttonIntensitate.Click += new System.EventHandler(this.buttonIntensitate_Click);
            // 
            // textBoxFTJ
            // 
            this.textBoxFTJ.Location = new System.Drawing.Point(100, 249);
            this.textBoxFTJ.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxFTJ.Name = "textBoxFTJ";
            this.textBoxFTJ.Size = new System.Drawing.Size(76, 20);
            this.textBoxFTJ.TabIndex = 22;
            this.textBoxFTJ.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // buttonFTJ
            // 
            this.buttonFTJ.Location = new System.Drawing.Point(19, 249);
            this.buttonFTJ.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonFTJ.Name = "buttonFTJ";
            this.buttonFTJ.Size = new System.Drawing.Size(75, 19);
            this.buttonFTJ.TabIndex = 21;
            this.buttonFTJ.Text = "FTJ";
            this.buttonFTJ.UseVisualStyleBackColor = true;
            this.buttonFTJ.Click += new System.EventHandler(this.buttonFTJ_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(206, 210);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(92, 20);
            this.textBox1.TabIndex = 20;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // comboBoxReflection
            // 
            this.comboBoxReflection.FormattingEnabled = true;
            this.comboBoxReflection.Items.AddRange(new object[] {
            "Orizontal",
            "Vertical",
            "Arbitrar"});
            this.comboBoxReflection.Location = new System.Drawing.Point(100, 208);
            this.comboBoxReflection.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxReflection.Name = "comboBoxReflection";
            this.comboBoxReflection.Size = new System.Drawing.Size(92, 21);
            this.comboBoxReflection.TabIndex = 19;
            this.comboBoxReflection.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // buttonReflexie
            // 
            this.buttonReflexie.Location = new System.Drawing.Point(19, 206);
            this.buttonReflexie.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonReflexie.Name = "buttonReflexie";
            this.buttonReflexie.Size = new System.Drawing.Size(75, 21);
            this.buttonReflexie.TabIndex = 18;
            this.buttonReflexie.Text = "Reflexie";
            this.buttonReflexie.UseVisualStyleBackColor = true;
            this.buttonReflexie.Click += new System.EventHandler(this.buttonReflexie_Click);
            // 
            // buttonHistograma
            // 
            this.buttonHistograma.Location = new System.Drawing.Point(180, 154);
            this.buttonHistograma.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonHistograma.Name = "buttonHistograma";
            this.buttonHistograma.Size = new System.Drawing.Size(127, 23);
            this.buttonHistograma.TabIndex = 4;
            this.buttonHistograma.Text = "Egalizarea Histogramei";
            this.buttonHistograma.UseVisualStyleBackColor = true;
            this.buttonHistograma.Click += new System.EventHandler(this.buttonHistograma_Click);
            // 
            // trackbarContrast
            // 
            this.trackbarContrast.AutoSize = true;
            this.trackbarContrast.Location = new System.Drawing.Point(14, 84);
            this.trackbarContrast.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.trackbarContrast.Name = "trackbarContrast";
            this.trackbarContrast.Size = new System.Drawing.Size(46, 13);
            this.trackbarContrast.TabIndex = 17;
            this.trackbarContrast.Text = "Contrast";
            this.trackbarContrast.Click += new System.EventHandler(this.label2_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(16, 104);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trackBar1.Maximum = 130;
            this.trackBar1.Minimum = -130;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(226, 45);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Luminozitate";
            // 
            // trackBarLuminosity
            // 
            this.trackBarLuminosity.Location = new System.Drawing.Point(7, 49);
            this.trackBarLuminosity.Maximum = 255;
            this.trackBarLuminosity.Minimum = -255;
            this.trackBarLuminosity.Name = "trackBarLuminosity";
            this.trackBarLuminosity.Size = new System.Drawing.Size(236, 45);
            this.trackBarLuminosity.TabIndex = 15;
            this.trackBarLuminosity.ValueChanged += new System.EventHandler(this.trackBarLuminosity_ValueChanged);
            // 
            // buttonNegative
            // 
            this.buttonNegative.Location = new System.Drawing.Point(100, 154);
            this.buttonNegative.Name = "buttonNegative";
            this.buttonNegative.Size = new System.Drawing.Size(75, 23);
            this.buttonNegative.TabIndex = 14;
            this.buttonNegative.Text = "Negative";
            this.buttonNegative.UseVisualStyleBackColor = true;
            this.buttonNegative.Click += new System.EventHandler(this.buttonNegative_Click);
            // 
            // buttonGrayscale
            // 
            this.buttonGrayscale.Location = new System.Drawing.Point(19, 155);
            this.buttonGrayscale.Name = "buttonGrayscale";
            this.buttonGrayscale.Size = new System.Drawing.Size(75, 23);
            this.buttonGrayscale.TabIndex = 13;
            this.buttonGrayscale.Text = "Grayscale";
            this.buttonGrayscale.UseVisualStyleBackColor = true;
            this.buttonGrayscale.Click += new System.EventHandler(this.buttonGrayscale_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 679);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.panelDestination);
            this.Controls.Add(this.panelSource);
            this.Name = "MainForm";
            this.Text = "f";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLuminosity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSource;
        private System.Windows.Forms.Panel panelDestination;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonGrayscale;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonNegative;
        private System.Windows.Forms.TrackBar trackBarLuminosity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label trackbarContrast;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button buttonHistograma;
        private System.Windows.Forms.Button buttonReflexie;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBoxReflection;
        private System.Windows.Forms.TextBox textBoxFTJ;
        private System.Windows.Forms.Button buttonFTJ;
        private System.Windows.Forms.Button buttonIntensitate;
        private System.Windows.Forms.Button buttonMarkov;
        private System.Windows.Forms.Button buttonFTS;
        private System.Windows.Forms.Button buttonUnsharp;
        private System.Windows.Forms.Button buttonKirsch;
        private System.Windows.Forms.Button buttonPrewitt;
        private System.Windows.Forms.Button buttonFreiChen;
        private System.Windows.Forms.Button buttonGabor;
        private System.Windows.Forms.TextBox textBoxSplit;
        private System.Windows.Forms.Button btnSplitMerge;
        private System.Windows.Forms.Button buttonSplit;
    }
}


namespace ParticleSystems
{
    partial class MainFrame
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.glControl = new OpenTK.GLControl();
            this.label1 = new System.Windows.Forms.Label();
            this.amountBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.lifetimeBox = new System.Windows.Forms.TextBox();
            this.newParticleBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.frameButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.randomRadioButton = new System.Windows.Forms.RadioButton();
            this.tenRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl
            // 
            this.glControl.BackColor = System.Drawing.Color.Black;
            this.glControl.Location = new System.Drawing.Point(12, 12);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(400, 400);
            this.glControl.TabIndex = 0;
            this.glControl.VSync = false;
            this.glControl.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(427, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of particles";
            // 
            // amountBox
            // 
            this.amountBox.Location = new System.Drawing.Point(572, 93);
            this.amountBox.Name = "amountBox";
            this.amountBox.Size = new System.Drawing.Size(100, 20);
            this.amountBox.TabIndex = 2;
            this.amountBox.Text = "10";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(597, 175);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // lifetimeBox
            // 
            this.lifetimeBox.Location = new System.Drawing.Point(572, 119);
            this.lifetimeBox.Name = "lifetimeBox";
            this.lifetimeBox.Size = new System.Drawing.Size(100, 20);
            this.lifetimeBox.TabIndex = 4;
            this.lifetimeBox.Text = "10";
            // 
            // newParticleBox
            // 
            this.newParticleBox.Location = new System.Drawing.Point(572, 149);
            this.newParticleBox.Name = "newParticleBox";
            this.newParticleBox.Size = new System.Drawing.Size(100, 20);
            this.newParticleBox.TabIndex = 5;
            this.newParticleBox.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(427, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Lifetime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(427, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Max new particles per frame";
            // 
            // frameButton
            // 
            this.frameButton.Enabled = false;
            this.frameButton.Location = new System.Drawing.Point(572, 266);
            this.frameButton.Name = "frameButton";
            this.frameButton.Size = new System.Drawing.Size(75, 23);
            this.frameButton.TabIndex = 8;
            this.frameButton.Text = "Next frame";
            this.frameButton.UseVisualStyleBackColor = true;
            this.frameButton.Click += new System.EventHandler(this.frameButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Enabled = false;
            this.pauseButton.Location = new System.Drawing.Point(491, 266);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 23);
            this.pauseButton.TabIndex = 9;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // randomRadioButton
            // 
            this.randomRadioButton.AutoSize = true;
            this.randomRadioButton.Checked = true;
            this.randomRadioButton.Location = new System.Drawing.Point(6, 24);
            this.randomRadioButton.Name = "randomRadioButton";
            this.randomRadioButton.Size = new System.Drawing.Size(67, 17);
            this.randomRadioButton.TabIndex = 10;
            this.randomRadioButton.TabStop = true;
            this.randomRadioButton.Text = "randomly";
            this.randomRadioButton.UseVisualStyleBackColor = true;
            // 
            // tenRadioButton
            // 
            this.tenRadioButton.AutoSize = true;
            this.tenRadioButton.Location = new System.Drawing.Point(6, 47);
            this.tenRadioButton.Name = "tenRadioButton";
            this.tenRadioButton.Size = new System.Drawing.Size(86, 17);
            this.tenRadioButton.TabIndex = 11;
            this.tenRadioButton.Text = "x+1 and  y+1";
            this.tenRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.randomRadioButton);
            this.groupBox1.Controls.Add(this.tenRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(430, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(143, 66);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Position Update";
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 458);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.frameButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.newParticleBox);
            this.Controls.Add(this.lifetimeBox);
            this.Controls.Add(this.amountBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.glControl);
            this.Name = "MainFrame";
            this.Text = "Particle System Explorer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox amountBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox lifetimeBox;
        private System.Windows.Forms.TextBox newParticleBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button frameButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.RadioButton randomRadioButton;
        private System.Windows.Forms.RadioButton tenRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}


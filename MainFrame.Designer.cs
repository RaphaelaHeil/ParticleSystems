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
            this.xIncreaseBox = new System.Windows.Forms.TextBox();
            this.yIncreaseBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
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
            this.glControl.Paint += new System.Windows.Forms.PaintEventHandler(this.onRender);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(488, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of particles";
            // 
            // amountBox
            // 
            this.amountBox.Location = new System.Drawing.Point(625, 128);
            this.amountBox.Name = "amountBox";
            this.amountBox.Size = new System.Drawing.Size(31, 20);
            this.amountBox.TabIndex = 2;
            this.amountBox.Text = "20";
            this.amountBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(581, 210);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // lifetimeBox
            // 
            this.lifetimeBox.Location = new System.Drawing.Point(625, 154);
            this.lifetimeBox.Name = "lifetimeBox";
            this.lifetimeBox.Size = new System.Drawing.Size(31, 20);
            this.lifetimeBox.TabIndex = 4;
            this.lifetimeBox.Text = "20";
            this.lifetimeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // newParticleBox
            // 
            this.newParticleBox.Location = new System.Drawing.Point(625, 184);
            this.newParticleBox.Name = "newParticleBox";
            this.newParticleBox.Size = new System.Drawing.Size(31, 20);
            this.newParticleBox.TabIndex = 5;
            this.newParticleBox.Text = "20";
            this.newParticleBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(488, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Lifetime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(488, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Max new particles per frame";
            // 
            // frameButton
            // 
            this.frameButton.Enabled = false;
            this.frameButton.Location = new System.Drawing.Point(581, 296);
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
            this.pauseButton.Location = new System.Drawing.Point(500, 296);
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
            this.randomRadioButton.CheckedChanged += new System.EventHandler(this.randomRadioButton_CheckedChanged);
            // 
            // tenRadioButton
            // 
            this.tenRadioButton.AutoSize = true;
            this.tenRadioButton.Location = new System.Drawing.Point(6, 47);
            this.tenRadioButton.Name = "tenRadioButton";
            this.tenRadioButton.Size = new System.Drawing.Size(50, 17);
            this.tenRadioButton.TabIndex = 11;
            this.tenRadioButton.Text = "linear";
            this.tenRadioButton.UseVisualStyleBackColor = true;
            this.tenRadioButton.CheckedChanged += new System.EventHandler(this.linearRadioButton_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.yIncreaseBox);
            this.groupBox1.Controls.Add(this.xIncreaseBox);
            this.groupBox1.Controls.Add(this.randomRadioButton);
            this.groupBox1.Controls.Add(this.tenRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(456, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 75);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Position Update";
            // 
            // xIncreaseBox
            // 
            this.xIncreaseBox.Enabled = false;
            this.xIncreaseBox.Location = new System.Drawing.Point(102, 46);
            this.xIncreaseBox.Name = "xIncreaseBox";
            this.xIncreaseBox.Size = new System.Drawing.Size(39, 20);
            this.xIncreaseBox.TabIndex = 12;
            this.xIncreaseBox.Text = "1";
            this.xIncreaseBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // yIncreaseBox
            // 
            this.yIncreaseBox.Enabled = false;
            this.yIncreaseBox.Location = new System.Drawing.Point(183, 46);
            this.yIncreaseBox.Name = "yIncreaseBox";
            this.yIncreaseBox.Size = new System.Drawing.Size(38, 20);
            this.yIncreaseBox.TabIndex = 13;
            this.yIncreaseBox.Text = "1";
            this.yIncreaseBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "x + ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(161, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "y +";
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
        private System.Windows.Forms.TextBox yIncreaseBox;
        private System.Windows.Forms.TextBox xIncreaseBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}


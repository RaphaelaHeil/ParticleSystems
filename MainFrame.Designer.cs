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
            this.initialAmountInput = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.lifetimeInput = new System.Windows.Forms.TextBox();
            this.velocityInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.frameButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.psSettings = new System.Windows.Forms.GroupBox();
            this.particleSystemSettingsPanel = new ParticleSystems.ParticleSystemSettingsPanel();
            this.particleSystemSettings = new System.Windows.Forms.GroupBox();
            this.descriptionPanel = new System.Windows.Forms.Panel();
            this.particleSystemDescription = new System.Windows.Forms.Label();
            this.particleSystemSelection = new System.Windows.Forms.ComboBox();
            this.generalSettings = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.agingRand = new System.Windows.Forms.RadioButton();
            this.agingExact = new System.Windows.Forms.RadioButton();
            this.agingVelocityInput = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.newPerFrameRand = new System.Windows.Forms.RadioButton();
            this.newPerFrameExact = new System.Windows.Forms.RadioButton();
            this.newParticlesInput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lifetimeExact = new System.Windows.Forms.RadioButton();
            this.lifetimeRand = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.velocityRand = new System.Windows.Forms.RadioButton();
            this.velocityExact = new System.Windows.Forms.RadioButton();
            this.amountGroupBox = new System.Windows.Forms.GroupBox();
            this.frameControls = new System.Windows.Forms.GroupBox();
            this.framesPerSecondOutput = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.psSettings.SuspendLayout();
            this.particleSystemSettings.SuspendLayout();
            this.descriptionPanel.SuspendLayout();
            this.generalSettings.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.amountGroupBox.SuspendLayout();
            this.frameControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl
            // 
            this.glControl.BackColor = System.Drawing.Color.Black;
            this.glControl.Location = new System.Drawing.Point(12, 12);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(600, 600);
            this.glControl.TabIndex = 0;
            this.glControl.VSync = false;
            this.glControl.Paint += new System.Windows.Forms.PaintEventHandler(this.onRender);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Initial number of particles";
            // 
            // initialAmountInput
            // 
            this.initialAmountInput.Location = new System.Drawing.Point(146, 14);
            this.initialAmountInput.Name = "initialAmountInput";
            this.initialAmountInput.Size = new System.Drawing.Size(43, 20);
            this.initialAmountInput.TabIndex = 2;
            this.initialAmountInput.Text = "20";
            this.initialAmountInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(16, 19);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // lifetimeInput
            // 
            this.lifetimeInput.Location = new System.Drawing.Point(146, 13);
            this.lifetimeInput.Name = "lifetimeInput";
            this.lifetimeInput.Size = new System.Drawing.Size(43, 20);
            this.lifetimeInput.TabIndex = 4;
            this.lifetimeInput.Text = "5";
            this.lifetimeInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // velocityInput
            // 
            this.velocityInput.Location = new System.Drawing.Point(146, 14);
            this.velocityInput.Name = "velocityInput";
            this.velocityInput.Size = new System.Drawing.Size(43, 20);
            this.velocityInput.TabIndex = 5;
            this.velocityInput.Text = "1";
            this.velocityInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Lifetime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Velocity";
            // 
            // frameButton
            // 
            this.frameButton.Enabled = false;
            this.frameButton.Location = new System.Drawing.Point(178, 19);
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
            this.pauseButton.Location = new System.Drawing.Point(97, 19);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 23);
            this.pauseButton.TabIndex = 9;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // psSettings
            // 
            this.psSettings.Controls.Add(this.particleSystemSettingsPanel);
            this.psSettings.Location = new System.Drawing.Point(7, 91);
            this.psSettings.Name = "psSettings";
            this.psSettings.Size = new System.Drawing.Size(452, 189);
            this.psSettings.TabIndex = 12;
            this.psSettings.TabStop = false;
            this.psSettings.Text = "System specific settings";
            // 
            // particleSystemSettingsPanel
            // 
            this.particleSystemSettingsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.particleSystemSettingsPanel.Location = new System.Drawing.Point(6, 19);
            this.particleSystemSettingsPanel.Name = "particleSystemSettingsPanel";
            this.particleSystemSettingsPanel.Size = new System.Drawing.Size(437, 167);
            this.particleSystemSettingsPanel.TabIndex = 0;
            // 
            // particleSystemSettings
            // 
            this.particleSystemSettings.Controls.Add(this.descriptionPanel);
            this.particleSystemSettings.Controls.Add(this.particleSystemSelection);
            this.particleSystemSettings.Controls.Add(this.psSettings);
            this.particleSystemSettings.Location = new System.Drawing.Point(623, 12);
            this.particleSystemSettings.Name = "particleSystemSettings";
            this.particleSystemSettings.Size = new System.Drawing.Size(470, 286);
            this.particleSystemSettings.TabIndex = 13;
            this.particleSystemSettings.TabStop = false;
            this.particleSystemSettings.Text = "Particle system settings";
            // 
            // descriptionPanel
            // 
            this.descriptionPanel.Controls.Add(this.particleSystemDescription);
            this.descriptionPanel.Location = new System.Drawing.Point(7, 46);
            this.descriptionPanel.Name = "descriptionPanel";
            this.descriptionPanel.Size = new System.Drawing.Size(458, 42);
            this.descriptionPanel.TabIndex = 1;
            // 
            // particleSystemDescription
            // 
            this.particleSystemDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.particleSystemDescription.Location = new System.Drawing.Point(0, 0);
            this.particleSystemDescription.Name = "particleSystemDescription";
            this.particleSystemDescription.Size = new System.Drawing.Size(458, 42);
            this.particleSystemDescription.TabIndex = 0;
            // 
            // particleSystemSelection
            // 
            this.particleSystemSelection.FormattingEnabled = true;
            this.particleSystemSelection.Location = new System.Drawing.Point(7, 19);
            this.particleSystemSelection.Name = "particleSystemSelection";
            this.particleSystemSelection.Size = new System.Drawing.Size(152, 21);
            this.particleSystemSelection.TabIndex = 0;
            this.particleSystemSelection.Text = "Select particle system ...";
            this.particleSystemSelection.SelectedIndexChanged += new System.EventHandler(this.particleSystemSelected);
            // 
            // generalSettings
            // 
            this.generalSettings.Controls.Add(this.groupBox8);
            this.generalSettings.Controls.Add(this.groupBox7);
            this.generalSettings.Controls.Add(this.groupBox6);
            this.generalSettings.Controls.Add(this.groupBox5);
            this.generalSettings.Controls.Add(this.amountGroupBox);
            this.generalSettings.Cursor = System.Windows.Forms.Cursors.Default;
            this.generalSettings.Location = new System.Drawing.Point(623, 304);
            this.generalSettings.Name = "generalSettings";
            this.generalSettings.Size = new System.Drawing.Size(470, 254);
            this.generalSettings.TabIndex = 14;
            this.generalSettings.TabStop = false;
            this.generalSettings.Text = "General particle settings";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.agingRand);
            this.groupBox8.Controls.Add(this.agingExact);
            this.groupBox8.Controls.Add(this.agingVelocityInput);
            this.groupBox8.Controls.Add(this.label7);
            this.groupBox8.Location = new System.Drawing.Point(7, 157);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(458, 40);
            this.groupBox8.TabIndex = 14;
            this.groupBox8.TabStop = false;
            // 
            // agingRand
            // 
            this.agingRand.AutoSize = true;
            this.agingRand.Location = new System.Drawing.Point(305, 12);
            this.agingRand.Name = "agingRand";
            this.agingRand.Size = new System.Drawing.Size(107, 17);
            this.agingRand.TabIndex = 7;
            this.agingRand.Text = "random (1, value)";
            this.agingRand.UseVisualStyleBackColor = true;
            // 
            // agingExact
            // 
            this.agingExact.AutoSize = true;
            this.agingExact.Checked = true;
            this.agingExact.Location = new System.Drawing.Point(209, 14);
            this.agingExact.Name = "agingExact";
            this.agingExact.Size = new System.Drawing.Size(89, 17);
            this.agingExact.TabIndex = 8;
            this.agingExact.TabStop = true;
            this.agingExact.Text = "exact amount";
            this.agingExact.UseVisualStyleBackColor = true;
            // 
            // agingVelocityInput
            // 
            this.agingVelocityInput.Location = new System.Drawing.Point(145, 14);
            this.agingVelocityInput.Name = "agingVelocityInput";
            this.agingVelocityInput.Size = new System.Drawing.Size(44, 20);
            this.agingVelocityInput.TabIndex = 5;
            this.agingVelocityInput.Text = "1";
            this.agingVelocityInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Aging Velocity";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.newPerFrameRand);
            this.groupBox7.Controls.Add(this.newPerFrameExact);
            this.groupBox7.Controls.Add(this.newParticlesInput);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Location = new System.Drawing.Point(6, 65);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(458, 40);
            this.groupBox7.TabIndex = 13;
            this.groupBox7.TabStop = false;
            // 
            // newPerFrameRand
            // 
            this.newPerFrameRand.AutoSize = true;
            this.newPerFrameRand.Location = new System.Drawing.Point(305, 16);
            this.newPerFrameRand.Name = "newPerFrameRand";
            this.newPerFrameRand.Size = new System.Drawing.Size(107, 17);
            this.newPerFrameRand.TabIndex = 7;
            this.newPerFrameRand.Text = "random (0, value)";
            this.newPerFrameRand.UseVisualStyleBackColor = true;
            // 
            // newPerFrameExact
            // 
            this.newPerFrameExact.AutoSize = true;
            this.newPerFrameExact.Checked = true;
            this.newPerFrameExact.Location = new System.Drawing.Point(210, 16);
            this.newPerFrameExact.Name = "newPerFrameExact";
            this.newPerFrameExact.Size = new System.Drawing.Size(89, 17);
            this.newPerFrameExact.TabIndex = 8;
            this.newPerFrameExact.TabStop = true;
            this.newPerFrameExact.Text = "exact amount";
            this.newPerFrameExact.UseVisualStyleBackColor = true;
            // 
            // newParticlesInput
            // 
            this.newParticlesInput.Location = new System.Drawing.Point(145, 14);
            this.newParticlesInput.Name = "newParticlesInput";
            this.newParticlesInput.Size = new System.Drawing.Size(44, 20);
            this.newParticlesInput.TabIndex = 5;
            this.newParticlesInput.Text = "10";
            this.newParticlesInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "New particles per frame";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lifetimeExact);
            this.groupBox6.Controls.Add(this.lifetimeRand);
            this.groupBox6.Controls.Add(this.lifetimeInput);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Location = new System.Drawing.Point(7, 111);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(458, 40);
            this.groupBox6.TabIndex = 13;
            this.groupBox6.TabStop = false;
            // 
            // lifetimeExact
            // 
            this.lifetimeExact.AutoSize = true;
            this.lifetimeExact.Checked = true;
            this.lifetimeExact.Location = new System.Drawing.Point(210, 13);
            this.lifetimeExact.Name = "lifetimeExact";
            this.lifetimeExact.Size = new System.Drawing.Size(89, 17);
            this.lifetimeExact.TabIndex = 3;
            this.lifetimeExact.TabStop = true;
            this.lifetimeExact.Text = "exact amount";
            this.lifetimeExact.UseVisualStyleBackColor = true;
            // 
            // lifetimeRand
            // 
            this.lifetimeRand.AutoSize = true;
            this.lifetimeRand.Location = new System.Drawing.Point(305, 13);
            this.lifetimeRand.Name = "lifetimeRand";
            this.lifetimeRand.Size = new System.Drawing.Size(107, 17);
            this.lifetimeRand.TabIndex = 4;
            this.lifetimeRand.Text = "random (0, value)";
            this.lifetimeRand.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.velocityRand);
            this.groupBox5.Controls.Add(this.velocityExact);
            this.groupBox5.Controls.Add(this.velocityInput);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Location = new System.Drawing.Point(7, 203);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(458, 40);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            // 
            // velocityRand
            // 
            this.velocityRand.AutoSize = true;
            this.velocityRand.Location = new System.Drawing.Point(305, 12);
            this.velocityRand.Name = "velocityRand";
            this.velocityRand.Size = new System.Drawing.Size(141, 17);
            this.velocityRand.TabIndex = 7;
            this.velocityRand.Text = "random([0.0,1.0]) * value";
            this.velocityRand.UseVisualStyleBackColor = true;
            // 
            // velocityExact
            // 
            this.velocityExact.AutoSize = true;
            this.velocityExact.Checked = true;
            this.velocityExact.Location = new System.Drawing.Point(210, 12);
            this.velocityExact.Name = "velocityExact";
            this.velocityExact.Size = new System.Drawing.Size(89, 17);
            this.velocityExact.TabIndex = 8;
            this.velocityExact.TabStop = true;
            this.velocityExact.Text = "exact amount";
            this.velocityExact.UseVisualStyleBackColor = true;
            // 
            // amountGroupBox
            // 
            this.amountGroupBox.Controls.Add(this.initialAmountInput);
            this.amountGroupBox.Controls.Add(this.label1);
            this.amountGroupBox.Location = new System.Drawing.Point(6, 19);
            this.amountGroupBox.Name = "amountGroupBox";
            this.amountGroupBox.Size = new System.Drawing.Size(458, 40);
            this.amountGroupBox.TabIndex = 11;
            this.amountGroupBox.TabStop = false;
            // 
            // frameControls
            // 
            this.frameControls.Controls.Add(this.framesPerSecondOutput);
            this.frameControls.Controls.Add(this.label4);
            this.frameControls.Controls.Add(this.startButton);
            this.frameControls.Controls.Add(this.pauseButton);
            this.frameControls.Controls.Add(this.frameButton);
            this.frameControls.Enabled = false;
            this.frameControls.Location = new System.Drawing.Point(623, 564);
            this.frameControls.Name = "frameControls";
            this.frameControls.Size = new System.Drawing.Size(470, 48);
            this.frameControls.TabIndex = 15;
            this.frameControls.TabStop = false;
            this.frameControls.Text = "Frame Controls";
            // 
            // framesPerSecondOutput
            // 
            this.framesPerSecondOutput.AutoSize = true;
            this.framesPerSecondOutput.Location = new System.Drawing.Point(392, 24);
            this.framesPerSecondOutput.Name = "framesPerSecondOutput";
            this.framesPerSecondOutput.Size = new System.Drawing.Size(13, 13);
            this.framesPerSecondOutput.TabIndex = 11;
            this.framesPerSecondOutput.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Frames per Second:";
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 627);
            this.Controls.Add(this.generalSettings);
            this.Controls.Add(this.frameControls);
            this.Controls.Add(this.particleSystemSettings);
            this.Controls.Add(this.glControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainFrame";
            this.Text = "Particle System Explorer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.psSettings.ResumeLayout(false);
            this.particleSystemSettings.ResumeLayout(false);
            this.descriptionPanel.ResumeLayout(false);
            this.generalSettings.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.amountGroupBox.ResumeLayout(false);
            this.amountGroupBox.PerformLayout();
            this.frameControls.ResumeLayout(false);
            this.frameControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.GLControl glControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox initialAmountInput;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox lifetimeInput;
        private System.Windows.Forms.TextBox velocityInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button frameButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.GroupBox psSettings;
        private System.Windows.Forms.GroupBox particleSystemSettings;
        private System.Windows.Forms.GroupBox generalSettings;
        private System.Windows.Forms.GroupBox frameControls;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton lifetimeExact;
        private System.Windows.Forms.RadioButton lifetimeRand;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton velocityRand;
        private System.Windows.Forms.RadioButton velocityExact;
        private System.Windows.Forms.GroupBox amountGroupBox;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton newPerFrameRand;
        private System.Windows.Forms.RadioButton newPerFrameExact;
        private System.Windows.Forms.TextBox newParticlesInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RadioButton agingRand;
        private System.Windows.Forms.RadioButton agingExact;
        private System.Windows.Forms.TextBox agingVelocityInput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel descriptionPanel;
        private System.Windows.Forms.Label particleSystemDescription;
        private System.Windows.Forms.ComboBox particleSystemSelection;
        private System.Windows.Forms.Label framesPerSecondOutput;
        private System.Windows.Forms.Label label4;
        private ParticleSystemSettingsPanel particleSystemSettingsPanel;
    }
}


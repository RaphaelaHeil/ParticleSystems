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
            this.particleSystemSettings = new System.Windows.Forms.GroupBox();
            this.descriptionPanel = new System.Windows.Forms.Panel();
            this.particleSystemDescription = new System.Windows.Forms.Label();
            this.particleSystemSelection = new System.Windows.Forms.ComboBox();
            this.generalSettings = new System.Windows.Forms.GroupBox();
            this.ageVelocityPanel = new System.Windows.Forms.Panel();
            this.agingRand = new System.Windows.Forms.RadioButton();
            this.agingExact = new System.Windows.Forms.RadioButton();
            this.agingVelocityInput = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.newPerFramePanel = new System.Windows.Forms.Panel();
            this.newPerFrameRand = new System.Windows.Forms.RadioButton();
            this.newPerFrameExact = new System.Windows.Forms.RadioButton();
            this.newParticlesInput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lifetimePanel = new System.Windows.Forms.Panel();
            this.lifetimeExact = new System.Windows.Forms.RadioButton();
            this.lifetimeRand = new System.Windows.Forms.RadioButton();
            this.velocityPanel = new System.Windows.Forms.Panel();
            this.velocityRand = new System.Windows.Forms.RadioButton();
            this.velocityExact = new System.Windows.Forms.RadioButton();
            this.amountPanel = new System.Windows.Forms.Panel();
            this.frameControls = new System.Windows.Forms.GroupBox();
            this.framesPerSecondOutput = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.particleSystemSettingsPanel = new ParticleSystems.ParticleSystemSettingsPanel();
            this.psSettings.SuspendLayout();
            this.particleSystemSettings.SuspendLayout();
            this.descriptionPanel.SuspendLayout();
            this.generalSettings.SuspendLayout();
            this.ageVelocityPanel.SuspendLayout();
            this.newPerFramePanel.SuspendLayout();
            this.lifetimePanel.SuspendLayout();
            this.velocityPanel.SuspendLayout();
            this.amountPanel.SuspendLayout();
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
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Initial number of particles";
            // 
            // initialAmountInput
            // 
            this.initialAmountInput.Location = new System.Drawing.Point(146, 4);
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
            this.lifetimeInput.Location = new System.Drawing.Point(146, 4);
            this.lifetimeInput.Name = "lifetimeInput";
            this.lifetimeInput.Size = new System.Drawing.Size(43, 20);
            this.lifetimeInput.TabIndex = 4;
            this.lifetimeInput.Text = "5";
            this.lifetimeInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // velocityInput
            // 
            this.velocityInput.Location = new System.Drawing.Point(146, 4);
            this.velocityInput.Name = "velocityInput";
            this.velocityInput.Size = new System.Drawing.Size(43, 20);
            this.velocityInput.TabIndex = 5;
            this.velocityInput.Text = "1";
            this.velocityInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Lifetime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 7);
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
            this.psSettings.Location = new System.Drawing.Point(6, 108);
            this.psSettings.Name = "psSettings";
            this.psSettings.Size = new System.Drawing.Size(458, 234);
            this.psSettings.TabIndex = 12;
            this.psSettings.TabStop = false;
            this.psSettings.Text = "System specific settings";
            // 
            // particleSystemSettings
            // 
            this.particleSystemSettings.Controls.Add(this.descriptionPanel);
            this.particleSystemSettings.Controls.Add(this.particleSystemSelection);
            this.particleSystemSettings.Controls.Add(this.psSettings);
            this.particleSystemSettings.Location = new System.Drawing.Point(623, 12);
            this.particleSystemSettings.Name = "particleSystemSettings";
            this.particleSystemSettings.Size = new System.Drawing.Size(470, 348);
            this.particleSystemSettings.TabIndex = 13;
            this.particleSystemSettings.TabStop = false;
            this.particleSystemSettings.Text = "Particle system settings";
            // 
            // descriptionPanel
            // 
            this.descriptionPanel.Controls.Add(this.particleSystemDescription);
            this.descriptionPanel.Location = new System.Drawing.Point(7, 46);
            this.descriptionPanel.Name = "descriptionPanel";
            this.descriptionPanel.Size = new System.Drawing.Size(457, 56);
            this.descriptionPanel.TabIndex = 1;
            // 
            // particleSystemDescription
            // 
            this.particleSystemDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.particleSystemDescription.Location = new System.Drawing.Point(0, 0);
            this.particleSystemDescription.Name = "particleSystemDescription";
            this.particleSystemDescription.Size = new System.Drawing.Size(457, 56);
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
            this.generalSettings.Controls.Add(this.ageVelocityPanel);
            this.generalSettings.Controls.Add(this.newPerFramePanel);
            this.generalSettings.Controls.Add(this.lifetimePanel);
            this.generalSettings.Controls.Add(this.velocityPanel);
            this.generalSettings.Controls.Add(this.amountPanel);
            this.generalSettings.Cursor = System.Windows.Forms.Cursors.Default;
            this.generalSettings.Location = new System.Drawing.Point(623, 366);
            this.generalSettings.Name = "generalSettings";
            this.generalSettings.Size = new System.Drawing.Size(470, 192);
            this.generalSettings.TabIndex = 14;
            this.generalSettings.TabStop = false;
            this.generalSettings.Text = "General particle settings";
            // 
            // ageVelocityPanel
            // 
            this.ageVelocityPanel.Controls.Add(this.agingRand);
            this.ageVelocityPanel.Controls.Add(this.agingExact);
            this.ageVelocityPanel.Controls.Add(this.agingVelocityInput);
            this.ageVelocityPanel.Controls.Add(this.label7);
            this.ageVelocityPanel.Location = new System.Drawing.Point(6, 121);
            this.ageVelocityPanel.Name = "ageVelocityPanel";
            this.ageVelocityPanel.Size = new System.Drawing.Size(458, 28);
            this.ageVelocityPanel.TabIndex = 14;
            // 
            // agingRand
            // 
            this.agingRand.AutoSize = true;
            this.agingRand.Location = new System.Drawing.Point(305, 5);
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
            this.agingExact.Location = new System.Drawing.Point(210, 5);
            this.agingExact.Name = "agingExact";
            this.agingExact.Size = new System.Drawing.Size(89, 17);
            this.agingExact.TabIndex = 8;
            this.agingExact.TabStop = true;
            this.agingExact.Text = "exact amount";
            this.agingExact.UseVisualStyleBackColor = true;
            // 
            // agingVelocityInput
            // 
            this.agingVelocityInput.Location = new System.Drawing.Point(146, 4);
            this.agingVelocityInput.Name = "agingVelocityInput";
            this.agingVelocityInput.Size = new System.Drawing.Size(44, 20);
            this.agingVelocityInput.TabIndex = 5;
            this.agingVelocityInput.Text = "1";
            this.agingVelocityInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Aging Velocity";
            // 
            // newPerFramePanel
            // 
            this.newPerFramePanel.Controls.Add(this.newPerFrameRand);
            this.newPerFramePanel.Controls.Add(this.newPerFrameExact);
            this.newPerFramePanel.Controls.Add(this.newParticlesInput);
            this.newPerFramePanel.Controls.Add(this.label6);
            this.newPerFramePanel.Location = new System.Drawing.Point(6, 53);
            this.newPerFramePanel.Name = "newPerFramePanel";
            this.newPerFramePanel.Size = new System.Drawing.Size(458, 28);
            this.newPerFramePanel.TabIndex = 13;
            // 
            // newPerFrameRand
            // 
            this.newPerFrameRand.AutoSize = true;
            this.newPerFrameRand.Location = new System.Drawing.Point(305, 5);
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
            this.newPerFrameExact.Location = new System.Drawing.Point(210, 5);
            this.newPerFrameExact.Name = "newPerFrameExact";
            this.newPerFrameExact.Size = new System.Drawing.Size(89, 17);
            this.newPerFrameExact.TabIndex = 8;
            this.newPerFrameExact.TabStop = true;
            this.newPerFrameExact.Text = "exact amount";
            this.newPerFrameExact.UseVisualStyleBackColor = true;
            // 
            // newParticlesInput
            // 
            this.newParticlesInput.Location = new System.Drawing.Point(146, 4);
            this.newParticlesInput.Name = "newParticlesInput";
            this.newParticlesInput.Size = new System.Drawing.Size(44, 20);
            this.newParticlesInput.TabIndex = 5;
            this.newParticlesInput.Text = "10";
            this.newParticlesInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "New particles per frame";
            // 
            // lifetimePanel
            // 
            this.lifetimePanel.Controls.Add(this.lifetimeExact);
            this.lifetimePanel.Controls.Add(this.lifetimeRand);
            this.lifetimePanel.Controls.Add(this.lifetimeInput);
            this.lifetimePanel.Controls.Add(this.label2);
            this.lifetimePanel.Location = new System.Drawing.Point(6, 87);
            this.lifetimePanel.Name = "lifetimePanel";
            this.lifetimePanel.Size = new System.Drawing.Size(458, 28);
            this.lifetimePanel.TabIndex = 13;
            // 
            // lifetimeExact
            // 
            this.lifetimeExact.AutoSize = true;
            this.lifetimeExact.Checked = true;
            this.lifetimeExact.Location = new System.Drawing.Point(210, 5);
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
            this.lifetimeRand.Location = new System.Drawing.Point(305, 5);
            this.lifetimeRand.Name = "lifetimeRand";
            this.lifetimeRand.Size = new System.Drawing.Size(107, 17);
            this.lifetimeRand.TabIndex = 4;
            this.lifetimeRand.Text = "random (0, value)";
            this.lifetimeRand.UseVisualStyleBackColor = true;
            // 
            // velocityPanel
            // 
            this.velocityPanel.Controls.Add(this.velocityRand);
            this.velocityPanel.Controls.Add(this.velocityExact);
            this.velocityPanel.Controls.Add(this.velocityInput);
            this.velocityPanel.Controls.Add(this.label3);
            this.velocityPanel.Location = new System.Drawing.Point(6, 155);
            this.velocityPanel.Name = "velocityPanel";
            this.velocityPanel.Size = new System.Drawing.Size(458, 28);
            this.velocityPanel.TabIndex = 12;
            // 
            // velocityRand
            // 
            this.velocityRand.AutoSize = true;
            this.velocityRand.Location = new System.Drawing.Point(305, 5);
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
            this.velocityExact.Location = new System.Drawing.Point(210, 5);
            this.velocityExact.Name = "velocityExact";
            this.velocityExact.Size = new System.Drawing.Size(89, 17);
            this.velocityExact.TabIndex = 8;
            this.velocityExact.TabStop = true;
            this.velocityExact.Text = "exact amount";
            this.velocityExact.UseVisualStyleBackColor = true;
            // 
            // amountPanel
            // 
            this.amountPanel.Controls.Add(this.initialAmountInput);
            this.amountPanel.Controls.Add(this.label1);
            this.amountPanel.Location = new System.Drawing.Point(6, 19);
            this.amountPanel.Name = "amountPanel";
            this.amountPanel.Size = new System.Drawing.Size(458, 28);
            this.amountPanel.TabIndex = 11;
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
            // particleSystemSettingsPanel
            // 
            this.particleSystemSettingsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.particleSystemSettingsPanel.Location = new System.Drawing.Point(6, 19);
            this.particleSystemSettingsPanel.Name = "particleSystemSettingsPanel";
            this.particleSystemSettingsPanel.Size = new System.Drawing.Size(437, 209);
            this.particleSystemSettingsPanel.TabIndex = 0;
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
            this.ageVelocityPanel.ResumeLayout(false);
            this.ageVelocityPanel.PerformLayout();
            this.newPerFramePanel.ResumeLayout(false);
            this.newPerFramePanel.PerformLayout();
            this.lifetimePanel.ResumeLayout(false);
            this.lifetimePanel.PerformLayout();
            this.velocityPanel.ResumeLayout(false);
            this.velocityPanel.PerformLayout();
            this.amountPanel.ResumeLayout(false);
            this.amountPanel.PerformLayout();
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
        private System.Windows.Forms.Panel lifetimePanel;
        private System.Windows.Forms.RadioButton lifetimeExact;
        private System.Windows.Forms.RadioButton lifetimeRand;
        private System.Windows.Forms.Panel velocityPanel;
        private System.Windows.Forms.RadioButton velocityRand;
        private System.Windows.Forms.RadioButton velocityExact;
        private System.Windows.Forms.Panel amountPanel;
        private System.Windows.Forms.Panel newPerFramePanel;
        private System.Windows.Forms.RadioButton newPerFrameRand;
        private System.Windows.Forms.RadioButton newPerFrameExact;
        private System.Windows.Forms.TextBox newParticlesInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel ageVelocityPanel;
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


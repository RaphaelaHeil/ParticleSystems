using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ParticleSystems.SettingsPanels
{
    public partial class AirFlowUserSettings : ParticleSystemSettingsPanel {

        public AirFlowUserSettings()
        {
            InitializeComponent(); 
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.colorIndicator = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkVortex = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkInteraction = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.colorIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // colorDialog
            // 
            this.colorDialog.Color = System.Drawing.Color.Gray;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "! The background assumes the complementary color !";
            // 
            // colorIndicator
            // 
            this.colorIndicator.BackColor = this.colorDialog.Color;
            this.colorIndicator.Location = new System.Drawing.Point(45, 5);
            this.colorIndicator.Name = "colorIndicator";
            this.colorIndicator.Size = new System.Drawing.Size(20, 20);
            this.colorIndicator.TabIndex = 2;
            this.colorIndicator.TabStop = false;
            this.colorIndicator.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorIndicator_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Color:";
            // 
            // checkVortex
            // 
            this.checkVortex.AutoSize = true;
            this.checkVortex.Location = new System.Drawing.Point(13, 31);
            this.checkVortex.Name = "checkVortex";
            this.checkVortex.Size = new System.Drawing.Size(56, 17);
            this.checkVortex.TabIndex = 6;
            this.checkVortex.Text = "Vortex";
            this.checkVortex.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // checkInteraction
            // 
            this.checkInteraction.AutoSize = true;
            this.checkInteraction.Checked = true;
            this.checkInteraction.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkInteraction.Location = new System.Drawing.Point(13, 54);
            this.checkInteraction.Name = "checkInteraction";
            this.checkInteraction.Size = new System.Drawing.Size(76, 17);
            this.checkInteraction.TabIndex = 7;
            this.checkInteraction.Text = "Interaction";
            this.checkInteraction.UseVisualStyleBackColor = true;
            // 
            // AirFlowUserSettings
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.checkInteraction);
            this.Controls.Add(this.checkVortex);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.colorIndicator);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(6, 16);
            this.Name = "AirFlowUserSettings";
            ((System.ComponentModel.ISupportInitialize)(this.colorIndicator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public Color getColor()
        {
            return this.colorIndicator.BackColor;
        }

        public bool GetVortex()
        {
            if (this.checkVortex.Checked)
                return true;
            else
                return false;
        }

        public bool GetInteraction()
        {
            if (this.checkInteraction.Checked)
                return true;
            else
                return false;
        }

        private void colorIndicator_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.colorIndicator.BackColor = this.colorDialog.Color;
            }
        }

    }
}

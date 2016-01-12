using System.Drawing;
using System.Windows.Forms;

namespace ParticleSystems
{
    public partial class AirFlowUserSettings : ParticleSystemSettingsPanel {
        public AirFlowUserSettings()
        {
            InitializeComponent(); 
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.colorIndicator = new System.Windows.Forms.PictureBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.colorIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Color:";
            // 
            // colorIndicator
            // 
            this.colorIndicator.BackColor = this.colorDialog.Color;
            this.colorIndicator.Location = new System.Drawing.Point(38, 5);
            this.colorIndicator.Name = "colorIndicator";
            this.colorIndicator.Size = new System.Drawing.Size(20, 20);
            this.colorIndicator.TabIndex = 2;
            this.colorIndicator.TabStop = false;
            this.colorIndicator.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorIndicator_MouseClick);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(362, 5);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 4;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.resetButton_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "! The background assumes the complementary color !";
            // 
            // AirFlowUserSettings
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.resetButton);
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

        private void resetButton_MouseClick(object sender, MouseEventArgs e)
        {
            //ToDo: Reset the drawing-area
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

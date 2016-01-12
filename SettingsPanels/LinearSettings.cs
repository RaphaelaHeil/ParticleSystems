using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystems.SettingsPanels
{
    class LinearSettings : ParticleSystemSettingsPanel
    {
        private System.Windows.Forms.TextBox xDirectionInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox yDirectionInput;

        public LinearSettings()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.yDirectionInput = new System.Windows.Forms.TextBox();
            this.xDirectionInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // yDirectionInput
            // 
            this.yDirectionInput.Location = new System.Drawing.Point(221, 117);
            this.yDirectionInput.Name = "yDirectionInput";
            this.yDirectionInput.Size = new System.Drawing.Size(100, 20);
            this.yDirectionInput.TabIndex = 0;
            // 
            // xDirectionInput
            // 
            this.xDirectionInput.Location = new System.Drawing.Point(221, 67);
            this.xDirectionInput.Name = "xDirectionInput";
            this.xDirectionInput.Size = new System.Drawing.Size(100, 20);
            this.xDirectionInput.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "X direction change:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y direction change:";
            // 
            // LinearSettings
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.xDirectionInput);
            this.Controls.Add(this.yDirectionInput);
            this.Name = "LinearSettings";
            this.Size = this.Size;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public double GetXDirectionChange()
        {
            if (this.xDirectionInput.Text != "")
                return double.Parse(this.xDirectionInput.Text);
            else
                return 0;
        }

        public double GetYDirectionChange()
        {
            if (this.yDirectionInput.Text != "")
                return double.Parse(this.yDirectionInput.Text);
            else
                return 0;
        }
    }
}

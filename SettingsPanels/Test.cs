using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystems
{
    class Test : ParticleSystemSettingsPanel
    {
        private System.Windows.Forms.Label label1;

        public Test()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Size = base.Size;

            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // Test
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(6, 16);
            this.Name = "Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

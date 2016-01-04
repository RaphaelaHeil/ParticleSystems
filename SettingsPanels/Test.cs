using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystems
{
    class Test : ParticleSystemSettingsPanel
    {
        private System.Windows.Forms.GroupBox groupBox1;

        public Test()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Test
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Location = new System.Drawing.Point(6, 16);
            this.Name = "Test";
            this.ResumeLayout(false);

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParticleSystems
{
    public partial class ParticleSystemSettingsPanel : UserControl
    {
        public ParticleSystemSettingsPanel()
        {
            InitializeComponent(); 
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ParticleSystemSettingsPanel
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Location = new System.Drawing.Point(9, 16);
            this.Name = "ParticleSystemSettingsPanel";
            this.Size = new System.Drawing.Size(437, 209);
            this.ResumeLayout(false);

        }
    }
}

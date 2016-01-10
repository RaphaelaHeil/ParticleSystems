using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystems
{
    public partial class AirFlowUserSettings : ParticleSystemSettingsPanel {
        public AirFlowUserSettings()
        {
            InitializeComponent(); 
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // WindSimulationUserSettings
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Location = new System.Drawing.Point(6, 16);
            this.Name = "WindSimulationUserSettings";
            this.ResumeLayout(false);
        }
    }
}

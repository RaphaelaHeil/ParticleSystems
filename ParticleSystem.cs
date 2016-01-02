using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParticleSystems
{
    /// <summary>
    /// Abstract base class for all particle systems. Provides frame counter and default ParticleSystemSettingsPanel.
    /// </summary>
    abstract class ParticleSystem
    {

        protected ParticleSystemSettingsPanel panel = new ParticleSystemSettingsPanel();
        private long handledFramesCount = 0;
        //private bool frameBuildingInProgress = false;
        //private bool frameRenderingInProgress = false;
        

        /// <returns>The number of successfully rendered frames.</returns>
        public long GetFrameCount()
        {
            return handledFramesCount;
        }

        public void PrepareFrame()
        {
            //if (!frameBuildingInProgress)
            //{
            //    frameBuildingInProgress = true;
                BuildFrame();
            //}
        }

        /// <summary>
        /// Renders the currently active frame.
        /// </summary>
        public void RenderFrame()
        { 
            DrawFrame();
            //frameInProgess = false;
            handledFramesCount++;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ParticleSystemSettingsPanel GetParticleSystemSettingsPanel()
        {
            return panel;
        }

        public abstract String GetDescription();

        public abstract void Initialise();

        /// <summary>
        /// 
        /// </summary>
        protected abstract void BuildFrame();

        protected abstract void DrawFrame();

        

        
    }
}

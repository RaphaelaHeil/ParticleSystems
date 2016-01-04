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
        private long handledFramesCount = 0;

        protected Context context;
        protected ParticleSystemSettingsPanel panel = new ParticleSystemSettingsPanel();

        private bool frameBuildingInProgress = false;
        private bool frameRenderingInProgress = false;

        /// <returns>The number of successfully rendered frames.</returns>
        public long GetFrameCount()
        {
            return handledFramesCount;
        }

        public void PrepareFrame()
        {
            if (frameBuildingInProgress || frameRenderingInProgress)
            {
                return;
            }else
            {
                frameBuildingInProgress = true;
                //chpt. 7.3, p.206
                //slighlty changed the execution order to e.g. be able to create as many new particles as were removed

                DecrementLifetime();
                RemoveExpiredParticles();
                GenerateNewParticles();
                UpdateParticlePositions();
              
                frameBuildingInProgress = false;
               // handledFramesCount++;
            }
        }

        public void PrepareVBO()
        {

        }

        /// <summary>
        /// Renders the currently active frame.
        /// </summary>
        public void RenderFrame()
        {
            if (frameBuildingInProgress || frameRenderingInProgress)
            {
                return;
            }
            else
            {
                frameRenderingInProgress = true;
                DrawFrame();
                frameRenderingInProgress = false;
            }

            //  if()
            
            //frameInProgess = false;
          //  handledFramesCount++;
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

        public abstract void Initialise(ParticleSettings settings, Context context);

        protected abstract void DecrementLifetime();

        protected abstract void RemoveExpiredParticles();

        protected abstract void GenerateNewParticles();

        protected abstract void UpdateParticlePositions();

        protected abstract void BuildVBO();

        protected abstract void DrawFrame();

    }
}

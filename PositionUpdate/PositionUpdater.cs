using ParticleSystems.Particles;
using ParticleSystems.SettingsPanels;
using System.Collections.Generic;

namespace ParticleSystems.PositionUpdate
{

    /// <summary>
    /// Interface to group position updaters.
    /// </summary>
    interface PositionUpdater
    {

        /// <summary>
        /// Update the positions of the given particles.
        /// </summary>
        /// <param name="particles">Particles to be updated</param>
        void UpdatePositions(List<Particle> particles);
        void SetContext(Context context);
        void SetSettingsPanel(ParticleSystemSettingsPanel settingsPanel);
    }
}

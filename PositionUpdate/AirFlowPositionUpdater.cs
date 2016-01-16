using System;
using System.Collections.Generic;
using OpenTK;
using ParticleSystems.Particles;

namespace ParticleSystems.PositionUpdate
{

    /// <summary>
    /// Linearily translates particle positions.
    /// </summary>
    class AirFlowPositionUpdater : PositionUpdater
    {
        private Context context;
        private const int DEFAULT_DELTA = 1;
        private Vector2d TranslationX;
        private Vector2d TranslationYup;
        private Vector2d TranslationYdown;

        /// <summary>
        /// Default constructor, sets x and y updates to 1 each.
        /// </summary>
        public AirFlowPositionUpdater()
        {
            TranslationX = new Vector2d(DEFAULT_DELTA, 0);
            TranslationYup = new Vector2d(0, DEFAULT_DELTA);
            TranslationYdown = new Vector2d(0, -DEFAULT_DELTA);
        }

        /// <see cref="PositionUpdater.UpdatePositions(List{Particle})"/>
        public void UpdatePositions(List<Particle> particles)
        {
            List<PlaceableObject> placableObjectList = context.getPlacableObjectList();
            foreach (var particle in particles) {
                int particlePosX = (int)particle.GetPosition().X;
                int particlePosY = (int)particle.GetPosition().Y;

                Vector2d Translation = passObstacles(particlePosX, particlePosY, placableObjectList);
                particle.updatePosition(Translation);
            }
        }

        private Vector2d passObstacles(int particlePosX, int particlePosY, List<PlaceableObject> placableObjectList) {
            Vector2d Translation = new Vector2d();
            if (placableObjectList.Count != 0) {
                foreach (PlaceableObject po in placableObjectList) {
                    int poPosX = (int)(po.getPosition().X - (po.getSize().X / 2));
                    int crossRange = (int)(po.getPosition().X + (po.getSize().X / 2)); //range to cross the object

                    int poPosY = (int)po.getPosition().Y;
                    int up = (int)(poPosY - (po.getSize().Y / 2));
                    int down = (int)(poPosY + (po.getSize().Y / 2));

                    if ((particlePosX <= poPosX && particlePosX >= poPosX - 20) &&
                         (particlePosY >= up && particlePosY <= down)) {
                        if (particlePosY >= poPosY) {
                            Translation = TranslationYup;
                            break;
                        }
                        else {
                            Translation = TranslationYdown;
                            break;
                        }
                    }
                    else
                        Translation = TranslationX;
                }
            }
            else
                Translation = TranslationX;

            return Translation;
        }

        public void SetContext(Context context) {
            this.context = context;
        }
    }
}

using System;
using System.Collections.Generic;
using OpenTK;
using ParticleSystems.Particles;
using ParticleSystems.SettingsPanels;

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
        private Vector4d[,] GridArray;
        private AirParticle[,] AirParticleArray;

        private AirFlowUserSettings airFlowSettings;

        private Random Random = new Random();
        /// <summary>
        /// Default constructor, sets x and y updates to 1 each.
        /// </summary>
        public AirFlowPositionUpdater()
        {
            TranslationX = new Vector2d(DEFAULT_DELTA, 0);
            TranslationYup = new Vector2d(0, DEFAULT_DELTA);
            TranslationYdown = new Vector2d(0, -DEFAULT_DELTA);
        }


        public void UpdateAirPositions(List<AirParticle> particles)
        {
            Vector2d Position;
            Vector2d Translation = new Vector2d(DEFAULT_DELTA, 0);

            List<PlaceableObject> placableObjectList = context.getPlacableObjectList();
            
            foreach (var particle in particles) {
                if (particle.GetMaxLifetime() == 0)
                    particle.SetMaxLifetime(particle.GetRemainingLifetime() + 1);
                if (particle.GetStartingPosition().X == 0 && particle.GetStartingPosition().Y == 0)
                    particle.SetStartingPosition(particle.GetPosition());

                double particlePosX = particle.GetPosition().X;
                double particlePosY = particle.GetPosition().Y;

                if (airFlowSettings.GetVortex())
                {
                    double offset = particle.GetVelocity() * 4;
                    //Position = passVortex(particlePosX, particlePosY, placableObjectList, (int)offset);
                    Position = ineraction(particlePosX, particlePosY, particle, particles);
                }
                    
                else
                {
                    Translation = passObstacles((int)particlePosX, (int)particlePosY, placableObjectList);
                    //Position = new Vector2d(particlePosX, particlePosY);
                    Position = ineraction(particlePosX, particlePosY, particle, particles);
                }
                   
                if (particle.GetRemainingLifetime() == 5)
                {
                    Position = Vector2d.Add(particle.GetStartingPosition(), Translation * particle.GetVelocity());
                    particle.SetRemainingLifetime(particle.GetMaxLifetime());
                }
                    
                else
                    Position = Vector2d.Add(Position, Translation * particle.GetVelocity());

                particle.SetPosition(Position);
            }
        }

        private Vector2d ineraction(double pPosX, double pPosY, AirParticle curentParticle, List<AirParticle> particles) {
            Vector2d Position = new Vector2d(pPosX + 1, pPosY);
            foreach (AirParticle particle in particles) {
                double otherParticePosX = particle.GetPosition().X;
                double otherParticePosY = particle.GetPosition().Y;
                int range = 5;
                if (!curentParticle.Equals(particle)) {
                    if ( (pPosY <= otherParticePosY + range && pPosY >= otherParticePosY - range) &&
                       (pPosX <= otherParticePosX + range && pPosX >= otherParticePosX - range) )
                    {
                        if(pPosY < otherParticePosY)
                            Position = new Vector2d(pPosX + 1, pPosY + 2);
                        else if (pPosY >= otherParticePosY)
                            Position = new Vector2d(pPosX + 1, pPosY - 2);


                        if(pPosX < otherParticePosX)
                            Position = new Vector2d(pPosX + 2, Position.Y);
                        else if (pPosX >= otherParticePosX)
                            Position = new Vector2d(pPosX - 2, Position.Y);
                    }
                }
            }
            return Position;
        }

        private Vector2d passVortex(double pPosX, double pPosY, List<PlaceableObject> placableObjectList, int offset)
        {
            Vector2d Position = new Vector2d();
            if (placableObjectList.Count != 0)
            {
                foreach (PlaceableObject po in placableObjectList)
                {
                    int left = (int)(po.getPosition().X - (po.getSize().X / 2));
                    int right = (int)(po.getPosition().X + (po.getSize().X / 2));
                    int top = (int)(po.getPosition().Y - (po.getSize().Y / 2));
                    int bottom = (int)(po.getPosition().Y + (po.getSize().Y / 2));

                    if ((pPosX >= left && pPosX <= right) &&
                         (pPosY >= top && pPosY <= bottom ))
                    {
                        Vector2d middle = po.getPosition();
                        double change = 0.5;
                        //under left edge
                        if (pPosX < middle.X && pPosY > middle.Y) {
                            Position = new Vector2d(pPosX +1, pPosY + change);
                        }
                        //under right edge
                        else if (pPosX > middle.X && pPosY > middle.Y) {
                            Position = new Vector2d(pPosX + 1, pPosY - change);
                        }
                        //upper left edge
                        else if (pPosX < middle.X && pPosY < middle.Y) {
                            Position = new Vector2d(pPosX + 1, pPosY - change);
                        }
                        //right left edge
                        else if (pPosX > middle.X && pPosY < middle.Y) {
                            Position = new Vector2d(pPosX + 1, pPosY + change);
                        }
                    }
                    else
                        Position = new Vector2d(pPosX, pPosY);
                }
            }
            else
                Position = new Vector2d(pPosX, pPosY);
            return Position;
        }

        private Vector2d passObstacles(int pPosX, int pPosY, List<PlaceableObject> placableObjectList) {
            Vector2d Translation = new Vector2d();
            if (placableObjectList.Count != 0) {
                foreach (PlaceableObject po in placableObjectList) {
                    int left = (int)(po.getPosition().X - (po.getSize().X / 2));
                    int right = (int)(po.getPosition().X + (po.getSize().X / 2));
                    int top = (int)(po.getPosition().Y - (po.getSize().Y / 2));
                    int bottom = (int)(po.getPosition().Y + (po.getSize().Y / 2));

                    int poPosY = (int)po.getPosition().Y;

                    if ((pPosX >= left && pPosX <= right) &&
                         (pPosY >= top && pPosY <= bottom))
                    {
                        if (pPosY >= poPosY) {
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

        public void SetGridArray(Vector4d[,] GridArray) {
            this.GridArray = GridArray;
        }

        public void SetAirParticleArray(AirParticle[,] AirParticleArray) {
            this.AirParticleArray = AirParticleArray;
        }

        public void SetSettingsPanel(ParticleSystemSettingsPanel settingsPanel)
        {
            this.airFlowSettings = (AirFlowUserSettings)settingsPanel;
        }

        public void UpdatePositions(List<Particle> particles)
        {
            // substituted by custom method signature to avoid casting :) 
            throw new NotImplementedException("Not implemented. Use custom implementation with explicit List of AirParticles!");
        }
    }
}

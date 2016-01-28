using System;
using System.Collections.Generic;
using OpenTK;
using ParticleSystems.Particles;
using ParticleSystems.SettingsPanels;

namespace ParticleSystems.PositionUpdate
{

    /// <summary>
    /// Updates the position of the airflow particles.
    /// </summary>
    class AirFlowPositionUpdater : PositionUpdater
    {
        private Context context;
        private const int DEFAULT_DELTA = 1;
        private Vector2d TranslationX;
        private Vector2d TranslationYup;
        private Vector2d TranslationYdown;

        private ParticleGrid<AirParticle> ParticleGrid;
        List<AirParticle>[,] ParticleGridArrayList;
        List<PlaceableObject> placableObjectList;

        int range;
        int repel;
        int columnSize;
        int rowSize;
        int fieldSize;

        bool randomRepel;
        bool randomRange;

        bool vortex;
        bool interaction;
        private Random Random = new Random();

        /// <summary>
        /// Constructor for the AirFlowPositionUpdater.
        /// Sets the X, Up and Down transitions.
        /// </summary>
        public AirFlowPositionUpdater()
        {
            TranslationX = new Vector2d(DEFAULT_DELTA, 0);
            TranslationYup = new Vector2d(0, DEFAULT_DELTA);
            TranslationYdown = new Vector2d(0, -DEFAULT_DELTA);
        }

        /// <summary>
        /// Updates the position of the airflow particles.
        /// Handles the interaction with the placable objects.
        /// Handles the interaction with the particles among themselves.
        /// </summary>
        /// <param name="particles"></param>
        public void UpdateAirPositions(List<AirParticle> particles)
        {
            Vector2d Position;
            Vector2d Translation = new Vector2d(DEFAULT_DELTA, 0);

            //sets the random values for range and repel
            if (randomRepel)
                repel = Random.Next(0, repel);
            if (randomRange)
                range = Random.Next(0, range);

            //calls the update method from the ParticleGrid.
            //ParticleGridArrayList = ParticleGrid.updateParticleGridArrayListWithCheckingNeightburs(particles);
            ParticleGridArrayList = ParticleGrid.updateParticleGridArrayListWithNewList(particles);

            foreach (var particle in particles)
            {
                //gets the positon of the current particle
                double particlePosX = particle.GetPosition().X;
                double particlePosY = particle.GetPosition().Y;

                //checks if the vortex is enabled
                if (vortex)
                {
                    //sets an offset for the vortex
                    double offset = particle.GetVelocity() * 4;
                    //cheks if the particle interaction is enabled
                    if (interaction)
                        Position = ineraction(particlePosX, particlePosY, particle);
                    else
                        Position = new Vector2d(particlePosX, particlePosY);
                    //calls the passVortex method and saves the returned position in the Position variable
                    Position = passVortex(Position.X, Position.Y, (int)offset);
                }
                //if vortex isnt set, interac with the placable object normaly
                else
                {
                    if (interaction)
                        Position = ineraction(particlePosX, particlePosY, particle);
                    else
                        Position = new Vector2d(particlePosX, particlePosY);
                    //calls the passObstacles method and saves the returned values as the transition
                    Translation = passObstacles((int)Position.X, (int)Position.Y);
                }
                //set the new particle position
                particle.SetPosition(Position);
                //update the position with the new transition
                particle.updatePosition(Translation);
            }
        }

        /// <summary>
        /// Handles the interaction with the particles among themselves.
        /// </summary>
        /// <param name="pPosX"></param>
        /// <param name="pPosY"></param>
        /// <param name="curentParticle"></param>
        /// <returns></returns>
        private Vector2d ineraction(double pPosX, double pPosY, AirParticle curentParticle)
        {
            int column = (int)(pPosX / fieldSize); //get the column index by deviding the current postition of the current particle with the fieldsize (pos = 10 / fieldsize = 50 == rounded 0)
            int row = (int)(pPosY / fieldSize); //get the row index by deviding the current postition of the current particle with the fieldsize

            Vector2d Position = new Vector2d(pPosX + 1, pPosY); //default value for the position

            //cheks if the particle position X is greater than 0
            if (pPosX > 0)
            {
                //cheks if the current postition of the current particle is in one the particle grids field
                if (column < columnSize && row < rowSize)
                {
                    //iterates throgh the particles in the particle grid array list
                    foreach (AirParticle particle in ParticleGridArrayList[column, row])
                    {
                        double otherParticePosX = particle.GetPosition().X; //get the position of the partile that is not the current
                        double otherParticePosY = particle.GetPosition().Y;

                        //checks if the particle not equals the current
                        if (!curentParticle.Equals(particle))
                        {
                            //cheks if the current particle is in the range of an other particle in the list
                            if ((pPosY <= otherParticePosY + range && pPosY >= otherParticePosY - range) &&
                               (pPosX <= otherParticePosX + range && pPosX >= otherParticePosX - range))
                            {
                                //checks if the current particle Y position is smaler that Y position of the other particle
                                if (pPosY < otherParticePosY)
                                {
                                    //if so, move the particle downwards
                                    Position = new Vector2d(pPosX + 1, pPosY + repel);
                                    if ((pPosY + 2) > context.GetIdHolder().Height)
                                        Position = new Vector2d(pPosX + 1, pPosY - repel);
                                }
                                // checks if the current particle Y position is equal or greater than the Y position of the other particle
                                else if (pPosY >= otherParticePosY)
                                {
                                    //if so, move the particle upwards
                                    Position = new Vector2d(pPosX + 1, pPosY - repel);
                                    if ((pPosY - 2) < 0)
                                        Position = new Vector2d(pPosX + 1, pPosY + repel);
                                }
                                //checks if the current particle X position is smaler that X position of the other particle
                                if (pPosX < otherParticePosX)
                                {
                                    //if so, move the particle forward
                                    Position = new Vector2d(pPosX + repel, Position.Y);
                                    if ((pPosX + 2) > context.GetIdHolder().Width)
                                        Position = new Vector2d(pPosX - repel, Position.Y);
                                }
                                // checks if the current particle X position is equal or greater than the X position of the other particle
                                else if (pPosX >= otherParticePosX)
                                {
                                    //if so, move the particle backwards
                                    Position = new Vector2d(pPosX - repel, Position.Y);
                                    if ((pPosX - 2) < 0)
                                        Position = new Vector2d(pPosX + repel, Position.Y);
                                }
                            }
                        }
                    }
                }
            }
            return Position;
        }

        /// <summary>
        /// Changes the position of the particles that are influenced by the placable object.
        /// Moves the particles in a diamond shape.
        /// </summary>
        /// <param name="pPosX"></param>
        /// <param name="pPosY"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        private Vector2d passVortex(double pPosX, double pPosY, int offset)
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
                         (pPosY >= top && pPosY <= bottom))
                    {

                        Vector2d middle = po.getPosition();
                        double change = 1;
                        //under left edge
                        if (pPosX < middle.X && pPosY > middle.Y)
                        {
                            Position = new Vector2d(pPosX + 1, pPosY + change);
                        }
                        //under right edge
                        else if (pPosX > middle.X && pPosY > middle.Y)
                        {
                            Position = new Vector2d(pPosX + 1, pPosY - change);
                        }
                        //upper left edge
                        else if (pPosX < middle.X && pPosY < middle.Y)
                        {
                            Position = new Vector2d(pPosX + 1, pPosY - change);
                        }
                        //right left edge
                        else if (pPosX > middle.X && pPosY < middle.Y)
                        {
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

        /// <summary>
        /// Changes the position of the particles that are influenced by the placable object.
        /// Moves the particles alnong the placable object insted of passing throgh.
        /// </summary>
        /// <param name="pPosX"></param>
        /// <param name="pPosY"></param>
        /// <returns></returns>
        private Vector2d passObstacles(int pPosX, int pPosY)
        {
            Vector2d Translation = new Vector2d();
            if (placableObjectList.Count != 0)
            {
                foreach (PlaceableObject po in placableObjectList)
                {
                    int left = (int)(po.getPosition().X - (po.getSize().X / 2)) - ((range * repel) * 2);
                    int right = (int)(po.getPosition().X + (po.getSize().X / 2));
                    int top = (int)(po.getPosition().Y - (po.getSize().Y / 2)) - (range * repel);
                    int bottom = (int)(po.getPosition().Y + (po.getSize().Y / 2)) + (range * repel);

                    int poPosY = (int)po.getPosition().Y;

                    if ((pPosX >= left && pPosX <= right) &&
                         (pPosY >= top && pPosY <= bottom))
                    {
                        if (pPosY >= poPosY)
                        {
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

        /// <summary>
        /// Sets the particle gird object.
        /// Sets the column size, the row size and the fieldsize.
        /// </summary>
        /// <param name="particleGrid"></param>
        public void SetParticleGrid(ParticleGrid<AirParticle> particleGrid)
        {
            this.ParticleGrid = particleGrid;
            columnSize = ParticleGrid.GetGridColumnSize();
            rowSize = ParticleGrid.GetGridRowSize();
            fieldSize = ParticleGrid.GetFiieldSize();
        }

        /// <summary>
        /// Sets the settings panel object.
        /// Sets the range, the repel distance, and the vortex, random repel and the random range indicator.
        /// </summary>
        /// <param name="settingsPanel"></param>
        public void SetSettingsPanel(ParticleSystemSettingsPanel settingsPanel)
        {
            AirFlowUserSettings airFlowSettings = (AirFlowUserSettings)settingsPanel;
            range = airFlowSettings.getRange();
            repel = airFlowSettings.getRepel();
            vortex = airFlowSettings.GetVortex();
            interaction = airFlowSettings.GetInteraction();
            randomRepel = airFlowSettings.getRandomRepel();
            randomRange = airFlowSettings.getRandomRange();
        }

        /// <summary>
        /// Necessary method that fullfills no purpose.
        /// </summary>
        /// <param name="particles"></param>
        public void UpdatePositions(List<Particle> particles)
        {
            // substituted by custom method signature to avoid casting :) 
            throw new NotImplementedException("Not implemented. Use custom implementation with explicit List of AirParticles!");
        }

        /// <summary>
        /// Sets the context object.
        /// Sets the placable object list.
        /// </summary>
        /// <param name="context"></param>
        public void SetContext(Context context)
        {
            this.context = context;
            placableObjectList = context.getPlacableObjects();
        }
    }
}

using OpenTK;
using ParticleSystems.Particles;
using System.Collections.Generic;

namespace ParticleSystems
{
    /// <summary>
    /// Class to create a two-dimensional Particle Grid array list.
    /// Each array field contains a list with a possible amount of Particles in it.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class ParticleGrid<T> where T : Particle
    {
        private List<T>[,] ParticleGridArrayList;
        private Context Context;
        private int FieldSize;
        private int girdColumnSize;
        private int girdRowSize;

        /// <summary>
        /// Constructor for Particle Grid.
        /// Sets the context, with an otional FieldSize parameter for further use.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="optinalFieldSize"></param>
        public ParticleGrid(Context context, int optinalFieldSize = 50)
        {
            Context = context;
            FieldSize = optinalFieldSize;

            girdColumnSize = Context.GetIdHolder().Height / FieldSize;
            girdRowSize = Context.GetIdHolder().Width / FieldSize;

            CreateParticleGrid();
        }

        /// <summary>
        /// Creates and initializes the ParticleGrid array list.
        /// girdColumnSize and girdRowSize (size of the array),
        /// will be initialzed by the constructor.
        /// </summary>
        private void CreateParticleGrid()
        {
            ParticleGridArrayList = new List<T>[girdColumnSize, girdRowSize]; //12x12 Grid by glControlSize = 600
            for (int i = 0; i < girdColumnSize; i++)
            {
                for (int j = 0; j < girdRowSize; j++)
                {
                    ParticleGridArrayList[i, j] = new List<T>();
                }
            }
        }

        /// <summary>
        /// Update the particles in the ParticleGrid array list, and check,
        /// if the neightburs of the current grid contains the same particle.
        /// If so, the particle weill be removed from the current grid.
        /// Performace: low
        /// </summary>
        /// <param name="particles"></param>
        /// <returns></returns>
        public List<T>[,] updateParticleGridArrayListWithCheckingNeightburs(List<T> particles)
        {
            int column = 0;
            int row = 0;

            foreach (var particle in particles)
            {
                column = (int)(particle.GetPosition().X / FieldSize);
                row = (int)(particle.GetPosition().Y / FieldSize);

                //check if the current particle is in the range of the list
                if (column < girdColumnSize && row < girdRowSize)
                {
                    //check if the current particle is allready in the current list
                    if (ParticleGridArrayList[column, row].IndexOf(particle) == -1)
                    {
                        //add current particle to the current list
                        ParticleGridArrayList[column, row].Add(particle);
                        //check if the current particle is in one of the neightbur-grid of the current list
                        CheckNeighbours(column, row, particle);
                    }
                }
                //check if the particle position is outside the grid
                else if (column >= girdColumnSize || row >= girdRowSize)
                {
                    //column bigger than max and row bigger than max
                    if (column >= girdColumnSize && row >= girdRowSize)
                    {
                        //remove current particle from the current list
                        ParticleGridArrayList[girdColumnSize - 1, girdRowSize - 1].Remove(particle);
                    }
                    else if (column >= girdColumnSize)
                        ParticleGridArrayList[girdColumnSize - 1, row].Remove(particle);
                    else
                        ParticleGridArrayList[column, girdRowSize - 1].Remove(particle);
                }
            }
            return ParticleGridArrayList;
        }

        /// <summary>
        /// Update the particles in the ParticleGrid array list,
        /// by creatig a new empty list everytime, it is called. 
        /// Performace: middle
        /// </summary>
        /// <param name="particles"></param>
        /// <returns></returns>
        public List<T>[,] updateParticleGridArrayListWithNewList(List<T> particles)
        {
            //create a new empty grid array list
            CreateParticleGrid();
            int column = 0;
            int row = 0;
            foreach (var particle in particles)
            {
                column = (int)(particle.GetPosition().X / FieldSize);
                row = (int)(particle.GetPosition().Y / FieldSize);

                if (column < girdColumnSize && row < girdRowSize)
                {
                    if (ParticleGridArrayList[column, row].IndexOf(particle) == -1)
                    {

                        ParticleGridArrayList[column, row].Add(particle);
                    }
                }
                else if (column >= girdColumnSize || row >= girdRowSize)
                {
                    if (column >= girdColumnSize && row >= girdRowSize)
                    {
                        ParticleGridArrayList[girdColumnSize - 1, girdRowSize - 1].Remove(particle);
                    }
                    else if (column >= girdColumnSize)
                        ParticleGridArrayList[girdColumnSize - 1, row].Remove(particle);
                    else
                        ParticleGridArrayList[column, girdRowSize - 1].Remove(particle);
                }

            }
            return ParticleGridArrayList;
        }

        /// <summary>
        /// Check if the neightburs of the current Grid contains the same particle.
        /// If so, the particle in the current Grid weill be deleted from it.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="row"></param>
        /// <param name="particle"></param>
        private void CheckNeighbours(int column, int row, T particle)
        {
            List<Vector2d> removeList = new List<Vector2d>();
            int maxColumn = ParticleGridArrayList.GetLength(0) - 1;
            int maxRow = ParticleGridArrayList.GetLength(1) - 1;

            //check the possible neightburs of the current grid and put them into the remove list
            //upper left corner
            if (column == 0 && row == 0)
            {
                removeList.Add(new Vector2d(0, 1));
                removeList.Add(new Vector2d(1, 1));
                removeList.Add(new Vector2d(1, 0));
            }
            //upper right corner
            else if (column == maxColumn && row == 0)
            {
                removeList.Add(new Vector2d(maxColumn - 1, 0));
                removeList.Add(new Vector2d(maxColumn - 1, 1));
                removeList.Add(new Vector2d(maxColumn + 0, 1));
            }
            //lower right corner
            else if (column == maxColumn && row == maxRow)
            {
                removeList.Add(new Vector2d(maxColumn - 1, maxRow + 0));
                removeList.Add(new Vector2d(maxColumn - 1, maxRow - 1));
                removeList.Add(new Vector2d(maxColumn + 0, maxRow - 1));
            }
            //lower left corner
            else if (column == 0 && row == maxRow)
            {
                removeList.Add(new Vector2d(1, maxRow + 0));
                removeList.Add(new Vector2d(1, maxRow - 1));
                removeList.Add(new Vector2d(0, maxRow - 1));
            }
            //left side and right side
            else if (column == 0 || column == maxColumn)
            {
                int i = 1;
                if (column == maxColumn)
                    i = -1;
                removeList.Add(new Vector2d(column + 0, row - 1));
                removeList.Add(new Vector2d(column + i, row - 1));
                removeList.Add(new Vector2d(column + i, row + 0));
                removeList.Add(new Vector2d(column + i, row + 1));
                removeList.Add(new Vector2d(column + 0, row + 1));
            }
            //top side and bottom side
            else if (row == 0 || row == maxRow)
            {
                int i = 1;
                if (row == maxRow)
                    i = -1;
                removeList.Add(new Vector2d(column + 1, row + 0));
                removeList.Add(new Vector2d(column + 1, row + i));
                removeList.Add(new Vector2d(column + 0, row + i));
                removeList.Add(new Vector2d(column - 1, row + i));
                removeList.Add(new Vector2d(column - 1, row + 0));
            }
            else
            {
                removeList.Add(new Vector2d(column - 1, row - 1));
                removeList.Add(new Vector2d(column - 1, row + 0));
                removeList.Add(new Vector2d(column - 1, row + 1));
                removeList.Add(new Vector2d(column + 0, row - 1));
                removeList.Add(new Vector2d(column + 0, row + 1));
                removeList.Add(new Vector2d(column + 1, row - 1));
                removeList.Add(new Vector2d(column + 1, row + 0));
                removeList.Add(new Vector2d(column + 1, row + 1));
            }

            //interate thrugh the remove ist and check if the particle is in one of the neightbur-grids
            //if so, remove the particle from the current list
            foreach (Vector2d remove in removeList)
            {
                if (ParticleGridArrayList[(int)remove.X, (int)remove.Y].IndexOf(particle) != -1)
                    ParticleGridArrayList[(int)remove.X, (int)remove.Y].Remove(particle);
            }

        }

        /// <summary>
        /// Returns the ParticleGrid array list in its current state.
        /// </summary>
        /// <returns></returns>
        public List<T>[,] GetParticleGridArrayList()
        {
            return ParticleGridArrayList;
        }

        /// <summary>
        /// Returns the field size of the Grid (default value 50)
        /// </summary>
        /// <returns></returns>
        public int GetFiieldSize()
        {
            return this.FieldSize;
        }

        /// <summary>
        /// Returns the number of the columns in the Grid (default value 12)
        /// </summary>
        /// <returns></returns>
        public int GetGridColumnSize()
        {
            return girdColumnSize;
        }

        /// <summary>
        /// Returns the number of the rows in the Grid (default value 12)
        /// </summary>
        /// <returns></returns>
        public int GetGridRowSize()
        {
            return girdRowSize;
        }
    }


}

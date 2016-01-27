using OpenTK;
using ParticleSystems.Particles;
using System.Collections.Generic;

namespace ParticleSystems
{
    class ParticleGrid<T> where T : Particle
    {
        private List<T>[,] ParticleGridArrayList;
        private Context Context;
        private int FieldSize;
        private int girdColumnSize;
        private int girdRowSize;

        public ParticleGrid(Context context, int optinalFieldSize = 50)
        {
            Context = context;
            FieldSize = optinalFieldSize;

            girdColumnSize = Context.GetIdHolder().Height / FieldSize;
            girdRowSize = Context.GetIdHolder().Width / FieldSize;

            CreateParticleGrid();
        }

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

        public List<T>[,] updateParticleGridArrayListWithCheckingNeightburs(List<T> particles)
        {
            int column = 0;
            int row = 0;


            foreach(var particle in particles)
            {
                column = (int)(particle.GetPosition().X / FieldSize);
                row = (int)(particle.GetPosition().Y / FieldSize);

                if (column < girdColumnSize && row < girdRowSize)
                {
                    if (ParticleGridArrayList[column, row].IndexOf(particle) == -1)
                    {
                        ParticleGridArrayList[column, row].Add(particle);

                        CheckNeighbours(column, row, particle);
                    }
                }
                else if (column >= girdColumnSize)
                    ParticleGridArrayList[girdColumnSize - 1, row].Remove(particle);
                else if (row >= girdRowSize)
                    ParticleGridArrayList[column, girdRowSize - 1].Remove(particle);
            }
            return ParticleGridArrayList;
        }

        public List<T>[,] updateParticleGridArrayListWithNewList(List<T> particles)
        {
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
                    if(column >= girdColumnSize && row >= girdRowSize)
                    {
                        ParticleGridArrayList[girdColumnSize - 1, girdRowSize - 1].Remove(particle);
                    }
                    else if(column >= girdColumnSize)
                        ParticleGridArrayList[girdColumnSize - 1, row].Remove(particle);
                    else
                        ParticleGridArrayList[column, girdRowSize - 1].Remove(particle);
            }
            return ParticleGridArrayList;
        }

        private void CheckNeighbours(int column, int row, T particle)
        {
            List<Vector2d> removeList = new List<Vector2d>();
            int maxColumn = ParticleGridArrayList.GetLength(0) - 1;
            int maxRow = ParticleGridArrayList.GetLength(1) - 1;

            //upper left corner
            if (column == 0 && row == 0)
            {
                removeList.Add(new Vector2d(0, 1));
                removeList.Add(new Vector2d(1, 1));
                removeList.Add(new Vector2d(1, 0));
            }
            //upper right corner
            else if(column == maxColumn && row == 0)
            {
                removeList.Add(new Vector2d(maxColumn - 1,  0));
                removeList.Add(new Vector2d(maxColumn - 1,  1));
                removeList.Add(new Vector2d(maxColumn + 0,  1));
            }
            //lower right corner
            else if(column == maxColumn && row == maxRow)
            {
                removeList.Add(new Vector2d(maxColumn - 1, maxRow + 0));
                removeList.Add(new Vector2d(maxColumn - 1, maxRow - 1));
                removeList.Add(new Vector2d(maxColumn + 0, maxRow - 1));
            }
            //lower left corner
            else if (column == 0 && row == maxRow)
            {
                removeList.Add(new Vector2d( 1, maxRow + 0));
                removeList.Add(new Vector2d( 1, maxRow - 1));
                removeList.Add(new Vector2d( 0, maxRow - 1));
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

            foreach(Vector2d remove in removeList)
            {
                if (ParticleGridArrayList[(int)remove.X, (int)remove.Y].IndexOf(particle) != -1)
                    ParticleGridArrayList[(int)remove.X, (int)remove.Y].Remove(particle);
            }

        }



        public List<T>[,] GetParticleGridArrayList()
        {
            return ParticleGridArrayList;
        }

        public int GetFiieldSize()
        {
            return this.FieldSize;
        }

        public int GetGridColumnSize()
        {
            return girdColumnSize;
        }

        public int GetGridRowSize()
        {
            return girdRowSize;
        }
    }


}

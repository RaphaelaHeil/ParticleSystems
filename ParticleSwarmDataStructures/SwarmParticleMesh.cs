﻿using OpenTK;
using ParticleSystems.Particles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystems.ParticleSwarmDataStructures
{
    class SwarmParticleMesh
    {
        private List<SwarmParticle>[,] Mesh;
        private int CellSize;
        private int GridWidth;
        private int GridHeight;
        private int RowCount;
        private int ColumnCount;
        private int ParticleCount = 0;

        public SwarmParticleMesh(int cellSize = 10, int gridWidth = 600, int gridHeight = 600)
        {
            CellSize = cellSize;
            GridHeight = gridHeight;
            GridWidth = gridWidth;

            RowCount = GridHeight / CellSize;
            ColumnCount = GridWidth / CellSize;

            InitialiseMesh();
        }

        public SwarmParticleMesh(SwarmParticleMesh oldParticleMesh)
        {
            CellSize = oldParticleMesh.GetCellSize();
            GridHeight = oldParticleMesh.GetGridHeight();
            GridWidth = oldParticleMesh.GetGridWidth();

            RowCount = oldParticleMesh.GetRowCount();
            ColumnCount = oldParticleMesh.GetColumnCount();

            InitialiseMesh();
        }


        private void InitialiseMesh()
        {
            Mesh = new List<SwarmParticle>[RowCount, ColumnCount];
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    Mesh[i, j] = new List<SwarmParticle>();
                }
            }
        }

        public void AddParticle(SwarmParticle particle)
        {
            Tuple<int, int> cellIndices = ParticlePositionToCellIndices(particle.GetPosition());
            Mesh[cellIndices.Item1, cellIndices.Item2].Add(particle);
            ParticleCount++;
        }

        public void AddParticles(List<SwarmParticle> particles)
        {
            foreach (var particle in particles)
            {
                AddParticle(particle);
            }
        }

        public List<SwarmParticle> GetAdjacentParticlesWithoutGivenParticle(SwarmParticle particle)
        {
            Tuple<int, int> cellIndices = ParticlePositionToCellIndices(particle.GetPosition());
            List<SwarmParticle> neighbourhood = Mesh[cellIndices.Item1, cellIndices.Item2];
            neighbourhood.Remove(particle);
            return neighbourhood;
        }

        private Tuple<int, int> ParticlePositionToCellIndices(Vector2d position)
        {
            int column = (int)position.X / CellSize;
            int row = (int)position.Y / CellSize;

            if (column >= ColumnCount)
            {
                column -= ColumnCount;
            }
            if (row >= RowCount)
            {
                row -= RowCount;
            }
            return new Tuple<int, int>(row, column);
        }

        public List<SwarmParticle> GetListFromCell(int row, int column)
        {
            if (row < RowCount && column < ColumnCount)
            {
                return Mesh[row, column];
            }
            else
            {
                return new List<SwarmParticle>();
            }
        }

        public int GetRowCount()
        {
            return RowCount;
        }

        public int GetColumnCount()
        {
            return ColumnCount;
        }

        public int GetCellSize()
        {
            return CellSize;
        }

        public int GetGridWidth()
        {
            return GridWidth;
        }

        public int GetGridHeight()
        {
            return GridHeight;
        }

        public int GetParticleCount()
        {
            return ParticleCount;
        }
    }
}
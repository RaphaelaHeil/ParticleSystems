﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace ParticleSystems
{
    interface PositionUpdater
    {
        void UpdatePosition(Particle particle);

        void UpdatePositions(List<Particle> particles);
    }
}
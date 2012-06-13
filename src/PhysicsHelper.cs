using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TerraNullius
{
    class PhysicsHelper
    {
        private float phMaxVelocity;
        private float phAcceleration;

        public PhysicsHelper(float maxVelocity, float acceleration)
        {
            phMaxVelocity = maxVelocity;
            phAcceleration = acceleration;
        }

        public float falling(float phVelocity, float deltaT)
        {
            if (maxVelocity(phVelocity) == phMaxVelocity)
            {
                return phVelocity;
            }

            return (phVelocity + (phAcceleration * (deltaT / 1000)));
        }

        public float maxVelocity(float phVelocity)
        {
            return phVelocity;
        }
    }
}

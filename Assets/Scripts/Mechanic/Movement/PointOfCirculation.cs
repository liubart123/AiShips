using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Mechanic.Movement
{
    [Serializable]
    public class PointOfCirculation
    {
        public Vector2 centerOfCirculationCircle;
        /// <summary>
        /// Clockwise angle (in degrees) of point on circle, on which is finishing of circulation and start of direct movement.
        /// Starts from 3:00 counterclockwise direction
        /// </summary>
        public float endCirculationAngle;   
        /// <summary>
        /// Velocity during linear movement. During circulation velocity can be changed
        /// </summary>
        public float velocity;
        public float radiusOfCirculation;
    }
}

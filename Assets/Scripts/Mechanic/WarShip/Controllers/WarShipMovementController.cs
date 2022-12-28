using Assets.Scripts.Mechanic.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Mechanic.WarShip.Controllers
{
    [Serializable]
    public class WarShipMovementController : WarShipComponent
    {
        //CURRENT STATE OF MOVEMENT CONTROLLER
        [Range(0, 10)]
        public float currentVelocity;
        [Range(0, 10)]
        public float targetVelocity;
        /// <summary>
        /// Start from 3:00, counterclockwise. In Degree
        /// </summary>
        public float rotationAngle;
        /// <summary>
        /// [-1;1] range. Defines how fast direction is changed.
        /// 1 - clockwise,
        /// -1 - counterclockwise,
        /// 0 - no turning.
        /// </summary>
        [Range(-1, 1)]
        public float currentSteeringWheelState;

        //CONSTANT CHARACTERISTICS
        [Range(0, 1)]
        public float velocityChangePerTick;
        [Range(0, 1)]
        public float steerWheelChangingPerTick;
        [Range(0, 1)]
        public float maxAngleOfTurningPerTick;

        public virtual void DoTick()
        {

        }
    }
}

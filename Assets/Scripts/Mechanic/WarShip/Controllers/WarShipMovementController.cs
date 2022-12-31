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
        public float currentVelocity;
        public float targetVelocity;
        /// <summary>
        /// Start from 3:00, counterclockwise. In Degree
        /// </summary>
        public float currentRotationAngle;
        /// <summary>
        /// [-1;1] range. Defines how fast direction is changed.
        /// 1 - clockwise,
        /// -1 - counterclockwise,
        /// 0 - no turning.
        /// </summary>
        [Range(-1, 1)]
        public float currentSteeringWheelState;
        public float targetSteeringWheelState;
        public Vector2 currentPosition;

        //CONSTANT CHARACTERISTICS
        public float velocityChangePerTick;
        public float steerWheelChangePerTick;
        public float rateOfTurn;

        //GLOBAL CONSTANTS
        public float velocityMultiplier, turningRateMulitplier;

        public virtual void DoTick()
        {
            //Debug.Log($"MovementController Tick");
            Vector2 direction = new Vector2(
                Mathf.Cos(Mathf.PI * currentRotationAngle / 180),
                Mathf.Sin(Mathf.PI * currentRotationAngle / 180));
            currentPosition += direction * currentVelocity * velocityMultiplier;
            currentRotationAngle -= currentSteeringWheelState * rateOfTurn * turningRateMulitplier;

            currentVelocity = Mathf.Clamp(targetVelocity, currentVelocity - velocityChangePerTick, currentVelocity + velocityChangePerTick);
            currentSteeringWheelState = Mathf.Clamp(targetSteeringWheelState, currentSteeringWheelState - steerWheelChangePerTick, currentSteeringWheelState + steerWheelChangePerTick);
        }
    }
}

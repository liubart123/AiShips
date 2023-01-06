using Assets.Scripts.Mechanic.WarShip.Behavior;
using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Mechanic.Test
{
    [Serializable]
    public class NormalWsMovementBehavior : WarShipMovementBehavior
    {
        public float minDistanceForPerpendicularMovement;
        public float minAngleForMaxWheelSteering;
        public float targetVelocity = 10;
        [Header("Local fields for calculation")]
        public Vector2 shipPosition;
        public Vector2 shipDirection, pointC, vectorBC, targetDirectionOfMovement;
        public float angleCAB, distanceAB, distanceCB, angleDBC, targetRotationAngle;
        [Range(-1,1)]
        public float targetWheelingSteering;
        public override void DoMovementBehaviorTick()
        {
            shipPosition = WarShip.warShipMovementController.currentPosition;
            shipDirection = new Vector2(
                Mathf.Cos(WarShip.warShipMovementController.currentRotationAngle * Mathf.PI / 180),
                Mathf.Sin(WarShip.warShipMovementController.currentRotationAngle * Mathf.PI / 180));

            /*
              
            |
            |C     
            *------* B
            |     / \
            |    /   \
            |   /     \ 
            |  /       \
            | /         *D
            |/
            * A


            A - start position of movementVector
            AC - direction of movementVector
            B - position of ship
            BD - rotation of ship
            */

            angleCAB = Vector2.Angle(
                vectorOfMovement.direction,
                shipPosition - vectorOfMovement.startPosition);
            //if (angleCAB > 90)
            //    angleCAB = 180 - angleCAB;
            distanceAB = Vector2.Distance(shipPosition, vectorOfMovement.startPosition);
            distanceCB = Mathf.Sin(angleCAB * Mathf.PI / 180) * distanceAB;
            pointC = vectorOfMovement.startPosition + vectorOfMovement.direction.normalized * Mathf.Cos(angleCAB * Mathf.PI / 180) * distanceAB;
            angleDBC = Vector2.SignedAngle(shipDirection, shipPosition - pointC);

            Debug.DrawLine(pointC, shipPosition, Color.green, 0.1f);
            vectorBC = pointC - shipPosition;

            if (distanceCB > minDistanceForPerpendicularMovement)
            {
                targetDirectionOfMovement = vectorOfMovement.startPosition - shipPosition;
            } else
            {
                targetDirectionOfMovement = Vector2.Lerp(
                    vectorOfMovement.direction.normalized,
                    vectorBC.normalized,
                    distanceCB / minDistanceForPerpendicularMovement
                    );
            }

            targetRotationAngle = Vector2.SignedAngle(
                shipDirection, targetDirectionOfMovement);


            targetWheelingSteering = targetRotationAngle > 0 ? -1 : 1;
            targetWheelingSteering *= Mathf.Lerp(0, 1, Mathf.Abs(targetRotationAngle / minAngleForMaxWheelSteering));

            WarShip.warShipMovementController.targetSteeringWheelState = targetWheelingSteering;
            WarShip.warShipMovementController.targetVelocity = targetVelocity;

        }
    }
}
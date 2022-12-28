using Assets.Scripts.Mechanic.Main;
using Assets.Scripts.Mechanic.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Mechanic.Test
{
    [ExecuteInEditMode]
    public class TestPointOfCirculationUnityObject : MonoBehaviour
    {
        public PointOfCirculation pointOfCirculation;
        public WarShipUnityObject ship;
        public GameObject mask11, mask12, mask21, mask22;

        public void Update()
        {
            pointOfCirculation.centerOfCirculationCircle = transform.position;

            /*
            ________.____________________0
            |3    2/
            |     /
            |    /
            |   /
            |  /
            |1/
            |/____________________________A

            3 - 90 degree
            2 - center of circulation
            1 - ship
            */

            float angle1, angle2;

            Vector2 v13, v12, v23, point3;
            Vector2 shipPosition = new Vector2(ship.transform.position.x, ship.transform.position.y);
            v13 = new Vector2(Mathf.Cos(
                ship.warShip.warShipMovementController.rotationAngle * Mathf.PI / 180), 
                Mathf.Sin(ship.warShip.warShipMovementController.rotationAngle * Mathf.PI / 180));
            v12 = pointOfCirculation.centerOfCirculationCircle - shipPosition;
            angle1 = v13.ToDegreeAngle() - v12.ToDegreeAngle();
            angle1 = Mathf.Abs(angle1);
            point3 = Mathf.Cos(angle1 * Mathf.PI / 180) * v12.magnitude * v13.normalized;
            v23 = point3 - pointOfCirculation.centerOfCirculationCircle;
            float angle023 = v23.ToDegreeAngle();
            float angleA13 = v13.ToDegreeAngle();
            //Debug.Log($"v23:{v23}, angle023:{angle023}, angleA13:{angleA13}");

            mask11.transform.rotation = Quaternion.Euler(0, 0, angleA13 + 90);
            mask21.transform.rotation = Quaternion.Euler(0, 0, angleA13 - 90);

            bool clockwiseDirection = Vector2.SignedAngle(v13, v12) < 0;
            Debug.Log($"Vector2.SignedAngle(v13, v12):{Vector2.SignedAngle(v13, v12)}");
            float finalCirculationAngle = pointOfCirculation.endCirculationAngle;
            float angleOfDrawing = finalCirculationAngle - angle023;
            if (clockwiseDirection)
                angleOfDrawing = angleOfDrawing - 360;
            angleOfDrawing = angleOfDrawing % 360;
            //Debug.Log($"angleOfDrawing:{angleOfDrawing}, finalCirculationAngle:{finalCirculationAngle}, angle023:{angle023},clockwiseDirection:{clockwiseDirection}");
            if (Mathf.Abs(angleOfDrawing) <= 180)
            {
                mask12.transform.rotation = Quaternion.Euler(0, 0, angleA13 - 90 + angleOfDrawing);
                mask22.transform.rotation = Quaternion.Euler(0, 0, angleA13 + 90);
            }
            else
            {
                mask12.transform.rotation = Quaternion.Euler(0, 0, angleA13 + 90);
                mask22.transform.rotation = Quaternion.Euler(0, 0, angleA13 - 90 + angleOfDrawing);
            }

            //Debug.Log($"angle023:{angle023}");
            //Debug.Log($"angle023:{angle023}, angle1:{angle1}, point3:{point3}, v13:{v13}, v12:{v12}, v23:{v23}");
            ship.warShip.warShipBehavior.pointOfCirculation = pointOfCirculation;
        }
    }
}

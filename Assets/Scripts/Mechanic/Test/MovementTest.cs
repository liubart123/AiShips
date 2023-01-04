using Assets.Scripts.Mechanic.Main;
using Assets.Scripts.Mechanic.WarShip.Controllers;
using System.Collections;
using Unity.Collections;
using UnityEngine;

namespace Assets.Scripts.Mechanic.Test
{
    [ExecuteInEditMode]
    public class MovementTest : MonoBehaviour
    {
        public VectorOfMovement vectorOfMovement;
        public WarShipUnityObject ship;
        public WarShipMovementController warShipMovementController;
        public NormalWsMovementBehavior testWarShipMovementBehaviorbehavior;
        //public Assets.Scripts.Mechanic.WarShip.WarShip warShip;

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log($"MoveTest Start {ship.warShip.warShipMovementBehavior.GetType()}");
            Debug.DrawRay(vectorOfMovement.startPosition, vectorOfMovement.direction * 1000, Color.red, 0.5f);
            //ship.warShip = warShip;
            ship.warShip.warShipMovementController = warShipMovementController;
            ship.warShip.warShipMovementBehavior = testWarShipMovementBehaviorbehavior;
            ship.warShip.warShipMovementBehavior.vectorOfMovement = vectorOfMovement;
            ship.warShip.InitializeWarShipComponents();
            //Debug.Log($"MoveTest Finish {ship.warShip.warShipMovementBehavior.GetType()}");
        }

    }
}
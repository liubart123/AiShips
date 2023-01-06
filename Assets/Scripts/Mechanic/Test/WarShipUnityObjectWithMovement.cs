using Assets.Scripts.Mechanic.Main;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Mechanic.Test
{
    public class TestNormalWarShipMovementBehavior : MonoBehaviour 
    { 
        public NormalWsMovementBehavior shipMovementBehavior;

        private void Start()
        {
            CustomLogger.Log("ad");
            Initialize();
        }
        public void Initialize()
        {
            Debug.Log("Initialize test normal ws movement");
            var warShip = GetComponent<WarShipUnityObject>().warShip;
            if (warShip == null)
                return;
            warShip.warShipMovementBehavior = shipMovementBehavior;
            warShip.InitializeWarShipComponents();
        }
    }
}
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Mechanic.Test
{
    public class TestNormalWarShipMovementBehavior : MonoBehaviour 
    { 
        public NormalWsMovementBehavior shipMovementBehavior;

        private void Start()
        {
            
            Initialize();
        }
        public void Initialize()
        {
            var warShip = GetComponent<WarShipUnityObject>().warShip;
            if (warShip == null)
                return;
            warShip.warShipMovementBehavior = shipMovementBehavior;
        }
    }
}
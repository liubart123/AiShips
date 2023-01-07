using Assets.Scripts.Mechanic.Main;
using log4net;
using log4net.Repository.Hierarchy;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Mechanic.Test
{
    public class TestNormalWarShipMovementBehavior : MonoBehaviour
    {
        CustomLogger logger = new CustomLogger("TestNormalWarShipMovementBehavior", new Color(215, 232, 130));
        public NormalWsMovementBehavior shipMovementBehavior;

        private void Start()
        {
            Initialize();
        }
        public void Initialize()
        {
            logger.Info("Initialize");
            var warShip = GetComponent<WarShipUnityObject>().warShip;
            if (warShip == null)
                return;
            warShip.warShipMovementBehavior = shipMovementBehavior;
            warShip.SetUpWarShipComponents();
        }
        public void Update()
        {
        }
    }
}
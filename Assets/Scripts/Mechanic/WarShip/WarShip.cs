using Assets.Scripts.Mechanic.WarShip.Behavior;
using Assets.Scripts.Mechanic.WarShip.Controllers;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Mechanic.WarShip
{
    [Serializable]
    public class WarShip
    {
        #region CONTROLLERS
        public WarShipShootingController warShipShootingController;
        public WarShipMovementController warShipMovementController;
        public WarShipMovementBehavior warShipMovementBehavior;
        public WarShipWeaponBehavior warShipWeaponBehavior;
        #endregion

        ILog log = LogManager.GetLogger("asd");

        public void InitializeWarShipComponents()
        {
            Debug.Log("Initialize warship");
            List<WarShipComponent> components = new List<WarShipComponent>
            {
                warShipShootingController,
                warShipMovementController,
                warShipMovementBehavior,
                warShipWeaponBehavior
            };
            foreach (var component in components)
            {
                if (component == null)
                    continue;
                component.WarShip = this;
            }
        }
    }
}

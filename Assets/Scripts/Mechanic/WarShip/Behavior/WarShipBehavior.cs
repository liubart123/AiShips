using Assets.Scripts.Mechanic.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Mechanic.WarShip.Behavior
{
    [Serializable]
    public class WarShipBehavior
    {
        [NonSerialized]
        public WarShip warShip;
        public PointOfCirculation pointOfCirculation;
        [NonSerialized]
        public WarShip shootingTarget;

        public WarShipBehavior()
        {

        }
        public WarShipBehavior(WarShip behaviorForWarship)
        {
            this.warShip = behaviorForWarship;
        }


        public virtual void DoMovementBehaviorTick()
        {

        }
        public virtual void DoShootingBehaviorTick()
        {

        }
    }
}

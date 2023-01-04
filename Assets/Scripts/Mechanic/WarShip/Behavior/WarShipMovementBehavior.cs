using Assets.Scripts.Mechanic.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Mechanic.WarShip.Behavior
{
    [Serializable]
    public class WarShipMovementBehavior : WarShipComponent
    {
        public VectorOfMovement vectorOfMovement;

        public WarShipMovementBehavior()
        {

        }


        public virtual void DoMovementBehaviorTick()
        {

        }
    }
}

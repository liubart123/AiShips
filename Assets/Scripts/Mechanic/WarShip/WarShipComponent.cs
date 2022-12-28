using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Mechanic.WarShip
{
    public abstract class WarShipComponent
    {
        [NonSerialized]
        private WarShip warShip;

        public WarShip WarShip { get => warShip; set => warShip = value; }
    }
}

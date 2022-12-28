using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Mechanic.Main
{
    [Serializable]
    public class GameEngine
    {
        public List<WarShip.WarShip> warShips;
        public void DoTick()
        {
            foreach(var ship in warShips)
            {
                ship.warShipBehavior.DoMovementBehaviorTick();
            }

            foreach (var ship in warShips)
            {
                ship.warShipBehavior.DoShootingBehaviorTick();
            }
        }
    }
}

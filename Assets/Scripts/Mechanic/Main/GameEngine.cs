using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Mechanic.Main
{
    /// <summary>
    /// Stores all main game info. Runs calculations for each tick
    /// </summary>
    [Serializable]
    public class GameEngine
    {
        public List<WarShip.WarShip> warShips;
        public void DoTick()
        {

            foreach (var ship in warShips)
            {
                ship.warShipMovementBehavior.DoMovementBehaviorTick();
                ship.warShipMovementController.DoTick();
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Mechanic.WarShip.Controllers
{
    [Serializable]
    public class WarShipShootingController : WarShipComponent
    {
        //CURRENT STATE OF SHOOTING CONTROLLER
        [NonSerialized]
        public WarShip currentTarget;
        public float leftTimeToCompleteReloading;


        //CONSTANT CHARACTERISTICS
        public float reloadingTime;

        public virtual void DoTick()
        {

        }
    }
}

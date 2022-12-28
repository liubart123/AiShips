using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Mechanic.Main
{
    public static class Vector2ExtensionMethod
    {
        /// <summary>
        /// Starts from 3:00 counterclockwise
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static float ToRadAngle(this Vector2 vector)
        {
            float angle = Mathf.Atan2(vector.y, vector.x);
            //return angle;
            return angle%(Mathf.PI*2);
        }
        /// <summary>
        /// Starts from 3:00 counterclockwise
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static float ToDegreeAngle(this Vector2 vector)
        {
            return ToRadAngle(vector) / Mathf.PI * 180;
        }
    }
}

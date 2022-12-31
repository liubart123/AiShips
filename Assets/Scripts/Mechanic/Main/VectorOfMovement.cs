using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Mechanic.Main
{
    [Serializable]
    public class VectorOfMovement
    {
        public Vector2 startPosition, direction;
        //Ax+By+C=0
        public float A
        {
            get
            {
                return direction.x;
            }
        }
        public float B
        {
            get
            {
                return -direction.y;
            }
        }
        public float C
        {
            get
            {
                return startPosition.x * (-direction.y) + direction.x * startPosition.y;
            }
        }
    }
}
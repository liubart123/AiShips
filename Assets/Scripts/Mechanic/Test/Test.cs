using Assets.Scripts.Mechanic.Main;
using log4net;
using log4net.Core;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Mechanic.Test
{
    public class Test : MonoBehaviour
    {

        CustomLogger logger = new CustomLogger("test", Color.red);

        //public string LoggerName { get => "Test"; }
        public Color ColorForMessages { get => new Color(133, 82, 125); }

        // Use this for initialization
        void Start()
        {
        }
        

        // Update is called once per frame
        void Update()
        {

        }
    }
}
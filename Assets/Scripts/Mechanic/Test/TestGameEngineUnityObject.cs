using Assets.Scripts.Mechanic.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Mechanic.Test
{
    public class TestGameEngineUnityObject : MonoBehaviour
    {
        public GameEngine gameEngine;
        public List<WarShipUnityObject> warShipUnityObjects;

        static TestGameEngineUnityObject _instance;
        static TestGameEngineUnityObject Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<TestGameEngineUnityObject>();
                return _instance;
            }
        }

        public void Start()
        {
            if (gameEngine == null)
                gameEngine = new GameEngine();
            gameEngine.warShips = warShipUnityObjects.Select(shipUo => shipUo.warShip).ToList();
        }

        [MenuItem("MyMenu/DoTick &t")]
        static void DoTick()
        {
            Instance.gameEngine.DoTick();
        }

    }
}

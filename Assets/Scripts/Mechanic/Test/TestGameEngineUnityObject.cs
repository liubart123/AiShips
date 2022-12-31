using Assets.Scripts.Mechanic.Main;
using System;
using System.Collections;
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
        [HideInInspector]
        public GameEngine gameEngine;
        public List<WarShipUnityObject> warShipUnityObjects;
        public int msecondsForTick;

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
            InitializeEngine();
        }
        void InitializeEngine()
        {
            gameEngine.warShips = warShipUnityObjects.Select(shipUo => shipUo.warShip).ToList();
        }

        [MenuItem("MyMenu/Do tick &t")]
        static void DoTick()
        {
            if (Instance.ticksAreRunning)
            {
                Instance.ticksAreRunning = false;
                return;
            }
            Instance.InitializeEngine();
            Instance.gameEngine.DoTick();
        }

        bool ticksAreRunning;
        [MenuItem("MyMenu/Run ticks &r")]
        static async void RunTicks()
        {
            if (Instance.ticksAreRunning)
            {
                Instance.ticksAreRunning = false;
                return;
            }
            Instance.ticksAreRunning = true;
            await DoTickCoroutine();
        }

        static int ticksInRow = 0;
        static async Task DoTickCoroutine()
        {
            while (Instance.ticksAreRunning && ticksInRow < 1000)
            {
                Instance.InitializeEngine();
                Instance.gameEngine.DoTick();
                Instance.warShipUnityObjects.ForEach(el => el.Render());
                ticksInRow++;
                await Task.Delay(Instance.msecondsForTick);
            }
            ticksInRow = 0;
        }

    }
}

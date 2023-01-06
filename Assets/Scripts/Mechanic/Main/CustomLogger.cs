
using Assets.Scripts.Mechanic.Test;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;
using static log4net.Appender.FileAppender;

namespace Assets.Scripts.Mechanic.Main
{
    public class CustomLogger : MonoBehaviour
    {
        public static ILog Logger { get; set; }
        //[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void ConfigureAllLogging()
        {
            var patternLayout = new PatternLayout
            {
                ConversionPattern = "%date %-5level %logger - %message%newline"
            };
            patternLayout.ActivateOptions();

            var infoFileAppender = new RollingFileAppender
            {
                AppendToFile = false,
                File = $"{Application.dataPath}/Logs/InfoLog.log",
                Layout = patternLayout,
                MaxSizeRollBackups = 5,
                MaximumFileSize = "10MB",
                RollingStyle = RollingFileAppender.RollingMode.Size,
                StaticLogFileName = true,
                Threshold = log4net.Core.Level.Info
            };
            infoFileAppender.ActivateOptions();
            var allFileAppender = new RollingFileAppender
            {
                AppendToFile = false,
                File = $"{Application.dataPath}/Logs/AllLog.log",
                Layout = patternLayout,
                MaxSizeRollBackups = 5,
                MaximumFileSize = "10MB",
                LockingModel = new MinimalLock(),
                RollingStyle = RollingFileAppender.RollingMode.Size,
                StaticLogFileName = true,
                Threshold = log4net.Core.Level.All
            };
            allFileAppender.ActivateOptions();

            BasicConfigurator.Configure(infoFileAppender, allFileAppender);
        }
        public void Start()
        {
            StartCoroutine(ConfigureLogs());    //configuring logs on Start doesn't work :{
        }


        IEnumerator ConfigureLogs()
        {
            yield return null;
            ConfigureAllLogging();
        }
    }
}
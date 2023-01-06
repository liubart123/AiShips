
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Layout;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Mechanic.Main
{
    public static class CustomLogger
    {

        static CustomLogger()
        {
        }

        public static void Log(string message)
        {
            Debug.Log("static CustomLogger");
            ILog logger = LogManager.GetLogger("asd");
            logger.Debug("static CustomLogger");
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void ConfigureAllLogging()
        {
            var patternLayout = new PatternLayout
            {
                ConversionPattern = "%date %-5level %logger - %message%newline"
            };
            patternLayout.ActivateOptions();

            // setup the appender that writes to Log\EventLog.txt
            var fileAppender = new RollingFileAppender
            {
                AppendToFile = false,
                File = $"{Application.dataPath}/Logs/EventLog.log",
                Layout = patternLayout,
                MaxSizeRollBackups = 5,
                MaximumFileSize = "10MB",
                RollingStyle = RollingFileAppender.RollingMode.Size,
                StaticLogFileName = true
            };
            fileAppender.ActivateOptions();

            BasicConfigurator.Configure(fileAppender);
        }
    }
}
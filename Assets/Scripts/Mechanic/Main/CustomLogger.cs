
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
                ConversionPattern = "%date %-5level %logger - %message<br/>%newline"
            };
            patternLayout.ActivateOptions();

            var infoFileAppender = new RollingFileAppender
            {
                AppendToFile = false,
                File = $"{Application.dataPath}/Logs/InfoLog.md",
                Layout = patternLayout,
                MaxSizeRollBackups = 5,
                MaximumFileSize = "10MB",
                RollingStyle = RollingFileAppender.RollingMode.Size,
                StaticLogFileName = true,
                PreserveLogFileNameExtension = true,
                Threshold = log4net.Core.Level.Info,
            };
            infoFileAppender.ActivateOptions();

            var allFileAppender = new RollingFileAppender
            {
                AppendToFile = false,
                File = $"{Application.dataPath}/Logs/AllLog.md",
                Layout = patternLayout,
                MaxSizeRollBackups = 5,
                MaximumFileSize = "10MB",
                LockingModel = new MinimalLock(),
                RollingStyle = RollingFileAppender.RollingMode.Size,
                StaticLogFileName = true,
                Threshold = log4net.Core.Level.All,
                PreserveLogFileNameExtension = true,
            };
            allFileAppender.ActivateOptions();

            var unityLogger = new UnityAppender
            {
                Layout = new PatternLayout()
            };
            unityLogger.ActivateOptions();

            BasicConfigurator.Configure(infoFileAppender, allFileAppender, unityLogger);
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

        /// <summary> An appender which logs to the unity console. </summary>
        private class UnityAppender : AppenderSkeleton
        {
            /// <inheritdoc />
            protected override void Append(LoggingEvent loggingEvent)
            {
                string message = RenderLoggingEvent(loggingEvent);

                if (Level.Compare(loggingEvent.Level, Level.Error) >= 0)
                {
                    // everything above or equal to error is an error
                    Debug.LogErrorFormat(message);
                }
                else if (Level.Compare(loggingEvent.Level, Level.Warn) >= 0)
                {
                    // everything that is a warning up to error is logged as warning
                    Debug.LogWarningFormat(message);
                }
                else
                {
                    // everything else we'll just log normally
                    Debug.LogFormat(message);
                }
            }
        }
    }

}
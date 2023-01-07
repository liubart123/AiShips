
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
    public class CustomLoggerConfiguration : MonoBehaviour
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

            var infoFileAppender = new CustomFileAppender
            {
                AppendToFile = true,
                File = $"{Application.dataPath}/Logs/InfoLog.md",
                Layout = patternLayout,
                MaxSizeRollBackups = 2,
                MaximumFileSize = "10MB",
                LockingModel = new MinimalLock(),
                RollingStyle = RollingFileAppender.RollingMode.Size,
                StaticLogFileName = true,
                PreserveLogFileNameExtension = true,
                Threshold = log4net.Core.Level.Info,
            };
            infoFileAppender.ActivateOptions();

            var allFileAppender = new CustomFileAppender
            {
                AppendToFile = true,
                File = $"{Application.dataPath}/Logs/AllLog.md",
                Layout = patternLayout,
                MaxSizeRollBackups = 2,
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
                Layout = new PatternLayout(),
                Threshold = log4net.Core.Level.Trace,
            };
            unityLogger.ActivateOptions();

            BasicConfigurator.Configure(allFileAppender, unityLogger, infoFileAppender);
        }
        public void Awake()
        {
            ConfigureAllLogging();
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
                string message = loggingEvent.LoggerName + ": " + RenderLoggingEvent(loggingEvent);

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
                    int size = GetUnityFontSizeForLoggingLevel(loggingEvent.Level);
                    Debug.LogFormat($"<size={size}>{message}</size>");
                }
            }
        }

        private class CustomFileAppender : RollingFileAppender { 
            protected override void Append(LoggingEvent loggingEvent)
            {
                int size = GetMarkupFontSizeForLoggingLevel(loggingEvent.Level);
                string convertedToMarkupMessage = loggingEvent.MessageObject.ToString()
                    .Replace("<color","<font color")
                    .Replace("</color>","</font>");

                convertedToMarkupMessage = $"<font size=\"{size}\">{convertedToMarkupMessage}</font>";

                LoggingEvent customizedLoggingEvent = new LoggingEvent(
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, 
                    loggingEvent.Repository,
                    loggingEvent.LoggerName,
                    loggingEvent.Level,
                    convertedToMarkupMessage,
                    loggingEvent.ExceptionObject);
                base.Append(customizedLoggingEvent);
            }

        }

        private static int GetUnityFontSizeForLoggingLevel(Level level)
        {
            int size;
            if (Level.Compare(level, Level.Notice) >= 0)
            {
                size = 15;
            }
            else if (Level.Compare(level, Level.Info) >= 0)
            {
                size = 13;
            }
            else if (Level.Compare(level, Level.Debug) >= 0)
            {
                size = 10;
            }
            else
            {
                size = 7;
            }
            return size;
        }
        private static int GetMarkupFontSizeForLoggingLevel(Level level)
        {
            int size;
            if (Level.Compare(level, Level.Notice) >= 0)
            {
                size = 4;
            }
            else if (Level.Compare(level, Level.Info) >= 0)
            {
                size = 3;
            }
            else if (Level.Compare(level, Level.Debug) >= 0)
            {
                size = 2;
            }
            else
            {
                size = 1;
            }
            return size;
        }
    }

}
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Mechanic.Main
{
    public class CustomLogger
    {
        public Color messageColor;
        public ILog logger;
        public CustomLogger()
        {
            logger = LogManager.GetLogger("default");
            this.messageColor = Color.gray;
        }
        public CustomLogger(string loggerName)
        {
            logger = LogManager.GetLogger(loggerName);
            this.messageColor = Color.gray;
        }
        public CustomLogger(string loggerName, Color messageColor)
        {
            logger = LogManager.GetLogger(loggerName);
            this.messageColor = messageColor;
        }
        public void Debug(string message, bool useColor = true)
        {
            if (useColor)
                logger.Debug($"<color={ColorUtility.ToHtmlStringRGB(messageColor)}>{message}</color>");
            else
                logger.Debug(message);
        }
        public void Info(string message, bool useColor = true)
        {
            if (useColor)
                logger.Info($"<color={ColorUtility.ToHtmlStringRGB(messageColor)}>{message}</color>");
            else
                logger.Info(message);
        }
        public void Notice(string message, bool useColor = true)
        {
            if (useColor)
                logger.Notice($"<color={ColorUtility.ToHtmlStringRGB(messageColor)}>{message}</color>");
            else
                logger.Notice(message);
        }
        public void Error(string message, bool useColor = true)
        {
            if (useColor)
                logger.Error($"<color={ColorUtility.ToHtmlStringRGB(messageColor)}>{message}</color>");
            else
                logger.Error(message);
        }
        public void Warn(string message, bool useColor = true)
        {
            if (useColor)
                logger.Warn($"<color={ColorUtility.ToHtmlStringRGB(messageColor)}>{message}</color>");
            else
                logger.Warn(message);
        }
    }
}

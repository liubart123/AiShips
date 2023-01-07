using log4net.Core;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace log4net
{
    public static class LoggerExtension
    {
        public static void Notice(this ILog log, string message)
        {
            log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                Level.Notice, message, null);
        }

    }
}

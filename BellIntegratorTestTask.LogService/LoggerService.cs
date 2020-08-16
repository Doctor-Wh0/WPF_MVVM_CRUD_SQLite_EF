using NLog;
using NLog.Targets;
using System;
using System.IO;

namespace BellIntegratorTestTask.LogService
{
    public class LoggerService 
    {
        //private static string _path;
        //public static string Path
        //{
        //    get { return _path; }
        //    set 
        //    { 
        //        _path = value;
        //        //logger = LogManager.Configuration.FindTargetByName("filedata").
        //        var fileTarget = (FileTarget)LogManager.Configuration.FindTargetByName("filedata");
        //        fileTarget.FileName = value;

        //        // Need to set timestamp here if filename uses date. 
        //        // For example - filename="${basedir}/logs/${shortdate}/trace.log"
        //        var logEventInfo = new LogEventInfo { TimeStamp = DateTime.Now };
        //        string fileName = fileTarget.FileName.Render(logEventInfo);
        //        if (!File.Exists(fileName))
        //            throw new Exception("Log file does not exist.");
        //    }
        //}

        private static Logger logger = LogManager.GetCurrentClassLogger();


        public void Trace(string message) { logger.Trace(message); }
        public void Debug(string message) { logger.Debug(message); }
        public void Info (string message) { logger.Info (message); }
        public void Warn (string message) { logger.Warn (message); }
        public void Error(string message) { logger.Error(message); }
        public void Fatal(string message) { logger.Fatal(message); }
    }
}

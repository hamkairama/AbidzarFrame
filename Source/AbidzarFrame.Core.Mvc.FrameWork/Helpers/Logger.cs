using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Web.Mvc;

namespace AbidzarFrame.Core.Mvc.Helpers
{
    public class Logger
    {
        protected static Logger logger = null;
        protected Stream loggerStream = null;
        protected int level = 10;
        protected int indent = 0;
        protected SOURCE_TYPE source = SOURCE_TYPE.CONSOLE;
        protected StreamWriter writer = null;

        protected enum SOURCE_TYPE {
            CONSOLE = 0,
            FILE = 1
        }

        public Stream LoggerStream
        {
            get
            {
                return loggerStream;
            }
        }

        protected StreamWriter Writer
        {
            get
            {
                return this.writer;
            }
        }

        public static Logger GetInstance()
        {
            ApplicationSetting setting = ApplicationSetting.GetInstance();
            return GetInstance(setting.LogFile, setting.LogLevel);
        }

        public static Logger GetInstance(String source, int level)
        {
            if (logger == null) {
                logger = new Logger();
                logger.level = level;
                if (source.StartsWith("Console"))
                {
                    logger.source = SOURCE_TYPE.CONSOLE;
                    logger.loggerStream = new MemoryStream();

                    //System.Diagnostics.Debug.Listeners.Add(
                    //    new ConsoleTraceListener());
                } else
                if (source.StartsWith("File:"))
                {
                    String fileName = source.Substring(5);
                    fileName = fileName.Replace("{yyyyMMdd}", System.DateTime.Today.ToString("yyyyMMdd"));
                    fileName = fileName.Replace("{yyyyMM}", System.DateTime.Today.ToString("yyyyMM"));
                    fileName = fileName.Replace("{yyyy}", System.DateTime.Today.ToString("yyyy"));
                    fileName = fileName.Replace("{MMdd}", System.DateTime.Today.ToString("MMdd"));
                    if (!File.Exists(fileName))
                    {
                        Directory.CreateDirectory(fileName);
                        Directory.Delete(fileName);
                    }
                    logger.source = SOURCE_TYPE.FILE;
                    logger.loggerStream = new FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                    logger.writer = new StreamWriter(logger.loggerStream);
                    logger.writer.AutoFlush = true;

                    //System.Diagnostics.Debug.Listeners.Add(
                    //    new TextWriterTraceListener(logger.loggerStream));
                }
            }
            return logger;
        }

        public void WriteLogData(LogData log, int level, LogData.LOG_TYPE prefix)
        {
            if (this.level >= level)
            {
                lock (logger)
                {
                    if (prefix == LogData.LOG_TYPE.begin) indent++;

                    if (source == SOURCE_TYPE.CONSOLE)
                        Console.WriteLine(LogData.FormatLogData(log, level, prefix, indent + (prefix == LogData.LOG_TYPE.data ? 1 : 0)));
                    else
                        writer.WriteLine(LogData.FormatLogData(log, level, prefix, indent + (prefix == LogData.LOG_TYPE.data ? 1 : 0)));

                    //Debug.Print(LogData.FormatLogData(log, level, prefix, indent + (prefix == LogData.LOG_TYPE.data ? 1 : 0)));
                    //Debug.Flush();

                    if (prefix == LogData.LOG_TYPE.end) indent--;
                    indent = (indent < 0) ? 0 : indent;
                }
            }
        }

        public void WriteData(String s, int level) {
            if (this.level >= level)
            {
                lock (logger)
                {
                    if (source == SOURCE_TYPE.CONSOLE)
                        Console.WriteLine(s);
                    else
                        writer.WriteLine(s);

                    //Debug.Print(s);
                    //Debug.Flush();
                }
            }
        }

    }
}
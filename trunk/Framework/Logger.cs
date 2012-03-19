using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BA.MultiMvc.Framework
{
    public static class Logger
    {
        private static ILoggerService _loggerService;
        
        public static void SetLoggerService(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public static void Info(string message)
        {
            if (_loggerService == null) return;

            _loggerService.Info(message);
        }
        
        public static void Warn(string message)
        {
            if (_loggerService == null) return;

            _loggerService.Warn(message);
        }

        public static void Debug(string message)
        {
            if (_loggerService == null) return;

            _loggerService.Debug(message);
        }
        
        public static void Error(string message)
        {
            if (_loggerService == null) return;

            _loggerService.Error(message);
        }

        public static void Error(Exception ex)
        {
            if (_loggerService == null) return;

            _loggerService.Error(ex);
        }

        public static void Fatal(string message)
        {
            if (_loggerService == null) return;

            _loggerService.Fatal(message);
        }

        public static void Fatal(Exception ex)
        {
            if (_loggerService == null) return;

            _loggerService.Fatal(ex);
        }

    }
}

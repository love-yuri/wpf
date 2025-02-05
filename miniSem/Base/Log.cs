using System;

// ReSharper disable LocalizableElement
// ReSharper disable MemberCanBePrivate.Global

namespace miniSem.Base {
    internal enum LogLevel {
        Debug,
        Info,
        Error,
    }
    
    public static class Log {
        
        /// <summary>
        /// 格式化消息日志
        /// </summary>
        /// <param name="level">消息等级</param>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        internal static string FormatMsg(LogLevel level, string msg) {
            var time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var levelStr = level.ToString().PadLeft(5);
            return $"[{time} {levelStr}] {msg}";
        }

        /// <summary>
        /// 打印日志 info级别
        /// </summary>
        /// <param name="msg"></param>
        public static void Info(string msg) {
            Console.WriteLine(FormatMsg(LogLevel.Info, msg));
        }

        /// <summary>
        /// Debug模式，只在debug下打印，级别等同于info
        /// </summary>
        /// <param name="msg"></param>
        public static void Debug(string msg) {
        #if DEBUG
            Console.WriteLine(FormatMsg(LogLevel.Debug, msg)); 
        #endif
        }

        /// <summary>
        /// 输出到标准错误流
        /// </summary>
        /// <param name="msg"></param>
        public static void Error(string msg) {
            Console.Error.WriteLine(FormatMsg(LogLevel.Error, msg));
        }
    }
}

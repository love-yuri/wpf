using System;
using System.Diagnostics;

namespace miniSem.Base.Utils {
    
    
    /// <summary>
    /// 存储文件相关工具
    /// </summary>
    public static class FileUtils {

        /// <summary>
        /// 获取当前工作目录完全限定路径
        /// </summary>
        public static string CurrentPath => Environment.CurrentDirectory;

        public static void OpenDirectory() {
            Log.Info($"打开当前目录 -> {CurrentPath}");
            Process.Start(CurrentPath);
        }
    }
}
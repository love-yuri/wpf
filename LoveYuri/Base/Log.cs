namespace LoveYuri.Base;

public static class Log {
    private static string Time => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    
    /// <summary>
    /// 打印日志 info级别
    /// </summary>
    /// <param name="msg"></param>
    public static void Info(string msg) {
        Console.WriteLine($"[{Time} Info] {msg}");
    }

    /// <summary>
    /// Debug模式，旨在debug下打印，级别等同于info
    /// </summary>
    /// <param name="msg"></param>
    public static void Debug(string msg) {
        #if DEBUG
            Info(msg);
        #endif
    }

    /// <summary>
    /// 输出到标准错误流
    /// </summary>
    /// <param name="msg"></param>
    public static void Warn(string msg) {
        Console.Error.WriteLine($"[{Time} Warn] {msg}");
    }
}
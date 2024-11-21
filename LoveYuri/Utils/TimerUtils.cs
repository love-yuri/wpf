using System.Windows;
using System.Windows.Threading;
using Timer = System.Timers.Timer;

namespace LoveYuri.Utils;

public static class TimerUtils {
    
    /// <summary>
    /// 定时器
    /// </summary>
    /// <param name="mes">延迟时间</param>
    /// <param name="func">回调函数</param>
    /// <param name="runInUi">是否在ui线程执行</param>
    public static void Timeout(int mes, Action func, bool runInUi = false) {
        var timer = new Timer(mes);
        
        timer.AutoReset = false;
        timer.Elapsed += (_, _) => {
            try {
                if (runInUi) {
                   Application.Current.Dispatcher.Invoke(func);
                } else {
                    func();
                }
            } finally {
                timer.Stop();
                timer.Dispose();
            }
        };

        timer.Start();
    }
}
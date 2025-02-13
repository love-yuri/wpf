﻿using System;
using System.Windows;
using Timer = System.Timers.Timer;

namespace miniSem.Base.Utils {

    public static class TimerUtils {

        /// <summary>
        /// Timeout延迟执行
        /// </summary>
        /// <param name="mes">延迟时间</param>
        /// <param name="func">回调函数</param>
        /// <param name="runInUi">是否在ui线程执行</param>
        public static void Timeout(int mes, Action func, bool runInUi = false) {
            var timer = new Timer(mes);

            timer.AutoReset = false;
            timer.Elapsed += (o, e) => {
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
}
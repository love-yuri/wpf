using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Shell;
using miniSem.Base.Utils;

namespace miniSem.Base.Mvvm {
    
    public class BaseDialog: Window {
        protected BaseDialog() {
            WindowStyle = WindowStyle.None;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            SnapsToDevicePixels = true;
            
            // 设置 WindowChrome
            var windowChrome = new WindowChrome {
                ResizeBorderThickness = new Thickness(5), // 调整窗口大小的边框厚度
                CaptionHeight = 30,                       // 标题栏高度
                CornerRadius = new CornerRadius(12),       // 窗口圆角半径
                GlassFrameThickness = new Thickness(6)    // 玻璃效果边框厚度
            };

            WindowChrome.SetWindowChrome(this, windowChrome);
        }

        /// <summary>
        /// 弹出对话框
        /// </summary>
        /// <param name="window">父级指针</param>
        /// <typeparam name="T"></typeparam>
        public static void ShowDialog<T>(Window window = null) where T: BaseDialog {
            var dialog = CommonUtils.CreateInstance<T>();
            dialog.Owner = window;
            dialog.ShowDialog();
        }

        protected new void Close() {
            // 创建渐隐动画
            var fadeOutAnimation = new DoubleAnimation {
                From = 1.0, // 初始透明度
                To = 0.0,   // 最终透明度
                Duration = TimeSpan.FromSeconds(0.3) // 动画持续时间
            };

            var widthAnimation = new DoubleAnimation {
                From = Width,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.3)
            };

            // 动画完成时关闭窗口
            fadeOutAnimation.Completed += (__, _) => base.Close();

            // 启动动画
            BeginAnimation(OpacityProperty, fadeOutAnimation);
            BeginAnimation(WidthProperty, widthAnimation);
        }
    }
}
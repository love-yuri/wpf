using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using miniSem.Utils;

namespace miniSem.Components {
    public partial class MenuBar {
        
        public MenuBar() {
            InitializeComponent();
        }

        protected override void OnMouseMove(MouseEventArgs e) {
            // 判断鼠标是否按下
            if (e.LeftButton == MouseButtonState.Pressed) {
                CommonUtils.CurrentWindow.DragMove();
            }
        }

        private void CloseWindow(object sender, RoutedEventArgs e) {
            CommonUtils.CurrentWindow.Close();
        }

        private void MiniWindow(object sender, RoutedEventArgs e) {
            CommonUtils.CurrentWindow.WindowState = WindowState.Minimized;
        }
    }
}
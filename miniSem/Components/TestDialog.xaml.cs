using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace miniSem.Components {
    public partial class TestDialog {
        public TestDialog() {
            InitializeComponent();
        }

        private void CloseWindow(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
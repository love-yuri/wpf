using System.Windows;

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
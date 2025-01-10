using miniSem.Base;
using miniSem.Base.Config;

namespace miniSem {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        public MainWindow() {
            InitializeComponent();
            
            var config = GlobalConfig.Instance;
            var version = config.Version;
            Log.Info($"name -> {config.Name} version -> {version}");
        }
    }
}
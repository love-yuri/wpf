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
            var array = config.Arrays;
            Log.Info($"name -> {config.Name} version -> {version}");
            array.Add("yuri is yes");
            config.Arrays = array;
            config.Arrays.ForEach(k => {
                Log.Info($"v -> {k}");
            });
            config.Save();
        }
    }
}
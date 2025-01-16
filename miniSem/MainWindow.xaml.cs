using System.Runtime.CompilerServices;
using System.Windows.Input;
using miniSem.Base;
using miniSem.Base.Config;
using miniSem.Base.Mvvm;
using miniSem.Base.Utils;
using miniSem.Components;

namespace miniSem {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        public ICommand ClickCommand { get; }
        
        public MainWindow() {
            ClickCommand = BaseCommand.Create(() => {
                BaseDialog.ShowDialog<TestDialog>(this);
            });
            
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

            Log.Info($"path -> {FileUtils.CurrentPath}");
        }
    }
}
using System.Windows;
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
            // config.Person = new Person {
            //     Name = "yuri",
            //     Age = 18,
            // };
            // var array = config.Arrays;
            Log.Info($"name -> {config.Name} version -> {version}, person -> {config.Person}");
            // array.Add("yuri is yes");
            // array.Add("yuri is yes");
            // config.Arrays = array;
            config.Arrays.ForEach(k => {
                Log.Info($"v -> {k}");
            });

            Log.Info($"path -> {FileUtils.CurrentPath}");
        }

        private void OpenMessageBox(object sender, RoutedEventArgs e) {
            MessageBox.Show("弹出消息");
        }

        private void AddSliderValue(object sender, RoutedEventArgs e) {
            Slider.Value++;
        }

        private void MinusSliderValue(object sender, RoutedEventArgs e) {
            Slider.Value--;
        }
    }
}
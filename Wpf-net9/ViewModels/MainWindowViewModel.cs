using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Wpf_net9.ViewModels;

public partial class MainWindowViewModel: ObservableObject {
    
    [RelayCommand]
    private void Click() {
        Console.WriteLine("点击");
    }
}
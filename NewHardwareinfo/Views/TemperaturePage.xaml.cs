using Microsoft.UI.Xaml.Controls;

using NewHardwareinfo.ViewModels;

namespace NewHardwareinfo.Views;

public sealed partial class TemperaturePage : Page
{
    public TemperatureViewModel ViewModel
    {
        get;
    }

    public TemperaturePage()
    {
        ViewModel = App.GetService<TemperatureViewModel>();
        InitializeComponent();
    }
}

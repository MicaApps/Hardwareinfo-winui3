using Microsoft.UI.Xaml.Controls;
using NewHardwareinfo.Contracts.Services;
using NewHardwareinfo.Services;
using NewHardwareinfo.ViewModels;

namespace NewHardwareinfo.Views;

public sealed partial class HardwareGridPage : Page
{
    public HardwareGridViewModel ViewModel
    {
        get;
    }

    public HardwareGridPage()
    {
        ViewModel = App.GetService<HardwareGridViewModel>();
        InitializeComponent();

        gv.ItemsSource = HardwareInfoService.source;
    }

   
}

using Microsoft.UI.Xaml.Controls;
using NewHardwareinfo.Services;
using NewHardwareinfo.ViewModels;

namespace NewHardwareinfo.Views;

public sealed partial class HomePage : Page
{
    public HomeViewModel ViewModel
    {
        get;
    }

    public HomePage()
    {
        ViewModel = App.GetService<HomeViewModel>();
        InitializeComponent();
        lv_cpu.ItemsSource = HardwareInfoService.cpu_source;
        lv_mem.ItemsSource = HardwareInfoService.mem_source;
        lv_gpu.ItemsSource = HardwareInfoService.gpu_source;
    }
}

using NewHardwareinfo.Helpers;
using NewHardwareinfo.Services;

namespace NewHardwareinfo;

public sealed partial class MainWindow : WindowEx
{
    public MainWindow()
    {
        InitializeComponent();

        AppWindow.SetIcon(Path.Combine(AppContext.BaseDirectory, "Assets/WindowIcon.ico"));
        Content = null;
        Title = "AppDisplayName".GetLocalized();

        HardwareInfoService.TimerUpdate();
    }
}

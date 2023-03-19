using Microsoft.UI.Xaml.Controls;
using NewHardwareinfo.Services;
using NewHardwareinfo.ViewModels;

namespace NewHardwareinfo.Views;

// TODO: Change the grid as appropriate for your app. Adjust the column definitions on DataGridPage.xaml.
// For more details, see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid.
public sealed partial class HardwareTablePage : Page
{
    public HardwareTableViewModel ViewModel
    {
        get;
    }

    public HardwareTablePage()
    {
        ViewModel = App.GetService<HardwareTableViewModel>();
        InitializeComponent();

        datagrid.ItemsSource = HardwareInfoService.source;
    }
}

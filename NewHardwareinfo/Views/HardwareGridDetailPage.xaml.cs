using CommunityToolkit.WinUI.UI.Animations;

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

using NewHardwareinfo.Contracts.Services;
using NewHardwareinfo.Services;
using NewHardwareinfo.ViewModels;

namespace NewHardwareinfo.Views;

public sealed partial class HardwareGridDetailPage : Page
{
    public HardwareGridDetailViewModel ViewModel
    {
        get;
    }

    public HardwareGridDetailPage()
    {
        ViewModel = App.GetService<HardwareGridDetailViewModel>();
        InitializeComponent();

        lv_hardwaredetail.ItemsSource = HardwareInfoService.source;
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        this.RegisterElementForConnectedAnimation("animationKeyContentGrid", itemHero);

        lv_hardwaredetail.ItemsSource = HardwareInfoService.source2;
    }

    protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
    {
        base.OnNavigatingFrom(e);
        if (e.NavigationMode == NavigationMode.Back)
        {
            var navigationService = App.GetService<INavigationService>();

            if (ViewModel.Item != null)
            {
                navigationService.SetListDataItemForNextConnectedAnimation(ViewModel.Item);
            }
        }
    }
}

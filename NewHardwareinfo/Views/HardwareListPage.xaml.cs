using System;
using CommunityToolkit.WinUI.UI.Controls;

using Microsoft.UI.Xaml.Controls;
using NewHardwareinfo.Services;
using NewHardwareinfo.ViewModels;

namespace NewHardwareinfo.Views;

public sealed partial class HardwareListPage : Page
{
    public HardwareListViewModel ViewModel
    {
        get;
    }

    public HardwareListPage()
    {
        ViewModel = App.GetService<HardwareListViewModel>();
        InitializeComponent();

        ListDetailsViewControl.ItemsSource = HardwareInfoService.source;
    }

    private void ListDetailsViewControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        HardwareInfoService.SeletedIndex = ListDetailsViewControl.SelectedIndex;
        HardwareInfoService.source2[0] = HardwareInfoService.source[HardwareInfoService.SeletedIndex];
    }
}

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using NewHardwareinfo.Models;
using NewHardwareinfo.Services;

namespace NewHardwareinfo.Views;

public sealed partial class HardwareListDetailControl : UserControl
{
    public HardwareData? ListDetailsMenuItem
    {
        get => GetValue(ListDetailsMenuItemProperty) as HardwareData;
        set => SetValue(ListDetailsMenuItemProperty, value);
    }

    public static readonly DependencyProperty ListDetailsMenuItemProperty = DependencyProperty.Register("ListDetailsMenuItem", typeof(HardwareData), typeof(HardwareListDetailControl), new PropertyMetadata(null, OnListDetailsMenuItemPropertyChanged));

    public HardwareListDetailControl()
    {
        InitializeComponent();

        lv_hardwaredetail.ItemsSource = HardwareInfoService.source2;
    }

    private static void OnListDetailsMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
    }
}

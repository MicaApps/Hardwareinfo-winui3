using CommunityToolkit.Mvvm.ComponentModel;

using NewHardwareinfo.Contracts.ViewModels;
using NewHardwareinfo.Models;
using NewHardwareinfo.Services;

namespace NewHardwareinfo.ViewModels;

public class HardwareGridDetailViewModel : ObservableRecipient, INavigationAware
{
    private HardwareData? _item;

    public HardwareData? Item
    {
        get => _item;
        set => SetProperty(ref _item, value);
    }


    public void OnNavigatedTo(object parameter)
    {
        if (parameter is string name)
        {
            var index = HardwareInfoService.source.IndexOf(HardwareInfoService.source.First(o=>o.Name==name));
            HardwareInfoService.SeletedIndex =index;
            HardwareInfoService.source2[0] = HardwareInfoService.source[HardwareInfoService.SeletedIndex];
        }
    }

    public void OnNavigatedFrom()
    {
    }
}

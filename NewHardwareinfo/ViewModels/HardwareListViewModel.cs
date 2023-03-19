using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;

using NewHardwareinfo.Contracts.ViewModels;
using NewHardwareinfo.Models;

namespace NewHardwareinfo.ViewModels;

public class HardwareListViewModel : ObservableRecipient, INavigationAware
{
    private HardwareData? _selected;

    public HardwareData? Selected
    {
        get => _selected;
        set => SetProperty(ref _selected, value);
    }

    public ObservableCollection<HardwareData> SampleItems { get; private set; } = new ObservableCollection<HardwareData>();


    public void OnNavigatedTo(object parameter)
    {
      
    }

    public void OnNavigatedFrom()
    {
    }

    public void EnsureItemSelected()
    {

    }
}

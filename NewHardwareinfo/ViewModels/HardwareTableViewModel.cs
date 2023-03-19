using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;

using NewHardwareinfo.Contracts.ViewModels;
using NewHardwareinfo.Models;

namespace NewHardwareinfo.ViewModels;

public class HardwareTableViewModel : ObservableRecipient, INavigationAware
{

    public ObservableCollection<HardwareData> Source { get; } = new ObservableCollection<HardwareData>();


    public async void OnNavigatedTo(object parameter)
    {
    }

    public void OnNavigatedFrom()
    {
    }
}

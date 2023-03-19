using System.Collections.ObjectModel;
using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using NewHardwareinfo.Contracts.Services;
using NewHardwareinfo.Contracts.ViewModels;
using NewHardwareinfo.Models;

namespace NewHardwareinfo.ViewModels;

public class HardwareGridViewModel : ObservableRecipient, INavigationAware
{
    private readonly INavigationService _navigationService;

    public ICommand ItemClickCommand
    {
        get;
    }

    public ObservableCollection<HardwareData> Source { get; } = new ObservableCollection<HardwareData>();

    public HardwareGridViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;

        ItemClickCommand = new RelayCommand<HardwareData>(OnItemClick);
    }

    public async void OnNavigatedTo(object parameter)
    {
        
    }

    public void OnNavigatedFrom()
    {
    }

    private void OnItemClick(HardwareData? clickedItem)
    {
        if (clickedItem != null)
        {
            _navigationService.SetListDataItemForNextConnectedAnimation(clickedItem);
            _navigationService.NavigateTo(typeof(HardwareGridDetailViewModel).FullName!, clickedItem.Name);
        }
    }
}

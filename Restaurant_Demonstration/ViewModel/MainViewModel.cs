using Restaurant_Demonstration.Command;
using System.Threading.Tasks;

namespace Restaurant_Demonstration.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        private ViewModelBase? _selectedViewModel;
        public MainViewModel(ManagerViewModel managerViewModel,
            ProductsViewModel productsViewModel)
        {
            ManagerViewModel = managerViewModel;
            ProductsViewModel = productsViewModel;
            SelectedViewModel = ManagerViewModel;
            SelectViewModelCommand = new DelegateCommand(SelectViewModel);
        }
        public ViewModelBase? SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                RaisePropertyChanged();
            }
        }
        public ManagerViewModel ManagerViewModel { get; }
        public ProductsViewModel ProductsViewModel { get; }
        public DelegateCommand SelectViewModelCommand { get; }
        public override async Task LoadAsync()
        {
            if (SelectedViewModel is not null)
            {
                await SelectedViewModel.LoadAsync();
            }
        }
        private async void SelectViewModel(object? parameter)
        {
            SelectedViewModel = parameter as ViewModelBase;
            await LoadAsync();
        }
    }
}

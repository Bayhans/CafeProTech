using Restaurant_Demonstration.Command;
using Restaurant_Demonstration.Data;
using Restaurant_Demonstration.Model;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Restaurant_Demonstration.ViewModel
{
    public class ManagerViewModel : ViewModelBase
    {
        private readonly ICustomersDataProvider _customersDataProvider;
        private CustomerItemViewModel? _selectedCustomer;
        private NavigationSide _navigationSide;

        public ManagerViewModel(ICustomersDataProvider customersDataProvider)
        {
            _customersDataProvider = customersDataProvider;
            AddCommand = new DelegateCommand(Add);
            MoveNavigationCommand = new DelegateCommand(MoveNavigation);
            DeleteCommand = new DelegateCommand(Delete, CanDelete);
        }
        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();
        public CustomerItemViewModel? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(IsCustomerSelected));
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }
        public bool IsCustomerSelected => SelectedCustomer is not null;
        public NavigationSide NavigationSide
        {
            get => _navigationSide;
            private set
            {
                _navigationSide = value;
                RaisePropertyChanged();
            }
        }

        public DelegateCommand AddCommand { get; }
        public DelegateCommand MoveNavigationCommand { get; }
        public DelegateCommand DeleteCommand { get; }
        public override async Task LoadAsync()
        {
            if (Customers.Any())
            {
                return;
            }
            var customers = await _customersDataProvider.GetAllAsync();
            if (customers is not null)
            {
                foreach (var customer in customers)
                {
                    Customers.Add(new CustomerItemViewModel(customer));
                }
            }
        }
        private void Add(object? parameter)
        {
            var customer = new Customer { FirstName = "New" };
            var viewModel = new CustomerItemViewModel(customer);
            Customers.Add(viewModel);
            SelectedCustomer = viewModel;
        }
        private void MoveNavigation(object? parameter)
        {
            NavigationSide = NavigationSide == NavigationSide.Left
                ? NavigationSide.Right
                : NavigationSide.Left;
        }
        private void Delete(object? parameter)
        {
            if (SelectedCustomer is null) return;
            Customers.Remove(SelectedCustomer);
            SelectedCustomer = null;
        }
        private bool CanDelete(object? parameter) => SelectedCustomer is not null;
    }
    public enum NavigationSide
    {
        Left,
        Right,
    }
}

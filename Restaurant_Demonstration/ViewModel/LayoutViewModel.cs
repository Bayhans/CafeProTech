using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant_Demonstration.Command;
using Restaurant_Demonstration.Data;
using Restaurant_Demonstration.Model;

namespace Restaurant_Demonstration.ViewModel
{
    public class LayoutViewModel : ViewModelBase
    {
        
            private readonly ILayoutDataProvider _LayoutDataProvider;
            private LayoutItemsViewModel? _selectedLayout;

            public LayoutViewModel(ILayoutDataProvider layoutDataProvider)
            {
                _LayoutDataProvider = layoutDataProvider;
                LayoutAddCommand = new DelegateCommand(Add);
                LayoutDeleteCommand = new DelegateCommand(Delete, CanDelete);
            }
        public ObservableCollection<LayoutItemsViewModel> Layouts { get; } = new();
        public LayoutItemsViewModel? SelectedLayout
            {
                get => _selectedLayout;
                set
                {
                    _selectedLayout = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(IsLayoutSelected));
                    LayoutDeleteCommand.RaiseCanExecuteChanged();
                }
            }
            public bool IsLayoutSelected => SelectedLayout is not null;
          

            public DelegateCommand LayoutAddCommand { get; }
            public DelegateCommand LayoutDeleteCommand { get; }
            public override async Task LoadAsync()
            {
                if (Layouts.Any())
                {
                    return;
                }
                var layouts = await _LayoutDataProvider.GetAllAsync();
                if (layouts is not null)
                {
                    foreach (var layout in layouts)
                    {
                        Layouts.Add(new LayoutItemsViewModel(layout));
                    }
                }
            }
            private void Add(object? parameter)
            {
                var layout = new Layout { LayoutName = "New layout" };
                var layoutviewModel = new LayoutItemsViewModel(layout);
                Layouts.Add(layoutviewModel);
                SelectedLayout = layoutviewModel;
            }
            private void Delete(object? parameter)
            {
                if (SelectedLayout is null) return;
                Layouts.Remove(SelectedLayout);
                SelectedLayout = null;
            }
            private bool CanDelete(object? parameter) => SelectedLayout is not null;
        
    }
}

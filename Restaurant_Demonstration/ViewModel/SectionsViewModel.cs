using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Restaurant_Demonstration.Command;
using Restaurant_Demonstration.Data;
using Restaurant_Demonstration.Model;

namespace Restaurant_Demonstration.ViewModel
{
    public class SectionsViewModel : ViewModelBase
    {
        
            private readonly ILayoutDataProvider _LayoutDataProvider;
            private SectionsItemsViewModel? _selectedLayout;

            public SectionsViewModel(ILayoutDataProvider layoutDataProvider)
            {
                _LayoutDataProvider = layoutDataProvider;
                LayoutAddCommand = new DelegateCommand(AddLayout);
                LayoutDeleteCommand = new DelegateCommand(DeleteLayout, CanDeleteLayout);
            }
        public ObservableCollection<SectionsItemsViewModel> Layouts { get; } = new();
        public SectionsItemsViewModel? SelectedLayout
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
                        Layouts.Add(new SectionsItemsViewModel(layout));
                    }
                }
            }
            private void AddLayout(object? parameter)
            {
                var layout = new Section { SectionName = "New layout" };
                var layoutviewModel = new SectionsItemsViewModel(layout);
                Layouts.Add(layoutviewModel);
                SelectedLayout = layoutviewModel;
            }
            private void DeleteLayout(object? parameter)
            {
                if (SelectedLayout is null) return;
                Layouts.Remove(SelectedLayout);
                SelectedLayout = null;
            }
            private bool CanDeleteLayout(object? parameter) => SelectedLayout is not null;
        
    }
}

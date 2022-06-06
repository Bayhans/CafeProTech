using Restaurant_Demonstration.Model;

namespace Restaurant_Demonstration.ViewModel
{
    public class LayoutItemsViewModel: ValidationViewModelBase
    {
        private readonly Layout _layoutmodel;

        public LayoutItemsViewModel(Layout layoutmodel)
        {
            _layoutmodel = layoutmodel;
        }

        public int LayoutId => _layoutmodel.LayoutId;

        public string? LayoutName
        {
            get => _layoutmodel.LayoutName;
            set
            {
                _layoutmodel.LayoutName = value;
                RaisePropertyChanged();
                if (string.IsNullOrEmpty(_layoutmodel.LayoutName))
                {
                    AddError("layout name is required");
                }
                else
                {
                    ClearErrors();
                }
            }
        }
        public bool Avaliblity
        {
            get => _layoutmodel.Avaliblity;
            set
            {
                _layoutmodel.Avaliblity = value;
                RaisePropertyChanged();
            }
        }
    }
}

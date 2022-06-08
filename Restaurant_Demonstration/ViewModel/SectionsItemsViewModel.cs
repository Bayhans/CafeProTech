using Restaurant_Demonstration.Model;

namespace Restaurant_Demonstration.ViewModel
{
    public class SectionsItemsViewModel: ValidationViewModelBase
    {
        private readonly Section _layoutModel;

        public SectionsItemsViewModel(Section layoutmodel)
        {
            _layoutModel = layoutmodel;
        }

        public int SectionsId => _layoutModel.SectionId;

        public string? LayoutName
        {
            get => _layoutModel.SectionName;
            set
            {
                _layoutModel.SectionName = value;
                RaisePropertyChanged();
                if (string.IsNullOrEmpty(_layoutModel.SectionName))
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
            get => _layoutModel.Avaliblity;
            set
            {
                _layoutModel.Avaliblity = value;
                RaisePropertyChanged();
            }
        }
    }
}

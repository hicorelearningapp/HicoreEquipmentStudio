using System.ComponentModel;

namespace HiCore.EquipmentFramework.Config.Models
{
    public class RecipeModel : INotifyPropertyChanged
    {
        private string _recipeID;
        private string _recipeName;
        private string _description;
        private string _dataSourceType;
        private string _address;
        private string _dataFormat;
        private int _parameterCount;
        private bool _enabled;

        public string RecipeID
        {
            get => _recipeID;
            set { _recipeID = value; OnPropertyChanged(nameof(RecipeID)); }
        }

        public string RecipeName
        {
            get => _recipeName;
            set { _recipeName = value; OnPropertyChanged(nameof(RecipeName)); }
        }

        public string Description
        {
            get => _description;
            set { _description = value; OnPropertyChanged(nameof(Description)); }
        }

        public string DataSourceType
        {
            get => _dataSourceType;
            set { _dataSourceType = value; OnPropertyChanged(nameof(DataSourceType)); }
        }

        public string Address
        {
            get => _address;
            set { _address = value; OnPropertyChanged(nameof(Address)); }
        }

        public string DataFormat
        {
            get => _dataFormat;
            set { _dataFormat = value; OnPropertyChanged(nameof(DataFormat)); }
        }

        public int ParameterCount
        {
            get => _parameterCount;
            set { _parameterCount = value; OnPropertyChanged(nameof(ParameterCount)); }
        }

        public bool Enabled
        {
            get => _enabled;
            set { _enabled = value; OnPropertyChanged(nameof(Enabled)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
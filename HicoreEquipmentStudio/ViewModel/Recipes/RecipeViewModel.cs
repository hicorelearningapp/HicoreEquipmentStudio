using HicoreEquipmentStudio.Commands;
using HicoreEquipmentStudio.Interfaces;
using HicoreEquipmentStudio.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HicoreEquipmentStudio.ViewModel.Recipes
{
    public class RecipeViewModel : BaseViewModel, IJsonSectionProvider
    {
        private RecipeModel _selectedRecipe;
        private RecipeModel _editingRecipe;
        private RecipeModel _originalRecipe;
        private bool _isEditMode;

        private string _searchText;

        public ObservableCollection<RecipeModel> Recipes { get; }

        public ObservableCollection<RecipeParameterModel> Parameters { get; }

        public ICommand AddRecipeCommand { get; }
        public ICommand EditRecipeCommand { get; }
        public ICommand DeleteRecipeCommand { get; }
        public ICommand SaveRecipeCommand { get; }
        public ICommand CancelRecipeCommand { get; }

        public RecipeModel SelectedRecipe
        {
            get => _selectedRecipe;
            set
            {
                _selectedRecipe = value;
                OnPropertyChanged();
            }
        }

        public RecipeModel EditingRecipe
        {
            get => _editingRecipe;
            set
            {
                _editingRecipe = value;
                OnPropertyChanged();
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
            }
        }

        public string LastReadTime { get; set; }

        public string CurrentRecipeID { get; set; }

        public int ParameterCount { get; set; }

        public string Checksum { get; set; }

        public string SectionName => "recipes";

        public RecipeViewModel()
        {
            Recipes = new ObservableCollection<RecipeModel>();
            Parameters = new ObservableCollection<RecipeParameterModel>();

            LoadParameters();

            LastReadTime = "";
            CurrentRecipeID = "";
            ParameterCount = 0;
            Checksum = "";

            AddRecipeCommand =
                new RelayCommand(AddRecipe);

            EditRecipeCommand =
                new RelayCommand(EditRecipe);

            DeleteRecipeCommand =
                new RelayCommand(DeleteRecipe);

            SaveRecipeCommand =
                new RelayCommand(SaveRecipe);

            CancelRecipeCommand =
                new RelayCommand(CancelRecipe);
        }

        private void AddRecipe()
        {
            _isEditMode = false;

            EditingRecipe = new RecipeModel
            {
                Enabled = true
            };
        }

        private void EditRecipe()
        {
            if (SelectedRecipe == null)
                return;

            _isEditMode = true;
            _originalRecipe = SelectedRecipe;

            EditingRecipe = new RecipeModel
            {
                RecipeID = SelectedRecipe.RecipeID,
                RecipeName = SelectedRecipe.RecipeName,
                Description = SelectedRecipe.Description,
                DataSourceType = SelectedRecipe.DataSourceType,
                Address = SelectedRecipe.Address,
                DataFormat = SelectedRecipe.DataFormat,
                ParameterCount = SelectedRecipe.ParameterCount,
                Enabled = SelectedRecipe.Enabled
            };
        }

        private void SaveRecipe()
        {
            if (EditingRecipe == null)
                return;

            if (_isEditMode)
            {
                _originalRecipe.RecipeID = EditingRecipe.RecipeID;
                _originalRecipe.RecipeName = EditingRecipe.RecipeName;
                _originalRecipe.Description = EditingRecipe.Description;
                _originalRecipe.DataSourceType = EditingRecipe.DataSourceType;
                _originalRecipe.Address = EditingRecipe.Address;
                _originalRecipe.DataFormat = EditingRecipe.DataFormat;
                _originalRecipe.ParameterCount = EditingRecipe.ParameterCount;
                _originalRecipe.Enabled = EditingRecipe.Enabled;

                OnPropertyChanged(nameof(Recipes));
            }
            else
            {
                Recipes.Add(new RecipeModel
                {
                    RecipeID = EditingRecipe.RecipeID,
                    RecipeName = EditingRecipe.RecipeName,
                    Description = EditingRecipe.Description,
                    DataSourceType = EditingRecipe.DataSourceType,
                    Address = EditingRecipe.Address,
                    DataFormat = EditingRecipe.DataFormat,
                    ParameterCount = EditingRecipe.ParameterCount,
                    Enabled = EditingRecipe.Enabled
                });
            }

            EditingRecipe = null;
        }

        private void DeleteRecipe()
        {
            if (SelectedRecipe == null)
                return;

            Recipes.Remove(SelectedRecipe);

            if (Recipes.Count > 0)
                SelectedRecipe = Recipes[0];
            else
                SelectedRecipe = null;
        }

        private void CancelRecipe()
        {
            EditingRecipe = null;
        }

        private void LoadParameters()
        {
            Parameters.Add(new RecipeParameterModel
            {
                Index = 1,
                ParameterName = "Temperature",
                Address = "41000",
                DataType = "Int16",
                DefaultValue = "60",
                Units = "°C"
            });

            Parameters.Add(new RecipeParameterModel
            {
                Index = 2,
                ParameterName = "Conveyor Speed",
                Address = "41001",
                DataType = "Int16",
                DefaultValue = "100",
                Units = "%"
            });

            Parameters.Add(new RecipeParameterModel
            {
                Index = 3,
                ParameterName = "Spray Time",
                Address = "41002",
                DataType = "Int16",
                DefaultValue = "30",
                Units = "s"
            });
        }

        public override void Initialize()
        {
        }

        public object GetExportData()
        {
            return Recipes;
        }
    }
}
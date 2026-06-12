using HiCore.EquipmentFramework.Config.Commands;
using HiCore.EquipmentFramework.Config.Core;
using HiCore.EquipmentFramework.Config.Interfaces;
using HiCore.EquipmentFramework.Config.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HiCore.EquipmentFramework.Config.ViewModel.Recipes
{
    public class RecipeViewModel :
        BaseViewModel,
        IJsonSectionProvider
    {
        private readonly EquipmentManager _manager;

        private RecipeModel _selectedRecipe;
        private RecipeModel _editingRecipe;
        private RecipeModel _originalRecipe;
        private bool _isEditMode;

        private string _searchText;

        public ICommand AddRecipeCommand { get; private set; }

        public ICommand EditRecipeCommand { get; private set; }

        public ICommand DeleteRecipeCommand { get; private set; }

        public ICommand SaveRecipeCommand { get; private set; }

        public ICommand CancelRecipeCommand { get; private set; }

        public ObservableCollection<RecipeModel> Recipes
        {
            get { return _manager.Recipes; }
        }

        public ObservableCollection<RecipeParameterModel> Parameters
        {
            get;
            private set;
        }

        public RecipeModel SelectedRecipe
        {
            get { return _selectedRecipe; }
            set
            {
                _selectedRecipe = value;
                OnPropertyChanged();
            }
        }

        public RecipeModel EditingRecipe
        {
            get { return _editingRecipe; }
            set
            {
                _editingRecipe = value;
                OnPropertyChanged();
            }
        }

        public string SearchText
        {
            get { return _searchText; }
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

        public string SectionName
        {
            get { return "recipes"; }
        }

        public RecipeViewModel(
            EquipmentManager manager)
        {
            _manager = manager;

            Parameters =
                new ObservableCollection<RecipeParameterModel>();

            LoadParameters();

            LastReadTime = "--";
            CurrentRecipeID = "--";
            ParameterCount = 0;
            Checksum = "--";

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
                _originalRecipe.RecipeID =
                    EditingRecipe.RecipeID;

                _originalRecipe.RecipeName =
                    EditingRecipe.RecipeName;

                _originalRecipe.Description =
                    EditingRecipe.Description;

                _originalRecipe.DataSourceType =
                    EditingRecipe.DataSourceType;

                _originalRecipe.Address =
                    EditingRecipe.Address;

                _originalRecipe.DataFormat =
                    EditingRecipe.DataFormat;

                _originalRecipe.ParameterCount =
                    EditingRecipe.ParameterCount;

                _originalRecipe.Enabled =
                    EditingRecipe.Enabled;

                OnPropertyChanged(nameof(Recipes));
            }
            else
            {
                RecipeModel recipe =
                    new RecipeModel
                    {
                        RecipeID = EditingRecipe.RecipeID,
                        RecipeName = EditingRecipe.RecipeName,
                        Description = EditingRecipe.Description,
                        DataSourceType = EditingRecipe.DataSourceType,
                        Address = EditingRecipe.Address,
                        DataFormat = EditingRecipe.DataFormat,
                        ParameterCount = EditingRecipe.ParameterCount,
                        Enabled = EditingRecipe.Enabled
                    };

                _manager.Recipes.Add(recipe);

                SelectedRecipe = recipe;
            }

            EditingRecipe = null;
            _isEditMode = false;
        }

        private void DeleteRecipe()
        {
            if (SelectedRecipe == null)
                return;

            _manager.Recipes.Remove(
                SelectedRecipe);

            if (_manager.Recipes.Count > 0)
            {
                SelectedRecipe =
                    _manager.Recipes[0];
            }
            else
            {
                SelectedRecipe = null;
            }
        }

        private void CancelRecipe()
        {
            EditingRecipe = null;
            _isEditMode = false;
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
            return _manager.Recipes;
        }
    }
}
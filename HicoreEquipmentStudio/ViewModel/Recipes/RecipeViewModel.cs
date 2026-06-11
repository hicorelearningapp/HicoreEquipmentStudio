using HicoreEquipmentStudio.Models;
using System.Collections.ObjectModel;

namespace HicoreEquipmentStudio.ViewModel.Recipes
{
    public class RecipeViewModel : BaseViewModel
    {
        private RecipeModel _selectedRecipe;

        public ObservableCollection<RecipeModel> Recipes { get; }

        public ObservableCollection<RecipeParameterModel> Parameters { get; }

        public RecipeModel SelectedRecipe
        {
            get => _selectedRecipe;
            set
            {
                _selectedRecipe = value;
                OnPropertyChanged();
            }
        }

        public string SearchText { get; set; }

        public string LastReadTime { get; set; }

        public string CurrentRecipeID { get; set; }

        public int ParameterCount { get; set; }

        public string Checksum { get; set; }

        public RecipeViewModel()
        {
            Recipes = new ObservableCollection<RecipeModel>();
            Parameters = new ObservableCollection<RecipeParameterModel>();

            LoadRecipes();
            LoadParameters();

            LastReadTime = "20-May-2025 10:22:18 AM";
            CurrentRecipeID = "R001 - Standard Clean";
            ParameterCount = 25;
            Checksum = "0x1A2B";
        }

        private void LoadRecipes()
        {
            Recipes.Add(new RecipeModel
            {
                RecipeID = "R001",
                RecipeName = "Standard Clean",
                Description = "Standard cleaning recipe",
                DataSourceType = "Register Block",
                Address = "41000",
                DataFormat = "Binary",
                ParameterCount = 25,
                Enabled = true
            });

            Recipes.Add(new RecipeModel
            {
                RecipeID = "R002",
                RecipeName = "Heavy Clean",
                Description = "Heavy contamination cleaning",
                DataSourceType = "Register Block",
                Address = "42000",
                DataFormat = "Binary",
                ParameterCount = 25,
                Enabled = true
            });

            Recipes.Add(new RecipeModel
            {
                RecipeID = "R003",
                RecipeName = "PCB Clean",
                Description = "PCB specific cleaning recipe",
                DataSourceType = "Register Block",
                Address = "43000",
                DataFormat = "Binary",
                ParameterCount = 25,
                Enabled = true
            });

            SelectedRecipe = Recipes[0];
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

            Parameters.Add(new RecipeParameterModel
            {
                Index = 4,
                ParameterName = "Rinse Time",
                Address = "41003",
                DataType = "Int16",
                DefaultValue = "20",
                Units = "s"
            });

            Parameters.Add(new RecipeParameterModel
            {
                Index = 5,
                ParameterName = "Dry Time",
                Address = "41004",
                DataType = "Int16",
                DefaultValue = "60",
                Units = "s"
            });
        }

        public override void Initialize()
        {
        }
    }
}
using HiCore.EquipmentFramework.Config.Model;
using HiCore.EquipmentFramework.Config.Models;
using HiCore.EquipmentFramework.Config.View.Alarms;
using HiCore.EquipmentFramework.Config.View.Commands;
using HiCore.EquipmentFramework.Config.View.Events;
using HiCore.EquipmentFramework.Config.View.Mapping;
using HiCore.EquipmentFramework.Config.View.Recipes;
using HiCore.EquipmentFramework.Config.View.Variable;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace HiCore.EquipmentFramework.Config.ViewModel.Mapping
{
    public class MappingViewModel : BaseViewModel
    {
        private int _selectedTabIndex;

        private UserControl _currentGridView;
        private UserControl _currentDetailsView;
      
        // =====================================================
        // TAB INDEX
        // =====================================================

        public int SelectedTabIndex
        {
            get => _selectedTabIndex;
            set
            {
                _selectedTabIndex = value;
                OnPropertyChanged();

                UpdateCurrentViews();
            }
        }

        // =====================================================
        // CURRENT DYNAMIC VIEW
        // =====================================================

        public UserControl CurrentGridView
        {
            get => _currentGridView;
            set
            {
                _currentGridView = value;
                OnPropertyChanged();
            }
        }

        public UserControl CurrentDetailsView
        {
            get => _currentDetailsView;
            set
            {
                _currentDetailsView = value;
                OnPropertyChanged();
            }
        }

        // =====================================================
        // COLLECTIONS
        // =====================================================

        public ObservableCollection<AlarmModel> Alarms { get; set; }

        public ObservableCollection<EventModel> Events { get; set; }

        public ObservableCollection<CommandModel> Commands { get; set; }

        public ObservableCollection<RecipeModel> Recipes { get; set; }

        public ObservableCollection<VariableModel> Variables { get; set; }

        // =====================================================
        // SELECTED ITEMS
        // =====================================================

        public AlarmModel SelectedAlarm { get; set; }

        public EventModel SelectedEvent { get; set; }

        public CommandModel SelectedCommand { get; set; }

        public RecipeModel SelectedRecipe { get; set; }

        public VariableModel SelectedVariable { get; set; }

        // =====================================================
        // SUMMARY
        // =====================================================

        public int VariableCount => Variables.Count;

        public int AlarmCount => Alarms.Count;

        public int EventCount => Events.Count;

        public int CommandCount => Commands.Count;

        public int RecipeCount => Recipes.Count;

        public string TotalText
        {
            get
            {
                switch (SelectedTabIndex)
                {
                    case 0:
                        return "Total SVID Mappings : " + Variables.Count;

                    case 1:
                        return "Total ALID Mappings : " + Alarms.Count;

                    case 2:
                        return "Total CEID Mappings : " + Events.Count;

                    case 3:
                        return "Total RCMD Mappings : " + Commands.Count;

                    case 4:
                        return "Total PPID Mappings : " + Recipes.Count;

                    default:
                        return "";
                }
            }
        }

        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        public MappingViewModel()
        {
            LoadSampleData();

            SelectedTabIndex = 0;

            UpdateCurrentViews();
        }

        // =====================================================
        // UPDATE VIEWS
        // =====================================================

        private void UpdateCurrentViews()
        {
            switch (SelectedTabIndex)
            {
                // =================================================
                // VARIABLES
                // =================================================

                case 0:

                    CurrentGridView = new VariableGridControl
                    {
                        DataContext = this
                    };

                    CurrentDetailsView = new VariableDetailsControl
                    {
                        DataContext = this
                    };

                    break;

                // =================================================
                // ALARMS
                // =================================================

                case 1:

                    CurrentGridView = new AlarmMappingGridControl
                    {
                        DataContext = this
                    };

                    CurrentDetailsView = new AlarmDetailsControl
                    {
                        DataContext = this
                    };

                    break;

                // =================================================
                // EVENTS
                // =================================================

                case 2:

                    CurrentGridView = new EventMappingGridControl
                    {
                        DataContext = this
                    };

                    CurrentDetailsView = new EventDetailsControl
                    {
                        DataContext = this
                    };

                    break;

                // =================================================
                // COMMANDS
                // =================================================

                case 3:

                    CurrentGridView = new CommandMappingGridControl
                    {
                        DataContext = this
                    };

                    CurrentDetailsView = new CommandDetailsControl
                    {
                        DataContext = this
                    };

                    break;

                // =================================================
                // RECIPES
                // =================================================

                case 4:

                    CurrentGridView = new RecipeMappingGridControl
                    {
                        DataContext = this
                    };

                    CurrentDetailsView = new RecipeDetailsControl
                    {
                        DataContext = this
                    };

                    break;
            }

            OnPropertyChanged(nameof(TotalText));
        }

        // =====================================================
        // SAMPLE DATA
        // =====================================================

        private void LoadSampleData()
        {
            // VARIABLES

            Variables = new ObservableCollection<VariableModel>
            {
                new VariableModel
                {
                    SVID = 1001,
                    Name = "Temperature",
                    Address = "40001",
                    DataType = "FLOAT64",
                    Access = "R",
                    Units = "°C",
                    Category = "Equipment",
                    PollInterval = 1000,
                    Description = "Process Temperature"
                },

                new VariableModel
                {
                    SVID = 1002,
                    Name = "Pressure",
                    Address = "40002",
                    DataType = "FLOAT64",
                    Access = "R/W",
                    Units = "psi",
                    Category = "Equipment",
                    PollInterval = 1000,
                    Description = "Line Pressure"
                }
            };

            // ALARMS

            Alarms = new ObservableCollection<AlarmModel>
            {
                new AlarmModel
                {
                    ALID = 2001,
                    AlarmName = "Heater Fault",
                    SourceType = "PLC",
                    Address = "50001",
                    Condition = "ON",
                    Severity = "High",
                    Category = "Process",
                    Enabled = true,
                    Description = "Heater Error"
                }
            };

            // EVENTS

            Events = new ObservableCollection<EventModel>
            {
                new EventModel
                {
                    CEID = 3001,
                    EventName = "Process Started",
                    SourceType = "PLC",
                    SourceAddress = "60001",
                    TriggerCondition = "1",
                    ReportType = "S6F11",
                    Enabled = true,
                    Description = "Start Event"
                }
            };

            // COMMANDS

            Commands = new ObservableCollection<CommandModel>
            {
                new CommandModel
                {
                    CommandCode = "R001",
                    CommandName = "Start",
                    Address = "70001",
                    DataType = "BOOL",
                    WriteValue = "1",
                    ReadbackAddress = "70002",
                    ReadbackValue = "1",
                    Enabled = true,
                    Description = "Start Command"
                }
            };

            // RECIPES

            Recipes = new ObservableCollection<RecipeModel>
            {
                new RecipeModel
                {
                    RecipeID = "P001",
                    RecipeName = "Standard Clean",
                    DataSourceType = "PLC",
                    Address = "80001",
                    DataFormat = "Binary",
                    ParameterCount = 25,
                    Enabled = true,
                    Description = "Main Recipe"
                }
            };
        }
    }
}
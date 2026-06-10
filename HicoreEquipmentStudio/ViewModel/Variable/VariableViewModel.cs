using HicoreEquipmentStudio.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HicoreEquipmentStudio.ViewModel.Variable
{
    public class VariableViewModel : BaseViewModel
    {
        private VariableModel _selectedVariable;
        private string _searchText;

        private string _lastReadTime;
        private string _currentValue;
        private string _status;

        public ObservableCollection<VariableModel> Variables { get; }

        public ObservableCollection<ReadHistoryModel> ReadHistory { get; }

        public VariableModel SelectedVariable
        {
            get => _selectedVariable;
            set
            {
                _selectedVariable = value;
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

        public string LastReadTime
        {
            get => _lastReadTime;
            set
            {
                _lastReadTime = value;
                OnPropertyChanged();
            }
        }

        public string CurrentValue
        {
            get => _currentValue;
            set
            {
                _currentValue = value;
                OnPropertyChanged();
            }
        }

        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        public VariableViewModel()
        {
            Variables = new ObservableCollection<VariableModel>();
            ReadHistory = new ObservableCollection<ReadHistoryModel>();

            LoadSampleData();
            LoadSampleHistory();
        }

        private void LoadSampleData()
        {
            Variables.Add(new VariableModel
            {
                Name = "Temperature",
                Address = "40001",
                DataType = "Double",
                Category = "Process",
                Access = "Read Only",
                PollInterval = 1000,
                SVID = 1001,
                Units = "°C",
                Description = "Process Temperature"
            });

            Variables.Add(new VariableModel
            {
                Name = "RecipeId",
                Address = "40002",
                DataType = "Int32",
                Category = "Recipe",
                Access = "Read Only",
                PollInterval = 1000,
                SVID = 1002,
                Units = "-",
                Description = "Current Recipe ID"
            });

            SelectedVariable = Variables[0];
        }

        private void LoadSampleHistory()
        {
            LastReadTime = "20-May-2025 10:22:18 AM";
            CurrentValue = "25.62 °C";
            Status = "Success";

            ReadHistory.Add(new ReadHistoryModel
            {
                Time = "10:22:18 AM",
                Value = "25.62"
            });

            ReadHistory.Add(new ReadHistoryModel
            {
                Time = "10:22:08 AM",
                Value = "25.58"
            });

            ReadHistory.Add(new ReadHistoryModel
            {
                Time = "10:21:58 AM",
                Value = "25.61"
            });
        }

        public override void Initialize()
        {
        }
    }
}

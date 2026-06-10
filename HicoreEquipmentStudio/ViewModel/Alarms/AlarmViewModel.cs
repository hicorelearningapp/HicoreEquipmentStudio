using HicoreEquipmentStudio.Model;
using System.Collections.ObjectModel;

namespace HicoreEquipmentStudio.ViewModel.Alarms
{
    public class AlarmViewModel : BaseViewModel
    {
        private AlarmModel _selectedAlarm;

        private string _searchText;
        private string _lastChangeTime;
        private string _currentValue;
        private string _alarmStatus;
        private string _active;

        public ObservableCollection<AlarmModel> Alarms { get; }

        public ObservableCollection<AlarmHistoryModel> AlarmHistory { get; }

        public AlarmModel SelectedAlarm
        {
            get => _selectedAlarm;
            set
            {
                _selectedAlarm = value;
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

        public string LastChangeTime
        {
            get => _lastChangeTime;
            set
            {
                _lastChangeTime = value;
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

        public string AlarmStatus
        {
            get => _alarmStatus;
            set
            {
                _alarmStatus = value;
                OnPropertyChanged();
            }
        }

        public string Active
        {
            get => _active;
            set
            {
                _active = value;
                OnPropertyChanged();
            }
        }

        public AlarmViewModel()
        {
            Alarms = new ObservableCollection<AlarmModel>();
            AlarmHistory = new ObservableCollection<AlarmHistoryModel>();

            LoadSampleData();
            LoadSampleHistory();
        }

        private void LoadSampleData()
        {
            Alarms.Add(new AlarmModel
            {
                ALID = 2001,
                AlarmName = "Heater Fault",
                SourceType = "Register",
                Address = "40010",
                Condition = "= 1",
                Severity = "Critical",
                Category = "Equipment",
                Enabled = true,
                Description = "Heater over temperature or fault"
            });

            Alarms.Add(new AlarmModel
            {
                ALID = 2002,
                AlarmName = "Pump Fault",
                SourceType = "Register",
                Address = "40011",
                Condition = "= 1",
                Severity = "Critical",
                Category = "Equipment",
                Enabled = true,
                Description = "Pump motor fault"
            });

            SelectedAlarm = Alarms[0];
        }

        private void LoadSampleHistory()
        {
            LastChangeTime = "20-May-2025 10:22:18 AM";
            CurrentValue = "0";
            AlarmStatus = "Normal";
            Active = "No";

            AlarmHistory.Add(new AlarmHistoryModel
            {
                Time = "20-May-2025 10:15:12",
                Status = "Cleared",
                Value = "0"
            });

            AlarmHistory.Add(new AlarmHistoryModel
            {
                Time = "20-May-2025 09:45:08",
                Status = "Raised",
                Value = "1"
            });

            AlarmHistory.Add(new AlarmHistoryModel
            {
                Time = "20-May-2025 09:40:03",
                Status = "Cleared",
                Value = "0"
            });
        }

        public override void Initialize()
        {
        }
    }
}
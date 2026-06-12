using HicoreEquipmentStudio.Commands;
using HicoreEquipmentStudio.Interfaces;
using HicoreEquipmentStudio.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HicoreEquipmentStudio.ViewModel.Alarms
{
    public class AlarmViewModel : BaseViewModel, IJsonSectionProvider
    {
        private AlarmModel _selectedAlarm;
        private AlarmModel _editingAlarm;

        private bool _isEditMode;

        private string _searchText;
        private string _lastChangeTime;
        private string _currentValue;
        private string _alarmStatus;
        private string _active;

        public ICommand AddAlarmCommand { get; }
        public ICommand EditAlarmCommand { get; }
        public ICommand DeleteAlarmCommand { get; }
        public ICommand SaveAlarmCommand { get; }
        public ICommand CancelAlarmCommand { get; }

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

        public AlarmModel EditingAlarm
        {
            get => _editingAlarm;
            set
            {
                _editingAlarm = value;
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

        public string SectionName => "alarms";

        public AlarmViewModel()
        {
            Alarms = new ObservableCollection<AlarmModel>();
            AlarmHistory = new ObservableCollection<AlarmHistoryModel>();

            AddAlarmCommand = new RelayCommand(AddAlarm);
            EditAlarmCommand = new RelayCommand(EditAlarm);
            DeleteAlarmCommand = new RelayCommand(DeleteAlarm);
            SaveAlarmCommand = new RelayCommand(SaveAlarm);
            CancelAlarmCommand = new RelayCommand(CancelAlarm);

            LoadSampleHistory();
        }

        private void AddAlarm()
        {
            _isEditMode = false;

            EditingAlarm = new AlarmModel();
        }

        private void EditAlarm()
        {
            if (SelectedAlarm == null)
                return;

            _isEditMode = true;

            EditingAlarm = new AlarmModel
            {
                ALID = SelectedAlarm.ALID,
                AlarmName = SelectedAlarm.AlarmName,
                SourceType = SelectedAlarm.SourceType,
                Address = SelectedAlarm.Address,
                Condition = SelectedAlarm.Condition,
                Severity = SelectedAlarm.Severity,
                Category = SelectedAlarm.Category,
                Enabled = SelectedAlarm.Enabled,
                Description = SelectedAlarm.Description
            };
        }

        private void SaveAlarm()
        {
            if (EditingAlarm == null)
                return;

            if (_isEditMode)
            {
                SelectedAlarm.ALID = EditingAlarm.ALID;
                SelectedAlarm.AlarmName = EditingAlarm.AlarmName;
                SelectedAlarm.SourceType = EditingAlarm.SourceType;
                SelectedAlarm.Address = EditingAlarm.Address;
                SelectedAlarm.Condition = EditingAlarm.Condition;
                SelectedAlarm.Severity = EditingAlarm.Severity;
                SelectedAlarm.Category = EditingAlarm.Category;
                SelectedAlarm.Enabled = EditingAlarm.Enabled;
                SelectedAlarm.Description = EditingAlarm.Description;
            }
            else
            {
                Alarms.Add(new AlarmModel
                {
                    ALID = EditingAlarm.ALID,
                    AlarmName = EditingAlarm.AlarmName,
                    SourceType = EditingAlarm.SourceType,
                    Address = EditingAlarm.Address,
                    Condition = EditingAlarm.Condition,
                    Severity = EditingAlarm.Severity,
                    Category = EditingAlarm.Category,
                    Enabled = EditingAlarm.Enabled,
                    Description = EditingAlarm.Description
                });
            }

            EditingAlarm = null;
            _isEditMode = false;
        }

        private void DeleteAlarm()
        {
            if (SelectedAlarm == null)
                return;

            Alarms.Remove(SelectedAlarm);

            SelectedAlarm = null;
        }

        private void CancelAlarm()
        {
            EditingAlarm = null;
            _isEditMode = false;
        }

        private void LoadSampleHistory()
        {
            LastChangeTime = "--";
            CurrentValue = "--";
            AlarmStatus = "--";
            Active = "--";
        }

        public override void Initialize()
        {
        }

        public object GetExportData()
        {
            return Alarms;
        }
    }
}
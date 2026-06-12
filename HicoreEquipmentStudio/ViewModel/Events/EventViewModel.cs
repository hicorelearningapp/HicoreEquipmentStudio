using HiCore.EquipmentFramework.Config.Commands;
using HiCore.EquipmentFramework.Config.Core;
using HiCore.EquipmentFramework.Config.Interfaces;
using HiCore.EquipmentFramework.Config.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HiCore.EquipmentFramework.Config.ViewModel.Events
{
    public class EventViewModel :
        BaseViewModel,
        IJsonSectionProvider
    {
        private readonly EquipmentManager _manager;

        private EventModel _selectedEvent;
        private EventModel _editingEvent;

        private string _searchText;
        private string _lastOccurredTime;
        private string _currentValue;
        private string _eventStatus;
        private string _active;

        private bool _isEditMode;

        public ICommand AddEventCommand { get; private set; }
        public ICommand EditEventCommand { get; private set; }
        public ICommand DeleteEventCommand { get; private set; }
        public ICommand SaveEventCommand { get; private set; }
        public ICommand CancelEventCommand { get; private set; }

        public ObservableCollection<EventModel> Events
        {
            get
            {
                return _manager.Events;
            }
        }

        public ObservableCollection<EventHistoryModel> EventHistory
        {
            get;
            private set;
        }

        public EventModel SelectedEvent
        {
            get { return _selectedEvent; }
            set
            {
                _selectedEvent = value;
                OnPropertyChanged();
            }
        }

        public EventModel EditingEvent
        {
            get { return _editingEvent; }
            set
            {
                _editingEvent = value;
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

        public string LastOccurredTime
        {
            get { return _lastOccurredTime; }
            set
            {
                _lastOccurredTime = value;
                OnPropertyChanged();
            }
        }

        public string CurrentValue
        {
            get { return _currentValue; }
            set
            {
                _currentValue = value;
                OnPropertyChanged();
            }
        }

        public string EventStatus
        {
            get { return _eventStatus; }
            set
            {
                _eventStatus = value;
                OnPropertyChanged();
            }
        }

        public string Active
        {
            get { return _active; }
            set
            {
                _active = value;
                OnPropertyChanged();
            }
        }

        public string SectionName
        {
            get { return "events"; }
        }

        public EventViewModel(
            EquipmentManager manager)
        {
            _manager = manager;

            EventHistory =
                new ObservableCollection<EventHistoryModel>();

            AddEventCommand =
                new RelayCommand(AddEvent);

            EditEventCommand =
                new RelayCommand(EditEvent);

            DeleteEventCommand =
                new RelayCommand(DeleteEvent);

            SaveEventCommand =
                new RelayCommand(SaveEvent);

            CancelEventCommand =
                new RelayCommand(CancelEvent);

            LoadSampleHistory();
        }

        private void AddEvent()
        {
            _isEditMode = false;

            EditingEvent = new EventModel
            {
                Enabled = true
            };
        }

        private void EditEvent()
        {
            if (SelectedEvent == null)
                return;

            _isEditMode = true;

            EditingEvent = new EventModel
            {
                CEID = SelectedEvent.CEID,
                EventName = SelectedEvent.EventName,
                Description = SelectedEvent.Description,
                SourceType = SelectedEvent.SourceType,
                SourceAddress = SelectedEvent.SourceAddress,
                TriggerCondition = SelectedEvent.TriggerCondition,
                ReportType = SelectedEvent.ReportType,
                Enabled = SelectedEvent.Enabled,

                EventPriority = SelectedEvent.EventPriority,
                EventCategory = SelectedEvent.EventCategory,
                AlarmRelated = SelectedEvent.AlarmRelated,
                MinimumInterval = SelectedEvent.MinimumInterval,
                Data1 = SelectedEvent.Data1,
                Data2 = SelectedEvent.Data2
            };
        }

        private void SaveEvent()
        {
            if (EditingEvent == null)
                return;

            if (_isEditMode)
            {
                SelectedEvent.CEID = EditingEvent.CEID;
                SelectedEvent.EventName = EditingEvent.EventName;
                SelectedEvent.Description = EditingEvent.Description;
                SelectedEvent.SourceType = EditingEvent.SourceType;
                SelectedEvent.SourceAddress = EditingEvent.SourceAddress;
                SelectedEvent.TriggerCondition = EditingEvent.TriggerCondition;
                SelectedEvent.ReportType = EditingEvent.ReportType;
                SelectedEvent.Enabled = EditingEvent.Enabled;

                SelectedEvent.EventPriority = EditingEvent.EventPriority;
                SelectedEvent.EventCategory = EditingEvent.EventCategory;
                SelectedEvent.AlarmRelated = EditingEvent.AlarmRelated;
                SelectedEvent.MinimumInterval = EditingEvent.MinimumInterval;
                SelectedEvent.Data1 = EditingEvent.Data1;
                SelectedEvent.Data2 = EditingEvent.Data2;
            }
            else
            {
                EventModel evt =
                    new EventModel
                    {
                        CEID = EditingEvent.CEID,
                        EventName = EditingEvent.EventName,
                        Description = EditingEvent.Description,
                        SourceType = EditingEvent.SourceType,
                        SourceAddress = EditingEvent.SourceAddress,
                        TriggerCondition = EditingEvent.TriggerCondition,
                        ReportType = EditingEvent.ReportType,
                        Enabled = EditingEvent.Enabled,

                        EventPriority = EditingEvent.EventPriority,
                        EventCategory = EditingEvent.EventCategory,
                        AlarmRelated = EditingEvent.AlarmRelated,
                        MinimumInterval = EditingEvent.MinimumInterval,
                        Data1 = EditingEvent.Data1,
                        Data2 = EditingEvent.Data2
                    };

                _manager.Events.Add(evt);

                SelectedEvent = evt;
            }

            EditingEvent = null;
            _isEditMode = false;
        }

        private void DeleteEvent()
        {
            if (SelectedEvent == null)
                return;

            _manager.Events.Remove(
                SelectedEvent);

            SelectedEvent = null;
            EditingEvent = null;
        }

        private void CancelEvent()
        {
            EditingEvent = null;
            _isEditMode = false;
        }

        private void LoadSampleHistory()
        {
            LastOccurredTime = "--";
            CurrentValue = "--";
            EventStatus = "--";
            Active = "--";

            EventHistory.Clear();
        }

        public override void Initialize()
        {
        }

        public object GetExportData()
        {
            return _manager.Events;
        }
    }
}
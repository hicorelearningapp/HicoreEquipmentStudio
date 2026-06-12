using HicoreEquipmentStudio.Commands;
using HicoreEquipmentStudio.Interfaces;
using HicoreEquipmentStudio.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HicoreEquipmentStudio.ViewModel.Events
{
    public class EventViewModel : BaseViewModel, IJsonSectionProvider
    {
        private EventModel _selectedEvent;
        private EventModel _editingEvent;

        private string _searchText;
        private string _lastOccurredTime;
        private string _currentValue;
        private string _eventStatus;
        private string _active;

        private bool _isEditMode;

        public ObservableCollection<EventModel> Events { get; }
        public ObservableCollection<EventHistoryModel> EventHistory { get; }

        public ICommand AddEventCommand { get; }
        public ICommand EditEventCommand { get; }
        public ICommand DeleteEventCommand { get; }
        public ICommand SaveEventCommand { get; }
        public ICommand CancelEventCommand { get; }

        public EventModel SelectedEvent
        {
            get => _selectedEvent;
            set
            {
                _selectedEvent = value;
                OnPropertyChanged();
            }
        }

        public EventModel EditingEvent
        {
            get => _editingEvent;
            set
            {
                _editingEvent = value;
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

        public string LastOccurredTime
        {
            get => _lastOccurredTime;
            set
            {
                _lastOccurredTime = value;
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

        public string EventStatus
        {
            get => _eventStatus;
            set
            {
                _eventStatus = value;
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

        public string SectionName => "events";

        public EventViewModel()
        {
            Events = new ObservableCollection<EventModel>();
            EventHistory = new ObservableCollection<EventHistoryModel>();

            AddEventCommand = new RelayCommand(AddEvent);
            EditEventCommand = new RelayCommand(EditEvent);
            DeleteEventCommand = new RelayCommand(DeleteEvent);
            SaveEventCommand = new RelayCommand(SaveEvent);
            CancelEventCommand = new RelayCommand(CancelEvent);

            LoadSampleHistory();
        }

        #region CRUD Operations

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
                Events.Add(EditingEvent);
                SelectedEvent = EditingEvent;
            }

            EditingEvent = null;
            _isEditMode = false;

            OnPropertyChanged(nameof(Events));
        }

        private void DeleteEvent()
        {
            if (SelectedEvent == null)
                return;

            Events.Remove(SelectedEvent);

            SelectedEvent = null;
            EditingEvent = null;
        }

        private void CancelEvent()
        {
            EditingEvent = null;
            _isEditMode = false;
        }

        #endregion

        private void LoadSampleHistory()
        {
            LastOccurredTime = "";
            CurrentValue = "";
            EventStatus = "";
            Active = "";

            EventHistory.Clear();
        }

        public override void Initialize()
        {
        }

        public object GetExportData()
        {
            return Events;
        }
    }
}
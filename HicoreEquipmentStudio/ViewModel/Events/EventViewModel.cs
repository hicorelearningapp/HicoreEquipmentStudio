using HicoreEquipmentStudio.Models;
using System.Collections.ObjectModel;

namespace HicoreEquipmentStudio.ViewModel.Events
{
    public class EventViewModel : BaseViewModel
    {
        private EventModel _selectedEvent;
        private string _searchText;
        private string _lastOccurredTime;
        private string _currentValue;
        private string _eventStatus;
        private string _active;

        public ObservableCollection<EventModel> Events { get; }

        public ObservableCollection<EventHistoryModel> EventHistory { get; }

        public EventModel SelectedEvent
        {
            get => _selectedEvent;
            set
            {
                _selectedEvent = value;
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

        public EventViewModel()
        {
            Events = new ObservableCollection<EventModel>();
            EventHistory = new ObservableCollection<EventHistoryModel>();

            LoadSampleEvents();
            LoadSampleHistory();
        }

        private void LoadSampleEvents()
        {
            Events.Add(new EventModel
            {
                CEID = 3001,
                EventName = "Process Started",
                SourceType = "Register",
                SourceAddress = "40030",
                TriggerCondition = "= 1",
                ReportType = "Instant",
                Enabled = true,
                Description = "Process cycle has started",

                EventPriority = "Normal",
                EventCategory = "Process",
                AlarmRelated = "None",
                MinimumInterval = 1000
            });

            Events.Add(new EventModel
            {
                CEID = 3002,
                EventName = "Process Completed",
                SourceType = "Register",
                SourceAddress = "40031",
                TriggerCondition = "= 1",
                ReportType = "Instant",
                Enabled = true,
                Description = "Process cycle completed",

                EventPriority = "Normal",
                EventCategory = "Process",
                AlarmRelated = "None",
                MinimumInterval = 1000
            });

            Events.Add(new EventModel
            {
                CEID = 3003,
                EventName = "Process Aborted",
                SourceType = "Register",
                SourceAddress = "40032",
                TriggerCondition = "= 1",
                ReportType = "Instant",
                Enabled = true,
                Description = "Process aborted by equipment",

                EventPriority = "High",
                EventCategory = "Process",
                AlarmRelated = "None",
                MinimumInterval = 1000
            });

            Events.Add(new EventModel
            {
                CEID = 3004,
                EventName = "Recipe Loaded",
                SourceType = "Register",
                SourceAddress = "40033",
                TriggerCondition = "= 1",
                ReportType = "Instant",
                Enabled = true,
                Description = "New recipe loaded",

                EventPriority = "Normal",
                EventCategory = "Recipe",
                AlarmRelated = "None",
                MinimumInterval = 1000
            });

            SelectedEvent = Events[0];
        }

        private void LoadSampleHistory()
        {
            LastOccurredTime = "20-May-2025 10:22:18 AM";
            CurrentValue = "0";
            EventStatus = "Not Triggered";
            Active = "No";

            EventHistory.Add(new EventHistoryModel
            {
                Time = "20-May-2025 09:41:12",
                Status = "Triggered",
                Data1 = "-",
                Data2 = "-"
            });

            EventHistory.Add(new EventHistoryModel
            {
                Time = "20-May-2025 09:40:05",
                Status = "Triggered",
                Data1 = "-",
                Data2 = "-"
            });

            EventHistory.Add(new EventHistoryModel
            {
                Time = "20-May-2025 09:38:10",
                Status = "Triggered",
                Data1 = "-",
                Data2 = "-"
            });

            EventHistory.Add(new EventHistoryModel
            {
                Time = "20-May-2025 09:36:58",
                Status = "Triggered",
                Data1 = "-",
                Data2 = "-"
            });

            EventHistory.Add(new EventHistoryModel
            {
                Time = "20-May-2025 09:35:42",
                Status = "Triggered",
                Data1 = "-",
                Data2 = "-"
            });
        }

        public override void Initialize()
        {
        }
    }
}
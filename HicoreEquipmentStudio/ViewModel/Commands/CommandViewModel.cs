using HicoreEquipmentStudio.Models;
using System.Collections.ObjectModel;

namespace HicoreEquipmentStudio.ViewModel.Commands
{
    public class CommandViewModel : BaseViewModel
    {
        private CommandModel _selectedCommand;

        public ObservableCollection<CommandModel> Commands { get; set; }

        public ObservableCollection<CommandHistoryModel> TestHistory { get; set; }

        public CommandModel SelectedCommand
        {
            get => _selectedCommand;
            set
            {
                _selectedCommand = value;
                OnPropertyChanged();
            }
        }

        private string _lastExecutedTime;
        public string LastExecutedTime
        {
            get => _lastExecutedTime;
            set
            {
                _lastExecutedTime = value;
                OnPropertyChanged();
            }
        }

        private string _executionStatus;
        public string ExecutionStatus
        {
            get => _executionStatus;
            set
            {
                _executionStatus = value;
                OnPropertyChanged();
            }
        }

        private string _lastWriteValue;
        public string LastWriteValue
        {
            get => _lastWriteValue;
            set
            {
                _lastWriteValue = value;
                OnPropertyChanged();
            }
        }

        private string _readbackValue;
        public string ReadbackValue
        {
            get => _readbackValue;
            set
            {
                _readbackValue = value;
                OnPropertyChanged();
            }
        }

        private string _result;
        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        public CommandViewModel()
        {
            Commands = new ObservableCollection<CommandModel>();
            TestHistory = new ObservableCollection<CommandHistoryModel>();

            LoadSampleData();
        }

        private void LoadSampleData()
        {
            Commands.Add(new CommandModel
            {
                CommandName = "Start",
                CommandCode = "CMD_START",
                Address = "00001",
                DataType = "Bool",
                WriteValue = "1 (ON)",
                ReadbackAddress = "10001",
                ReadbackValue = "1 (ON)",
                Category = "Control",
                Enabled = true,
                Description = "Start the equipment"
            });

            Commands.Add(new CommandModel
            {
                CommandName = "Stop",
                CommandCode = "CMD_STOP",
                Address = "00002",
                DataType = "Bool",
                WriteValue = "1 (ON)",
                ReadbackAddress = "10002",
                ReadbackValue = "1 (ON)",
                Category = "Control",
                Enabled = true,
                Description = "Stop the equipment"
            });

            Commands.Add(new CommandModel
            {
                CommandName = "Reset",
                CommandCode = "CMD_RESET",
                Address = "00003",
                DataType = "Bool",
                WriteValue = "1 (ON)",
                ReadbackAddress = "10003",
                ReadbackValue = "1 (ON)",
                Category = "Control",
                Enabled = true,
                Description = "Reset alarms"
            });

            SelectedCommand = Commands[0];

            LastExecutedTime = "20-May-2025 10:22:18 AM";
            ExecutionStatus = "Success";
            LastWriteValue = "1 (ON)";
            ReadbackValue = "1 (ON)";
            Result = "Command Executed Successfully";

            TestHistory.Add(new CommandHistoryModel
            {
                Time = "20-May-2025 10:22:18",
                WriteValue = "1 (ON)",
                ReadbackValue = "1 (ON)",
                Result = "Success"
            });

            TestHistory.Add(new CommandHistoryModel
            {
                Time = "20-May-2025 10:20:05",
                WriteValue = "1 (ON)",
                ReadbackValue = "1 (ON)",
                Result = "Success"
            });

            TestHistory.Add(new CommandHistoryModel
            {
                Time = "20-May-2025 10:18:42",
                WriteValue = "1 (ON)",
                ReadbackValue = "1 (ON)",
                Result = "Success"
            });
        }

        public override void Initialize()
        {
        }
    }
}
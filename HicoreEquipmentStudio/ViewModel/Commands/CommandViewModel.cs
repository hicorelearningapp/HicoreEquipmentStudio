using HicoreEquipmentStudio.Commands;
using HicoreEquipmentStudio.Core;
using HicoreEquipmentStudio.Interfaces;
using HicoreEquipmentStudio.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HicoreEquipmentStudio.ViewModel.Commands
{
    public class CommandViewModel :
        BaseViewModel,
        IJsonSectionProvider
    {
        private readonly EquipmentManager _manager;

        private CommandModel _selectedCommand;
        private CommandModel _editingCommand;
        private bool _isEditMode;

        private string _searchText;
        private string _lastExecutedTime;
        private string _executionStatus;
        private string _lastWriteValue;
        private string _readbackValue;
        private string _result;

        public ObservableCollection<CommandModel> Commands
        {
            get { return _manager.Commands; }
        }

        public ObservableCollection<CommandHistoryModel> TestHistory
        {
            get;
            private set;
        }

        #region Commands

        public ICommand AddCommandCommand { get; private set; }

        public ICommand EditCommandCommand { get; private set; }

        public ICommand DeleteCommandCommand { get; private set; }

        public ICommand SaveCommandCommand { get; private set; }

        public ICommand CancelCommandCommand { get; private set; }

        #endregion

        #region Properties

        public CommandModel SelectedCommand
        {
            get { return _selectedCommand; }
            set
            {
                _selectedCommand = value;
                OnPropertyChanged();
            }
        }

        public CommandModel EditingCommand
        {
            get { return _editingCommand; }
            set
            {
                _editingCommand = value;
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

        public string LastExecutedTime
        {
            get { return _lastExecutedTime; }
            set
            {
                _lastExecutedTime = value;
                OnPropertyChanged();
            }
        }

        public string ExecutionStatus
        {
            get { return _executionStatus; }
            set
            {
                _executionStatus = value;
                OnPropertyChanged();
            }
        }

        public string LastWriteValue
        {
            get { return _lastWriteValue; }
            set
            {
                _lastWriteValue = value;
                OnPropertyChanged();
            }
        }

        public string ReadbackValue
        {
            get { return _readbackValue; }
            set
            {
                _readbackValue = value;
                OnPropertyChanged();
            }
        }

        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        public string SectionName
        {
            get { return "commands"; }
        }

        #endregion

        public CommandViewModel(
            EquipmentManager manager)
        {
            _manager = manager;

            TestHistory =
                new ObservableCollection<CommandHistoryModel>();

            AddCommandCommand =
                new RelayCommand(AddCommand);

            EditCommandCommand =
                new RelayCommand(EditCommand);

            DeleteCommandCommand =
                new RelayCommand(DeleteCommand);

            SaveCommandCommand =
                new RelayCommand(SaveCommand);

            CancelCommandCommand =
                new RelayCommand(CancelCommand);

            LoadSampleData();
        }

        private void AddCommand()
        {
            _isEditMode = false;

            EditingCommand = new CommandModel
            {
                Enabled = true
            };
        }

        private void EditCommand()
        {
            if (SelectedCommand == null)
                return;

            _isEditMode = true;

            EditingCommand = new CommandModel
            {
                CommandName = SelectedCommand.CommandName,
                CommandCode = SelectedCommand.CommandCode,
                Address = SelectedCommand.Address,
                DataType = SelectedCommand.DataType,
                WriteValue = SelectedCommand.WriteValue,
                ReadbackAddress = SelectedCommand.ReadbackAddress,
                ReadbackValue = SelectedCommand.ReadbackValue,
                Category = SelectedCommand.Category,
                Enabled = SelectedCommand.Enabled,
                Description = SelectedCommand.Description
            };
        }

        private void SaveCommand()
        {
            if (EditingCommand == null)
                return;

            if (_isEditMode)
            {
                SelectedCommand.CommandName =
                    EditingCommand.CommandName;

                SelectedCommand.CommandCode =
                    EditingCommand.CommandCode;

                SelectedCommand.Address =
                    EditingCommand.Address;

                SelectedCommand.DataType =
                    EditingCommand.DataType;

                SelectedCommand.WriteValue =
                    EditingCommand.WriteValue;

                SelectedCommand.ReadbackAddress =
                    EditingCommand.ReadbackAddress;

                SelectedCommand.ReadbackValue =
                    EditingCommand.ReadbackValue;

                SelectedCommand.Category =
                    EditingCommand.Category;

                SelectedCommand.Enabled =
                    EditingCommand.Enabled;

                SelectedCommand.Description =
                    EditingCommand.Description;
            }
            else
            {
                CommandModel command =
                    new CommandModel
                    {
                        CommandName = EditingCommand.CommandName,
                        CommandCode = EditingCommand.CommandCode,
                        Address = EditingCommand.Address,
                        DataType = EditingCommand.DataType,
                        WriteValue = EditingCommand.WriteValue,
                        ReadbackAddress = EditingCommand.ReadbackAddress,
                        ReadbackValue = EditingCommand.ReadbackValue,
                        Category = EditingCommand.Category,
                        Enabled = EditingCommand.Enabled,
                        Description = EditingCommand.Description
                    };

                _manager.Commands.Add(command);

                SelectedCommand = command;
            }

            EditingCommand = null;
            _isEditMode = false;
        }

        private void DeleteCommand()
        {
            if (SelectedCommand == null)
                return;

            _manager.Commands.Remove(
                SelectedCommand);

            SelectedCommand = null;
            EditingCommand = null;
        }

        private void CancelCommand()
        {
            EditingCommand = null;
            _isEditMode = false;
        }

        private void LoadSampleData()
        {
            LastExecutedTime = "--";
            ExecutionStatus = "--";
            LastWriteValue = "--";
            ReadbackValue = "--";
            Result = "--";

            TestHistory.Clear();
        }

        public override void Initialize()
        {
        }

        public object GetExportData()
        {
            return _manager.Commands;
        }
    }
}
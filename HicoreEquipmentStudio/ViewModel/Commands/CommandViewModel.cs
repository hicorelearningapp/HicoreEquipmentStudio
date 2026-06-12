using HicoreEquipmentStudio.Commands;
using HicoreEquipmentStudio.Interfaces;
using HicoreEquipmentStudio.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HicoreEquipmentStudio.ViewModel.Commands
{
    public class CommandViewModel : BaseViewModel, IJsonSectionProvider
    {
        private CommandModel _selectedCommand;
        private CommandModel _editingCommand;
        private bool _isEditMode;

        public ObservableCollection<CommandModel> Commands { get; }
        public ObservableCollection<CommandHistoryModel> TestHistory { get; }

        #region Commands

        public ICommand AddCommandCommand { get; }
        public ICommand EditCommandCommand { get; }
        public ICommand DeleteCommandCommand { get; }
        public ICommand SaveCommandCommand { get; }
        public ICommand CancelCommandCommand { get; }

        #endregion

        #region Properties

        public CommandModel SelectedCommand
        {
            get => _selectedCommand;
            set
            {
                _selectedCommand = value;
                OnPropertyChanged();
            }
        }

        public CommandModel EditingCommand
        {
            get => _editingCommand;
            set
            {
                _editingCommand = value;
                OnPropertyChanged();
            }
        }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
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

        public string SectionName => "commands";

        #endregion

        public CommandViewModel()
        {
            Commands = new ObservableCollection<CommandModel>();
            TestHistory = new ObservableCollection<CommandHistoryModel>();

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

        #region CRUD

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
                Commands.Add(EditingCommand);
                SelectedCommand = EditingCommand;
            }

            EditingCommand = null;
            _isEditMode = false;

            OnPropertyChanged(nameof(Commands));
        }

        private void DeleteCommand()
        {
            if (SelectedCommand == null)
                return;

            Commands.Remove(SelectedCommand);

            SelectedCommand = null;
            EditingCommand = null;
        }

        private void CancelCommand()
        {
            EditingCommand = null;
            _isEditMode = false;
        }

        #endregion

        private void LoadSampleData()
        {
            LastExecutedTime = "";
            ExecutionStatus = "";
            LastWriteValue = "";
            ReadbackValue = "";
            Result = "";

            TestHistory.Clear();
        }

        public override void Initialize()
        {
        }

        public object GetExportData()
        {
            return Commands;
        }
    }
}
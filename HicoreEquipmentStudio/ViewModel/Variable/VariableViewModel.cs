using HicoreEquipmentStudio.Commands;
using HicoreEquipmentStudio.Core;
using HicoreEquipmentStudio.Interfaces;
using HicoreEquipmentStudio.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HicoreEquipmentStudio.ViewModel.Variable
{
    public class VariableViewModel :
        BaseViewModel,
        IJsonSectionProvider
    {
        private readonly EquipmentManager _manager;

        private VariableModel _selectedVariable;
        private VariableModel _editingVariable;

        private bool _isEditMode;

        private string _searchText;
        private string _lastReadTime;
        private string _currentValue;
        private string _status;

        public ICommand AddVariableCommand { get; private set; }

        public ICommand EditVariableCommand { get; private set; }

        public ICommand DeleteVariableCommand { get; private set; }

        public ICommand SaveVariableCommand { get; private set; }

        public ICommand CancelCommand { get; private set; }

        public ObservableCollection<VariableModel> Variables
        {
            get
            {
                return _manager.Variables;
            }
        }

        public ObservableCollection<ReadHistoryModel> ReadHistory
        {
            get;
            private set;
        }

        public VariableModel SelectedVariable
        {
            get { return _selectedVariable; }
            set
            {
                _selectedVariable = value;
                OnPropertyChanged();
            }
        }

        public VariableModel EditingVariable
        {
            get { return _editingVariable; }
            set
            {
                _editingVariable = value;
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

        public string LastReadTime
        {
            get { return _lastReadTime; }
            set
            {
                _lastReadTime = value;
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

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        public string SectionName
        {
            get { return "variables"; }
        }

        public VariableViewModel(
            EquipmentManager manager)
        {
            _manager = manager;

            ReadHistory =
                new ObservableCollection<ReadHistoryModel>();

            AddVariableCommand =
                new RelayCommand(AddVariable);

            EditVariableCommand =
                new RelayCommand(EditVariable);

            DeleteVariableCommand =
                new RelayCommand(DeleteVariable);

            SaveVariableCommand =
                new RelayCommand(SaveVariable);

            CancelCommand =
                new RelayCommand(Cancel);

            LoadSampleHistory();
        }

        private void AddVariable()
        {
            _isEditMode = false;

            EditingVariable = new VariableModel();
        }

        private void EditVariable()
        {
            if (SelectedVariable == null)
                return;

            _isEditMode = true;

            EditingVariable = new VariableModel
            {
                Name = SelectedVariable.Name,
                Address = SelectedVariable.Address,
                DataType = SelectedVariable.DataType,
                Category = SelectedVariable.Category,
                Access = SelectedVariable.Access,
                PollInterval = SelectedVariable.PollInterval,
                SVID = SelectedVariable.SVID,
                Units = SelectedVariable.Units,
                Description = SelectedVariable.Description
            };
        }

        private void SaveVariable()
        {
            if (EditingVariable == null)
                return;

            if (_isEditMode)
            {
                SelectedVariable.Name =
                    EditingVariable.Name;

                SelectedVariable.Address =
                    EditingVariable.Address;

                SelectedVariable.DataType =
                    EditingVariable.DataType;

                SelectedVariable.Category =
                    EditingVariable.Category;

                SelectedVariable.Access =
                    EditingVariable.Access;

                SelectedVariable.PollInterval =
                    EditingVariable.PollInterval;

                SelectedVariable.SVID =
                    EditingVariable.SVID;

                SelectedVariable.Units =
                    EditingVariable.Units;

                SelectedVariable.Description =
                    EditingVariable.Description;
            }
            else
            {
                VariableModel variable =
                    new VariableModel
                    {
                        Name = EditingVariable.Name,
                        Address = EditingVariable.Address,
                        DataType = EditingVariable.DataType,
                        Category = EditingVariable.Category,
                        Access = EditingVariable.Access,
                        PollInterval = EditingVariable.PollInterval,
                        SVID = EditingVariable.SVID,
                        Units = EditingVariable.Units,
                        Description = EditingVariable.Description
                    };

                _manager.Variables.Add(variable);

                SelectedVariable = variable;
            }

            EditingVariable = null;
            _isEditMode = false;
        }

        private void DeleteVariable()
        {
            if (SelectedVariable == null)
                return;

            _manager.Variables.Remove(
                SelectedVariable);

            SelectedVariable = null;
        }

        private void Cancel()
        {
            EditingVariable = null;
            _isEditMode = false;
        }

        private void LoadSampleHistory()
        {
            LastReadTime = "--";
            CurrentValue = "--";
            Status = "--";
        }

        public override void Initialize()
        {
        }

        public object GetExportData()
        {
            return _manager.Variables;
        }
    }
}
using HicoreEquipmentStudio.Commands;
using System;
using System.Windows.Input;

namespace HicoreEquipmentStudio.ViewModel
{
    public class ConfigurationItemViewModel : BaseViewModel
    {
        private bool _isSelected;

        private readonly Action<string> _navigate;

        public string Title { get; }

        public string Key { get; }

        public ICommand NavigateCommand { get; }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }

        public ConfigurationItemViewModel(
            string title,
            string key,
            Action<string> navigate)
        {
            Title = title;
            Key = key;
            _navigate = navigate;

            NavigateCommand =
                new RelayCommand(() =>
                {
                    _navigate(Key);
                });
        }
    }
}
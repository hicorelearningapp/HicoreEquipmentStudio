using HicoreEquipmentStudio.ViewModel;

namespace HicoreEquipmentStudio.Models
{
    public class EquipmentInfoModel : BaseViewModel
    {
        private string _equipmentId;
        public string EquipmentId
        {
            get => _equipmentId;
            set
            {
                _equipmentId = value;
                OnPropertyChanged();
            }
        }

        private string _equipmentName;
        public string EquipmentName
        {
            get => _equipmentName;
            set
            {
                _equipmentName = value;
                OnPropertyChanged();
            }
        }

        private string _model;
        public string Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged();
            }
        }

        private string _vendor;
        public string Vendor
        {
            get => _vendor;
            set
            {
                _vendor = value;
                OnPropertyChanged();
            }
        }

        private string _protocol;
        public string Protocol
        {
            get => _protocol;
            set
            {
                _protocol = value;
                OnPropertyChanged();
            }
        }

        private string _ipAddress;
        public string IPAddress
        {
            get => _ipAddress;
            set
            {
                _ipAddress = value;
                OnPropertyChanged();
            }
        }

        private int _port;
        public int Port
        {
            get => _port;
            set
            {
                _port = value;
                OnPropertyChanged();
            }
        }

        private int _timeout;
        public int Timeout
        {
            get => _timeout;
            set
            {
                _timeout = value;
                OnPropertyChanged();
            }
        }

        private int _reconnectInterval;
        public int ReconnectInterval
        {
            get => _reconnectInterval;
            set
            {
                _reconnectInterval = value;
                OnPropertyChanged();
            }
        }

        private bool _isConnected;
        public bool IsConnected
        {
            get => _isConnected;
            set
            {
                _isConnected = value;
                OnPropertyChanged();
            }
        }
    }
}
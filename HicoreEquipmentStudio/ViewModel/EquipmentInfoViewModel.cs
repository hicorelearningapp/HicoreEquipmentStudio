using HicoreEquipmentStudio.Interfaces;
using HicoreEquipmentStudio.Models;

namespace HicoreEquipmentStudio.ViewModel
{
    public class EquipmentInfoViewModel :
        BaseViewModel,
        IJsonSectionProvider
    {
        private EquipmentInfoModel _equipmentInfo;

        public EquipmentInfoModel EquipmentInfo
        {
            get => _equipmentInfo;
            set
            {
                _equipmentInfo = value;
                OnPropertyChanged();
            }
        }

        public EquipmentInfoViewModel()
        {
            EquipmentInfo = new EquipmentInfoModel
            {
                EquipmentId = "FC001",
                EquipmentName = "Flux Cleaner",
                Model = "WEFG-3005A",
                Vendor = "World Engineering",
                Protocol = "Modbus TCP",
                IPAddress = "192.168.1.100",
                Port = 502,
                Timeout = 3000,
                ReconnectInterval = 5,
                IsConnected = true
            };
        }

        public string SectionName => "equipmentInfo";

        public object GetExportData()
        {
            return EquipmentInfo;
        }

        public override void Initialize()
        {
        }
    }
}
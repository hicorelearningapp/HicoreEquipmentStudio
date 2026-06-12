using HicoreEquipmentStudio.Core;
using HicoreEquipmentStudio.Interfaces;
using HicoreEquipmentStudio.Models;

namespace HicoreEquipmentStudio.ViewModel
{
    public class EquipmentInfoViewModel :
        BaseViewModel,
        IJsonSectionProvider
    {
        private readonly EquipmentManager _manager;

        public EquipmentInfoModel EquipmentInfo
        {
            get
            {
                return _manager.EquipmentInfo;
            }
        }

        public string SectionName
        {
            get
            {
                return "equipmentInfo";
            }
        }

        public EquipmentInfoViewModel(
            EquipmentManager manager)
        {
            _manager = manager;

            if (string.IsNullOrEmpty(_manager.EquipmentInfo.EquipmentId))
            {
                _manager.EquipmentInfo.EquipmentId = "FC001";
                _manager.EquipmentInfo.EquipmentName = "Flux Cleaner";
                _manager.EquipmentInfo.Model = "WEFG-3005A";
                _manager.EquipmentInfo.Vendor = "World Engineering";
                _manager.EquipmentInfo.Protocol = "Modbus TCP";
                _manager.EquipmentInfo.IPAddress = "192.168.1.100";
                _manager.EquipmentInfo.Port = 502;
                _manager.EquipmentInfo.Timeout = 3000;
                _manager.EquipmentInfo.ReconnectInterval = 5;
                _manager.EquipmentInfo.IsConnected = true;
            }
        }

        public object GetExportData()
        {
            return _manager.EquipmentInfo;
        }

        public override void Initialize()
        {
        }
    }
}
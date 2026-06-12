namespace HiCore.EquipmentFramework.Config.Interfaces
{
    public interface IJsonSectionProvider
    {
        string SectionName { get; }

        object GetExportData();
    }
}
namespace HicoreEquipmentStudio.Interfaces
{
    public interface IJsonSectionProvider
    {
        string SectionName { get; }

        object GetExportData();
    }
}
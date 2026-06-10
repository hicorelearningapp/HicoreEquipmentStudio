namespace HicoreEquipmentStudio.Models
{
    public class VariableModel
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string DataType { get; set; }

        public string Category { get; set; }

        public string Access { get; set; }

        public int PollInterval { get; set; }

        public int SVID { get; set; }

        public string Units { get; set; }

        public string Description { get; set; }
    }
}
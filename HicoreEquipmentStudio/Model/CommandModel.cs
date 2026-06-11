namespace HicoreEquipmentStudio.Models
{
    public class CommandModel
    {
        public string CommandName { get; set; }

        public string CommandCode { get; set; }

        public string Address { get; set; }

        public string DataType { get; set; }

        public string WriteValue { get; set; }

        public string ReadbackAddress { get; set; }

        public string ReadbackValue { get; set; }

        public string Category { get; set; }

        public bool Enabled { get; set; }

        public string Description { get; set; }
    }
}
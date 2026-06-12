using HicoreEquipmentStudio.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HicoreEquipmentStudio.Core
{
    public static class JsonExportService
    {
        public static void Export(
            IEnumerable<IJsonSectionProvider> providers,
            string filePath)
        {
            Dictionary<string, object> data =
                new Dictionary<string, object>();

            foreach (var provider in providers)
            {
                data[provider.SectionName] =
                    provider.GetExportData();
            }

            string json =
                JsonSerializer.Serialize(
                    data,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });

            File.WriteAllText(filePath, json);
        }
    }
}

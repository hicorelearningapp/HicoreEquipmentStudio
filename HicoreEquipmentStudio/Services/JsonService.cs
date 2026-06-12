using HicoreEquipmentStudio.Model;
using HicoreEquipmentStudio.Models;
using Newtonsoft.Json;
using System;
using System.IO;

namespace HicoreEquipmentStudio.Services
{
    public class JsonService
    {
        public bool Save(
            string filePath,
            EquipmentConfiguration configuration,
            out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                string directory =
                    Path.GetDirectoryName(filePath);

                if (!string.IsNullOrEmpty(directory) &&
                    !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                string json =
                    JsonConvert.SerializeObject(
                        configuration,
                        Formatting.Indented);

                File.WriteAllText(filePath, json);

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public EquipmentConfiguration Load(
            string filePath,
            out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                if (!File.Exists(filePath))
                {
                    return new EquipmentConfiguration();
                }

                string json = File.ReadAllText(filePath);

                EquipmentConfiguration configuration =
                    JsonConvert.DeserializeObject<EquipmentConfiguration>(json);

                return configuration ?? new EquipmentConfiguration();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return new EquipmentConfiguration();
            }
        }
    }
}
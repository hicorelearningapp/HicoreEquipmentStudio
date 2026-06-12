using Newtonsoft.Json;
using System;
using System.IO;

namespace HicoreEquipmentStudio.Core
{
    public class JsonService
    {
        public bool Save<T>(
            string filePath,
            T data,
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
                        data,
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

        public T Load<T>(
    string filePath,
    out string errorMessage)
    where T : new()
        {
            errorMessage = string.Empty;

            try
            {
                if (!File.Exists(filePath))
                {
                    return new T();
                }

                string json =
                    File.ReadAllText(filePath);

                T result =
                    JsonConvert.DeserializeObject<T>(json);

                if (result == null)
                {
                    return new T();
                }

                return result;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;

                return new T();
            }
        }
    }
}
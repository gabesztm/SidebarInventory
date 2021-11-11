using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SidebarInventory
{
    public class ViewModel
    {
        private string _jsonFilePath;
        private List<SpecialCharacter> _specialCharacters = new List<SpecialCharacter>();
        public List<SpecialCharacter> SpecialCharacters
        {
            get { return _specialCharacters; }
            private set { _specialCharacters = value; }
        }

        public ViewModel()
        {
            _jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "SpecialCharacters.json");
            try
            {
                SpecialCharacters = LoadFromJson();
            }
            catch
            {
                _specialCharacters = new List<SpecialCharacter>()
                {
                        new SpecialCharacter(){SpecChar = "μ"},
                        new SpecialCharacter(){SpecChar = "Å"},

                };
                SaveToJson();
            }
        }

        private void SaveToJson()
        {
            string json = JsonConvert.SerializeObject(SpecialCharacters, Formatting.Indented);
            using (StreamWriter sw = new StreamWriter(_jsonFilePath))
            {
                sw.WriteLine(json);
            }
        }

        private List<SpecialCharacter> LoadFromJson()
        {
            string json;
            using (StreamReader sr = new StreamReader(_jsonFilePath))
            {
                json = sr.ReadToEnd();
            }
            List<SpecialCharacter> loadedData = JsonConvert.DeserializeObject<List<SpecialCharacter>>(json);
            return loadedData;
        }

    }
}

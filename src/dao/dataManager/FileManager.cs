using System;
using System.Collections.Generic;
using System.IO;
using HangmanCSharp.model;

namespace HangmanCSharp.dao.dataManager
{
    public class FileManager : IDataManager
    {
        private readonly string _filePath;

        public FileManager(string filePath)
        {
            _filePath = filePath;
        }

        public List<Country> GetCountries()
        {
            List<Country> countries = new List<Country>();
            using (StreamReader streamReader = new StreamReader(_filePath))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] columns = line.Split(" | ");
                    string countryName = columns[0];
                    string capitalName = columns[1];
                    Country country = new Country(capitalName, countryName);
                    countries.Add(country);
                }
            }

            return countries;
        }

        public void SaveToFile(string pathToFile, string dataToSave)
        {
            using (StreamWriter streamWriter = new StreamWriter(pathToFile, true))
            {
                streamWriter.WriteLine(dataToSave);
            }
        }

        public List<string> ReadFile()
        {
            List<string> fileData = new List<string>();
            using (StreamReader streamReader = new StreamReader(_filePath))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    fileData.Add(line);
                }
            }
            return fileData;
        }
    }
}
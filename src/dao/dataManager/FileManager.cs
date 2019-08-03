using System;
using System.Collections.Generic;
using System.IO;
using HangmanCSharp.model;

namespace HangmanCSharp.dao.dataManager
{
    public class FileManager : IDataManager
    {
        private string _filePath;

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
                while((line = streamReader.ReadLine()) != null)
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
    }
}
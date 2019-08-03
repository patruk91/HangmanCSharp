using System;
using System.Collections.Generic;
using System.IO;
using HangmanCSharp.model;

namespace HangmanCSharp.dao.dataManager
{
    public class FileManager : IDataManager
    {
        public List<Country> GetCountries()
        {
            List<Country> countries = new List<Country>();
            List<string> fileData = ReadFile(
                @"F:\C#\PROJECTS\HangmanCSharp\HangmanCSharp\
                resources\countries_and_capitals.txt");

            foreach (string line in fileData)
            {
                string[] columns = line.Split(" | ");
                string countryName = columns[0];
                string capitalName = columns[1];
                Country country = new Country(capitalName, countryName);
                countries.Add(country);
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

        public List<string> ReadFile(string filePath)
        {
            List<string> fileData = new List<string>();
            using (StreamReader streamReader = new StreamReader(filePath))
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FloorMastery.Data.Interfaces;
using FloorMastery.Models;
using FloorMastery.Models.Helpers;
using FloorMastery.Models.Responses;

namespace FloorMastery.Data.Repos
{
    public class TaxesProdRepo : ITaxesRepository
    {
        private Dictionary<string, StateTaxData> _statesDictionary;

        public const string _taxPath = @"C:\Users\Csharpener\Desktop\Repos\conner-soligny-individual-work\C#OOP\FloorMastery\TextFiles\Taxes.txt";

        public TaxesProdRepo()
        {
            _statesDictionary = LoadStateTaxData().ToDictionary(m => m.StatesAbbreviation);
        }

       
        public StateTaxData GetTaxDataForState(string stateTax)
        {
            if (_statesDictionary.ContainsKey(stateTax))
            {
                return _statesDictionary[stateTax];
            }
            else
            {
                return null;
            }
        }

        public StateTaxData TheState(string stateInput)
        {
            if (_statesDictionary.ContainsKey(stateInput))
            {
                return _statesDictionary[stateInput];
            }
            else
            {
                return null;
            }
        }

        public List<StateTaxData> LoadStateTaxData()
        {
            List<StateTaxData> taxList = new List<StateTaxData>();

            using (StreamReader sr = new StreamReader(_taxPath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    StateTaxData stateTax = new StateTaxData();

                    string[] columns = line.Split(',');

                    stateTax.StatesAbbreviation = columns[0];
                    stateTax.StatesName = columns[1];
                    stateTax.TaxRate = decimal.Parse(columns[2]);

                    taxList.Add(stateTax);
                }
            }
            return taxList;
        }
    }
}
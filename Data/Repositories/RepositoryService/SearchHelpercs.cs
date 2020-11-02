using Accord.MachineLearning.Text.Stemmers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.RepositoryService
{
    public static class SearchHelpercs
    {
        private static RussianStemmer RussianStemmers = new RussianStemmer();

        private static EnglishStemmer EnglishStemmer = new EnglishStemmer();

        public static List<string> Helper(string Name)
        {
            var result = Name.Split(' ')
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => RussianStemmers.Stem(x))
            .ToList() ;
            return result; 
        }
    }
}

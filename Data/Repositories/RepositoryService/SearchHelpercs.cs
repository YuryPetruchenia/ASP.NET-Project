using System.Collections.Generic;
using System.Linq;
using Accord.MachineLearning.Text.Stemmers;

namespace Data.Repositories.RepositoryService
{
    public static class SearchHelpercs
    {
        private static RussianStemmer _russianStemmers = new RussianStemmer();

        private static EnglishStemmer _englishStemmer = new EnglishStemmer();

        public static List<string> Helper(string name)
        {
            var result = name.Split(' ')
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => _russianStemmers.Stem(x))
            .ToList();
            return result;
        }
    }
}

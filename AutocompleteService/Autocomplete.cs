using System.Globalization;

namespace AutocompleteService;

public static class Autocomplete
{
    private static readonly HashSet<string> AutocompleteWords = [];
    
    public static void Initialize()
    {
        var sr = new StreamReader("../CityNames.csv");

        while (sr.ReadLine() is {} line)
        {
            AutocompleteWords.Add(line);
        }
    }

    public static HashSet<string> AutocompleteWord(string scrap)
    {
        var possibleAutocompleteWords = new HashSet<string>();
        var ci = new CultureInfo("en-US");
        AutocompleteWords.Where(word => word.StartsWith(scrap, true, ci)).ToList().ForEach(word => possibleAutocompleteWords.Add(word));
        
        return possibleAutocompleteWords;
    }
}
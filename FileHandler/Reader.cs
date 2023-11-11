using System.Text.Json;
using Cookie_Cookbook.Conf;
using Cookie_Cookbook.Enums;
using Cookie_Cookbook.Helpers;
using Cookie_Cookbook.UserInteraction;

namespace Cookie_Cookbook.FileHandler
{
  public class Reader
  {
    public void ReadRecipeFromFile()
    {
      FileConf conf = new();
      string path = conf.GetFilePath();

      if (File.Exists(path))
      {
        StreamReader reader = new(path);
        string content = reader.ReadToEnd();
        string[] listOfRecipes = content.Split(Environment.NewLine);

        if (conf.Format == FileFormat.Json)
        {
          var deserializedData = JsonSerializer.Deserialize<string[]>(content);
          if (deserializedData is not null)
          {
            listOfRecipes = deserializedData;
          }
        }

        List<List<int>> myList = new();
        Parser parser = new();
        Printer printer = new();

        foreach (var recipe in listOfRecipes)
        {
          if (recipe.Trim() != "")
          {
            bool successParsing = parser.TryParseIngredientsIds(
              recipe,
              out List<int> parsedList
            );

            if (successParsing)
            {
              myList.Add(parsedList);
            }
          }
        }

        Console.WriteLine("Existing recipes are:" + Environment.NewLine);

        for (int i = 0; i < myList.Count; i++)
        {
          printer.PrintOrderedRecipe(myList[i], i + 1);
        }

        reader.Close();
      }
    }
  }
}
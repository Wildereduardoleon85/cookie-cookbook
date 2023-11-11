using Cookie_Cookbook.Conf;
using Cookie_Cookbook.Enums;
using Cookie_Cookbook.Helpers;
using Cookie_Cookbook.UserInteraction;

namespace Cookie_Cookbook.File
{
  public class FileHandler
  {
    public void GenerateOrWriteTxt(string fileName, string content)
    {
      FileConf conf = new();
      string path = $"{fileName}.json";

      if (conf.Format == FileFormat.Txt)
      {
        path = $"{fileName}.txt";
      }

      using StreamWriter writer = new(path, true);

      writer.WriteLine(content);
      writer.Close();
    }

    public void ReadRecipeFromFile(string filePath)
    {
      StreamReader reader = new(filePath);
      string content = reader.ReadToEnd();
      string[] listOfRecipes = content.Split(Environment.NewLine);

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
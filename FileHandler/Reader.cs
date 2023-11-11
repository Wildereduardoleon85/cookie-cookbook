using System.Text.Json;
using Cookie_Cookbook.Helpers;

namespace Cookie_Cookbook.FileHandler
{
  public class Reader
  {
    public string Path { get; }

    public Reader(string path)
    {
      Path = path;
    }
    public bool ReadRecipeFromFile(out List<string> recipes)
    {
      bool doesTheFileExists = true;

      if (File.Exists(Path))
      {
        FileHelper helper = new();
        string content = File.ReadAllText(Path);
        List<string> listOfRecipes = content.Split(Environment.NewLine).ToList();

        if (helper.GetFileExtension(Path) == "json")
        {
          var deserializedData = JsonSerializer.Deserialize<List<string>>(content);
          if (deserializedData is not null)
          {
            listOfRecipes = deserializedData;
          }
        }

        recipes = listOfRecipes;
      }
      else
      {
        recipes = new List<string> { "" };
        doesTheFileExists = false;
      }

      return doesTheFileExists;
    }
  }
}


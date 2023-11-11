using Cookie_Cookbook.Conf;
using Cookie_Cookbook.CookRecipe;
using Cookie_Cookbook.FileHandler;
using Cookie_Cookbook.Helpers;

namespace Cookie_Cookbook.UserInteraction
{
  public class Printer
  {
    private readonly string _initialInstruction = "Create a new cookie recipe! Available ingredients are:";
    private readonly string _addIngredientMessage = "Add an ingredient by it's Id or type anything else if finish.";

    public void PrintInstructions()
    {
      Console.WriteLine(_initialInstruction);

      foreach (var item in new Ingredient().List)
      {
        Console.WriteLine($"{item.Id}. {item.Name}");
      }
    }

    public void PrintAddIngredients()
    {
      Console.WriteLine(_addIngredientMessage);
    }

    public void PrintAddedIngredients(string addedIngredients)
    {
      Console.WriteLine("Recipe Added:");
      Console.WriteLine(addedIngredients);
    }

    public void PrintOrderedRecipe(List<int> recipeIds, int orderNumber)
    {
      Recipe recipe = new();

      foreach (var id in recipeIds)
      {
        recipe.Add(id);
      }

      Console.WriteLine($"**** {orderNumber} ****");
      Console.WriteLine(recipe.GetAddedIngredients() + Environment.NewLine);
    }

    public void PrintExistingRecipes()
    {
      List<List<int>> recipesMatrix = new();
      Parser parser = new();
      Reader reader = new(new FileConf().GetFilePath());
      ListTrimmer trimmer = new();
      bool theFileExists = reader.ReadRecipeFromFile(out List<string> recipes);

      if (theFileExists)
      {
        foreach (var recipe in trimmer.Trim(recipes))
        {
          bool successParsing = parser.TryParseIngredientsIds(
            recipe,
            out List<int> parsedList
          );

          if (successParsing)
          {
            recipesMatrix.Add(parsedList);
          }
        }

        Console.WriteLine("Existing recipes are:" + Environment.NewLine);

        for (int i = 0; i < recipesMatrix.Count; i++)
        {
          PrintOrderedRecipe(recipesMatrix[i], i + 1);
        }
      }
    }
  }
}
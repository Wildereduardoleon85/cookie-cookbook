using Cookie_Cookbook.CookRecipe;

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
  }
}
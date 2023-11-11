using Cookie_Cookbook.Conf;
using Cookie_Cookbook.CookRecipe;
using Cookie_Cookbook.FileHandler;

namespace Cookie_Cookbook.UserInteraction
{
  public class Interaction
  {
    public void Start()
    {
      Printer printer = new();
      Recipe recipe = new();
      Ingredient ingredient = new();
      Writer writer = new();

      bool keepAddingIngredients = true;
      List<string> recipeIds = new();

      printer.PrintInstructions();

      while (keepAddingIngredients)
      {
        printer.PrintAddIngredients();
        string? input = Console.ReadLine();

        if (input is not null)
        {
          bool isNumber = int.TryParse(input, out int ingredientId);

          if (isNumber)
          {
            if (ingredient.IsIdInTheList(ingredientId))
            {
              recipe.Add(ingredientId);
              recipeIds.Add(ingredientId.ToString());
            }
          }
          else
          {
            keepAddingIngredients = false;
          }
        }
      }

      printer.PrintAddedIngredients(recipe.GetAddedIngredients());
      writer.WriteOrGenerateFile(string.Join(",", recipeIds), new FileConf().Format);
    }
  }
}



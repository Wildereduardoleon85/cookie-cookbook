using Cookie_Cookbook.CookRecipe;
using Cookie_Cookbook.File;

namespace Cookie_Cookbook.UserInteraction
{
  public class Interaction
  {
    public void Start()
    {
      Message message = new();
      Recipe recipe = new();
      Ingredient ingredient = new();
      FileHandler fileHandler = new();

      bool keepAddingIngredients = true;
      List<string> recipeIds = new();

      message.PrintInstructions();

      while (keepAddingIngredients)
      {
        message.PrintAddIngredients();
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

      message.PrintAddedIngredients(recipe.GetAddedIngredients());
      fileHandler.GenerateOrWriteTxt("recipe.txt", string.Join(",", recipeIds));
    }
  }
}



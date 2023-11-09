using Cookie_Cookbook.CookRecipe;

namespace Cookie_Cookbook.UserInteraction
{
  public class Interaction
  {
    public void Start()
    {
      Message message = new();
      Recipe recipe = new();
      Ingredient ingredient = new();

      bool keepAddingIngredients = true;

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
            }
          }
          else
          {
            keepAddingIngredients = false;
          }
        }
      }

      message.PrintAddedIngredients(recipe.GetAddedIngredients());
    }
  }
}



using System.Text;
using static Cookie_Cookbook.CookRecipe.Ingredient;

namespace Cookie_Cookbook.CookRecipe
{
  public class Recipe
  {
    readonly List<BaseIngredient> _recipeItems = new();
    public void Add(int ingredientId)
    {
      foreach (var item in new Ingredient().List)
      {
        if (ingredientId == item.Id)
        {
          _recipeItems.Add(item);
        }
      }
    }
    public string GetAddedIngredients()
    {
      StringBuilder builder = new();

      for (int i = 0; i < _recipeItems.Count; i++)
      {
        string sentence = $"{_recipeItems[i].Name}. {_recipeItems[i].Instruction}";

        if (i == _recipeItems.Count - 1)
        {
          builder.Append(sentence);
        }
        else
        {
          builder.Append($"{sentence}\n");
        }
      }

      return builder.ToString();
    }
  }
}
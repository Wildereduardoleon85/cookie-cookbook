using Cookie_Cookbook.CookRecipe;
using Cookie_Cookbook.UserInteraction;

Interaction interaction = new();

// interaction.Start();

// Specify the path to the file
string filePath = "recipe.txt";

// Check if the file exists
if (File.Exists(filePath))
{
  // Use StreamReader to read from the file
  using (StreamReader reader = new StreamReader(filePath))
  {

    string content = reader.ReadToEnd();

    string[] listOfRecipes = content.Split(Environment.NewLine);
    Recipe recipe = new();

    for (int i = 0; i < listOfRecipes.Length; i++)
    {
      if (listOfRecipes[i].Trim() == "")
      {
        Console.WriteLine("this line is empty");
      }
      else
      {
        Console.WriteLine("this line is not empty");
      }
    }

    // foreach (var recipeItem in listOfRecipes)
    // {
    // Console.WriteLine(recipeItem);
    // foreach (var ingredient in recipeItem.Split(","))
    // {
    //   recipe.Add(int.Parse(ingredient));
    // }
    // }


    // Console.WriteLine(recipe.GetAddedIngredients());


    // Close the StreamReader when done
    reader.Close();
  }
}
else
{
  Console.WriteLine("File not found: " + filePath);
}

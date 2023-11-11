using Cookie_Cookbook.Conf;
using Cookie_Cookbook.File;
using Cookie_Cookbook.UserInteraction;

string filePath = $"{new FileConf().Name}.txt";

if (File.Exists(filePath))
{
  new FileHandler().ReadRecipeFromFile(filePath);
}

Interaction interaction = new();

interaction.Start();
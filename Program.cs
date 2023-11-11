using Cookie_Cookbook.UserInteraction;
using Cookie_Cookbook.FileHandler;

new Reader().ReadRecipeFromFile();

Interaction interaction = new();

interaction.Start();




// read from json
// string jsonString2 = File.ReadAllText("example.json");

// var deserializedData = JsonSerializer.Deserialize<List<string>>(jsonString2);

// foreach (var item in deserializedData)
// {
//   Console.WriteLine(item);
// }
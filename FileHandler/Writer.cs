using System.Text.Json;
using Cookie_Cookbook.Helpers;

namespace Cookie_Cookbook.FileHandler
{
  public class Writer
  {
    public string Content { get; }
    public string Path { get; }

    public Writer(string content, string path)
    {
      Content = content;
      Path = path;
    }
    public void WriteOrGenerateFile()
    {
      FileHelper helper = new();

      if (helper.GetFileExtension(Path) == "txt")
      {
        WriteToTextFile();
      }
      else
      {
        WriteToJsonFile();
      }
    }

    protected void WriteToTextFile()
    {
      StreamWriter writer = new(Path, true);

      writer.WriteLine(Content);
      writer.Close();
    }

    protected void WriteToJsonFile()
    {
      Parser parser = new();
      List<string> jsonData = parser.ConvertStringIntoList(Content);

      if (File.Exists(Path))
      {
        string jsonContent = File.ReadAllText(Path);
        var deserializedData = JsonSerializer.Deserialize<List<string>>(jsonContent);

        if (deserializedData is not null)
        {
          deserializedData.Add(Content);
          jsonData = deserializedData;
        }
      }

      string jsonString = JsonSerializer.Serialize(
        jsonData,
        new JsonSerializerOptions { WriteIndented = true }
      );

      File.WriteAllText(Path, jsonString);
    }
  }
}
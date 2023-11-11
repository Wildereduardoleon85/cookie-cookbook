using System.Text.Json;
using Cookie_Cookbook.Conf;
using Cookie_Cookbook.Enums;
using Cookie_Cookbook.Helpers;

namespace Cookie_Cookbook.FileHandler
{
  public class Writer
  {
    public void WriteOrGenerateFile(string content, FileFormat fileFormat)
    {
      string path = new FileConf().GetFilePath();
      Parser parser = new();
      string jsonString = JsonSerializer.Serialize(parser.ConvertStringIntoList(content), new JsonSerializerOptions { WriteIndented = true });

      if (fileFormat == FileFormat.Txt)
      {
        StreamWriter writer = new(path, true);

        writer.WriteLine(content);
        writer.Close();
      }
      else
      {
        if (File.Exists(path))
        {
          StreamReader reader = new(path);
          string jsonContent = reader.ReadToEnd();
          reader.Close();
          var deserializedData = JsonSerializer.Deserialize<List<string>>(jsonContent);

          if (deserializedData is not null)
          {
            deserializedData.Add(content);
            string newJsonString = JsonSerializer.Serialize(deserializedData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, newJsonString);
          }
        }
        else
        {
          File.WriteAllText(path, jsonString);
        }
      }
    }
  }
}
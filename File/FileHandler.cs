namespace Cookie_Cookbook.File
{
  public class FileHandler
  {
    public void GenerateOrWriteTxt(string path, string content)
    {
      using StreamWriter writer = new(path, true);

      writer.WriteLine(content);
      writer.Close();
    }
  }
}
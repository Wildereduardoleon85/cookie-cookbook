namespace Cookie_Cookbook.Helpers
{
  public class FileHelper
  {
    public string GetFileExtension(string path)
    {
      string[] splittedPath = path.Split(".");
      string lastItem = splittedPath[^1];

      return lastItem;
    }
  }
}
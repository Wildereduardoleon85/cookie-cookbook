namespace Cookie_Cookbook.Helpers
{
  public class ListTrimmer
  {
    public List<string> Trim(List<string> untrimmedList)
    {
      List<string> trimmedList = new();

      foreach (var item in untrimmedList)
      {
        if (item.Trim() != "")
        {
          trimmedList.Add(item);
        }
      }
      return trimmedList;
    }
  }
}
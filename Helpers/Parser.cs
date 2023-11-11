namespace Cookie_Cookbook.Helpers
{
  public class Parser
  {
    public bool TryParseIngredientsIds(string input, out List<int> parsedList)
    {
      string[] stringIds = input.Split(",");
      List<int> numberIds = new();
      bool isValid = true;

      foreach (var item in stringIds)
      {
        bool isNumber = int.TryParse(item, out int parsedId);
        if (isNumber)
        {
          numberIds.Add(parsedId);
        }
        else
        {
          isValid = false;
        }
      }

      parsedList = numberIds;

      return isValid;
    }
  }
}
using Cookie_Cookbook.Ingredient;

namespace Cookie_Cookbook.UserInteraction
{
    public class Printer
    {
        private readonly string _initialInstruction = "Create a new cookie recipe! Available ingredients are:";
        private readonly string _addIngredientMessage = "Add an ingredient by it's Id or type anything else if finish.";

        public void PrintInstructions()
        {
            Console.WriteLine(_initialInstruction);
            new IngredientList().Print();
            Console.WriteLine(_addIngredientMessage);
        }
    }
}
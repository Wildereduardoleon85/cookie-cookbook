

namespace Cookie_Cookbook.UserInteraction
{
    public class UserInteraction
    {
        private readonly string initialInstruction = "Create a new cookie recipe! Available ingredients are:";

        public void ShowInstructions()
        {
            Console.WriteLine(initialInstruction);
        }
    }
}
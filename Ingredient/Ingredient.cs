

namespace Cookie_Cookbook.Ingredient
{
    public class DetailedIngredient
    {
        private List<string> _ingredientList = new()
        {
            "Wheat flour",
            "Coconut flour",
            "Butter",
            "Chocolate",
            "Sugar",
            "Cardamon",
            "Cinamon",
            "Cocoa powder",
        };
        public List<string> IngredientList
        {
            get { return _ingredientList; }
        }
    }

    public class Ingredient
    {
        public virtual int Id { get; }
        public virtual string Name { get; } = "";
    }

    public class WheatFlour : Ingredient
    {
        public override int Id => 1;
        public override string Name { get; } = "Wheat flour";
    }
}

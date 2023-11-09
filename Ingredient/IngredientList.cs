

namespace Cookie_Cookbook.Ingredient
{
    public class IngredientList
    {
        private readonly List<BaseIngredient> _ingredientList = new()
        {
            new WheatFlour(),
            new CoconutFlour(),
            new Butter(),
            new Chocolate(),
            new Sugar(),
            new Cardamon(),
            new Cinamon(),
            new CocoaPowder(),
        };

        public void Print()
        {
            foreach (var ingredient in _ingredientList)
            {
                Console.WriteLine($"{ingredient.Id}. {ingredient.Name}");
            }
        }

        protected class BaseIngredient
        {
            public virtual int Id { get; }
            public virtual string Name { get; } = "";
            public virtual string Instruction { get; } = "Add to other ingredients.";
        }

        protected class Spice : BaseIngredient
        {
            public override string Instruction => "Take half a teaspoon. Add to other ingredients.";
        }

        protected class Flour : BaseIngredient
        {
            public override string Instruction => "Sieve. Add to other ingredients.";
        }

        protected class WheatFlour : Flour
        {
            public override int Id => 1;
            public override string Name => "Wheat flour";
        }

        protected class CoconutFlour : Flour
        {
            public override int Id => 2;
            public override string Name => "Coconut flour";
        }

        protected class Butter : BaseIngredient
        {
            public override int Id => 3;
            public override string Name => "Butter";
            public override string Instruction => "Melt on low heat. Add to other ingredients.";
        }

        protected class Chocolate : BaseIngredient
        {
            public override int Id => 4;
            public override string Name => "Chocolate";
            public override string Instruction => "Melt in a water bath. Add to other ingredients.";
        }
        protected class Sugar : BaseIngredient
        {
            public override int Id => 5;
            public override string Name => "Sugar";
        }

        protected class Cardamon : Spice
        {
            public override int Id => 6;
            public override string Name => "Cardamon";
        }

        protected class Cinamon : Spice
        {
            public override int Id => 7;
            public override string Name => "Cinamon";
        }

        protected class CocoaPowder : BaseIngredient
        {
            public override int Id => 8;
            public override string Name => "Cocoa powder";
        }
    }
}

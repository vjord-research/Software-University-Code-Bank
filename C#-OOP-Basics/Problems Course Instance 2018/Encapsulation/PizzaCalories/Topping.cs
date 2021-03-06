using System;
using System.Linq;
using System.Collections.Generic;

public class Topping
{
    private const double MeatModifier = 1.2;
    private const double VeggiesModifier = 0.8;
    private const double CheeseModifier = 1.1;
    private const double SauceModifier = 0.9;

    private readonly IReadOnlyList<string> allowedTypes = new string[] { "meat", "veggies", "cheese", "sauce" };
    private string type;
    private double weight;

    public Topping(string type, double weight)
    {
        this.Type = type;
        this.Weight = weight;
    }

    private string Type
    {
        set
        {
            if (!this.allowedTypes.Contains(value.ToLower()))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }

            this.type = value;
        }
    }

    private double Weight
    {
        set
        {
            if (value < 0 || value > 50)
            {
                throw new ArgumentException($"{this.type} weight should be in the range [1..50].");
            }

            this.weight = value;
        }
    }

    public double CalcToppingCalories()
    {
        double typeModifier = 0;

        switch (this.type.ToLower())
        {
            case "meat":
                typeModifier = MeatModifier;
                break;

            case "veggies":
                typeModifier = VeggiesModifier;
                break;

            case "cheese":
                typeModifier = CheeseModifier;
                break;

            case "sauce":
                typeModifier = SauceModifier;
                break;
        }

        double result = this.weight * typeModifier * 2;
        return result;
    }
}
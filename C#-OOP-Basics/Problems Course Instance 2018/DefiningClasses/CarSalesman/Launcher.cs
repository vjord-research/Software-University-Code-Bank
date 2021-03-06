using System;
using System.Collections.Generic;
using System.Linq;

public class Launcher
{
    public static void Main()
    {
        int enginesCount = int.Parse(Console.ReadLine());
        List<Engine> enginesList = new List<Engine>();

        for (int i = 0; i < enginesCount; i++)
        {
            string[] engineInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string engineModel = engineInfo[0];
            string enginePower = engineInfo[1];
            string displacement = null;
            string efficiency = null;

            if (engineInfo.Length == 3)
            {
                bool isNumber = int.TryParse(engineInfo[2], out int parsedDisplacement);
                if (isNumber)
                {
                    displacement = parsedDisplacement.ToString();
                }
                else
                {
                    efficiency = engineInfo[2];
                }
            }

            if (engineInfo.Length == 4)
            {
                displacement = engineInfo[2];
                efficiency = engineInfo[3];
            }

            Engine currentEngine = new Engine
            {
                Model = engineModel,
                Power = enginePower,
                Displacement = displacement,
                Efficiency = efficiency
            };

            enginesList.Add(currentEngine);
        }

        List<Car> carsList = new List<Car>();

        int carsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < carsCount; i++)
        {
            string[] carInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string carModel = carInfo[0];
            string carEngine = carInfo[1];
            string weight = null;
            string color = null;

            if (carInfo.Length == 3)
            {
                bool isNumber = int.TryParse(carInfo[2], out int parsedWeight);
                if (isNumber)
                {
                    weight = parsedWeight.ToString();
                }
                else
                {
                    color = carInfo[2];
                }
            }

            if (carInfo.Length == 4)
            {
                weight = carInfo[2];
                color = carInfo[3];
            }

            Car currentCar = new Car
            {
                Model = carModel,
                Engine = enginesList.FirstOrDefault(e => e.Model.Equals(carEngine)),
                Weight = weight,
                Color = color
            };

            carsList.Add(currentCar);
        }

        foreach (Car car in carsList)
        {
            Console.WriteLine(car);
        }
    }
}
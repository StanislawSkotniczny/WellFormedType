using System;
using Temperatura;

namespace WellFormedType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Temperature t1 = new Temperature(); 
            Temperature t2 = new Temperature(25, TemperatureUnit.Celsius);
            Temperature t3 = new Temperature(75, TemperatureUnit.Fahrenheit); 

            Console.WriteLine(t1.ToString()); 
            Console.WriteLine(t2.ToString()); 
            Console.WriteLine(t3.ToString()); 

         
            Console.WriteLine(t1 == t2); 
            Console.WriteLine(t2 != t3); 
            Console.WriteLine(t2 > t3); 

            
            Temperature sum = t1 + t2;
            Console.WriteLine(sum.ToString()); 

            Temperature diff = t2 - t3;
            Console.WriteLine(diff.ToString());

            Temperature neg = -t2;
            Console.WriteLine(neg.ToString());

            Temperature mul = t2 * 2;
            Console.WriteLine(mul.ToString());

            Temperature div = t2 / 5;
            Console.WriteLine(div.ToString()); 

            
            double value = t2;
            Console.WriteLine(value); 

          
            Temperature temp = (Temperature)30;
            Console.WriteLine(temp.ToString());

            Temperature parsedTemp = Temperature.Parse("100 K");
            Console.WriteLine(parsedTemp.ToString());

           
            List<Temperature> temperatures = new List<Temperature>
        {
            new Temperature(20, TemperatureUnit.Celsius),
            new Temperature(10, TemperatureUnit.Fahrenheit),
            new Temperature(300, TemperatureUnit.Kelvin)
        };

            Console.WriteLine("Temperatury przed sortowaniem:");
            foreach (Temperature temperature in temperatures)
            {
                Console.WriteLine(temperature.ToString());
            }

            temperatures.Sort();

            Console.WriteLine("\nTemperatury po sortowaniu w skali Kelvina:");
            foreach (Temperature temperature in temperatures)
            {
                Console.WriteLine(temperature.ToString("K"));
            }

            Console.WriteLine("\nTemperatury po sortowaniu w skali Celsiusza:");
            foreach (Temperature temperature in temperatures)
            {
                Console.WriteLine(temperature.ToString("C"));
            }
        }
    }
}
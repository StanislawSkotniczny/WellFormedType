using System;
using System.Collections.Generic;
using System.Globalization;


namespace Temperatura
{
    public enum TemperatureUnit
    {
        Kelvin, Celsius, Fahrenheit
    }

    public struct Temperature : IFormattable, IEquatable<Temperature>, IComparable<Temperature>
    {
        private const double AbsoluteZeroKelvin = 0;

        private double kelvin;

        public Temperature(double value = 0, TemperatureUnit unit = TemperatureUnit.Kelvin)
        {
            if (unit == TemperatureUnit.Kelvin)
            {
                kelvin = value;
            }
            else if (unit == TemperatureUnit.Celsius)
            {
                kelvin = CelsiusToKelvin(value);
            }
            else if (unit == TemperatureUnit.Fahrenheit)
            {
                kelvin = FahrenheitToKelvin(value);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(unit));
            }

            if (kelvin < AbsoluteZeroKelvin)
            {
                //throw new ArgumentOutOfRangeException(nameof(value), "Temperature cannot be below absolute zero.");
            }
        }

        public double Celsius
        {
            get { return KelvinToCelsius(kelvin); }
            set { kelvin = CelsiusToKelvin(value); }
        }

        public double Fahrenheit
        {
            get { return KelvinToFahrenheit(kelvin); }
            set { kelvin = FahrenheitToKelvin(value); }
        }

        public double Kelvin
        {
            get { return kelvin; }
            set { kelvin = value; }
        }

        public override string ToString()
        {
            return ToString("C", CultureInfo.CurrentCulture);
        }

        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "C";
            }

            switch (format.ToUpperInvariant())
            {
                case "K":
                    return $"{kelvin.ToString("F4", formatProvider)} K";
                case "C":
                    return $"{Celsius.ToString("F4", formatProvider)} °C";
                case "F":
                    return $"{Fahrenheit.ToString("F4", formatProvider)} °F";
                default:
                    throw new FormatException($"The '{format}' Nieprawidłowy Format temperatury.");
            }
        }

        public static Temperature Parse(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentNullException(nameof(s));
            }

            if (s.EndsWith(" K", StringComparison.OrdinalIgnoreCase))
            {
                double kelvin = double.Parse(s.Substring(0, s.Length - 2), CultureInfo.CurrentCulture);
                return new Temperature(kelvin, TemperatureUnit.Kelvin);
            }
            else if (s.EndsWith(" C", StringComparison.OrdinalIgnoreCase))
            {
                double celsius = double.Parse(s.Substring(0, s.Length - 2), CultureInfo.CurrentCulture);
                return new Temperature(celsius, TemperatureUnit.Celsius);
            }
            else if (s.EndsWith(" F", StringComparison.OrdinalIgnoreCase))
            {
                double fahrenheit = double.Parse(s.Substring(0, s.Length - 2), CultureInfo.CurrentCulture);
                return new Temperature(fahrenheit, TemperatureUnit.Fahrenheit);
            }
            else
            {
                throw new FormatException("Nieprawidłowy Format temperatury.");
            }
        }

        public static bool operator ==(Temperature left, Temperature right)
        {
            return left.kelvin == right.kelvin;
        }

        public static bool operator !=(Temperature left, Temperature right)
        {
            return left.kelvin != right.kelvin;
        }

        public static bool operator <(Temperature left, Temperature right)
        {
            return left.kelvin < right.kelvin;
        }

        public static bool operator <=(Temperature left, Temperature right)
        {
            return left.kelvin <= right.kelvin;
        }

        public static bool operator >(Temperature left, Temperature right)
        {
            return left.kelvin > right.kelvin;
        }

        public static bool operator >=(Temperature left, Temperature right)
        {
            return left.kelvin >= right.kelvin;
        }

        public static Temperature operator +(Temperature left, Temperature right)
        {
            return new Temperature(left.kelvin + right.kelvin, TemperatureUnit.Kelvin);
        }

        public static Temperature operator -(Temperature left, Temperature right)
        {
            return new Temperature(left.kelvin - right.kelvin, TemperatureUnit.Kelvin);
        }

        public static Temperature operator *(Temperature temperature, double scalar)
        {
            return new Temperature(temperature.kelvin * scalar, TemperatureUnit.Kelvin);
        }

        public static Temperature operator /(Temperature temperature, double scalar)
        {
            return new Temperature(temperature.kelvin / scalar, TemperatureUnit.Kelvin);
        }

        public static Temperature operator -(Temperature temperature)
        {
            return new Temperature(-temperature.kelvin, TemperatureUnit.Kelvin);
        }

        public static implicit operator double(Temperature temperature)
        {
            return temperature.kelvin;
        }

        public static explicit operator Temperature(double value)
        {
            return new Temperature(value, TemperatureUnit.Kelvin);
        }

        public override bool Equals(object obj)
        {
            if (obj is Temperature)
            {
                return Equals((Temperature)obj);
            }

            return false;
        }

        public bool Equals(Temperature other)
        {
            return kelvin.Equals(other.kelvin);
        }

        public override int GetHashCode()
        {
            return kelvin.GetHashCode();
        }

        public int CompareTo(Temperature other)
        {
            return kelvin.CompareTo(other.kelvin);
        }

        private static double CelsiusToKelvin(double celsius)
        {
            return celsius + 273.15;
        }

        private static double KelvinToCelsius(double kelvin)
        {
            return kelvin - 273.15;
        }

        private static double FahrenheitToKelvin(double fahrenheit)
        {
            return (fahrenheit + 459.67) * 5 / 9;
        }

        private static double KelvinToFahrenheit(double kelvin)
        {
            return kelvin * 9 / 5 - 459.67;
        }

    }
}
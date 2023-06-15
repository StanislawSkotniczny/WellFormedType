using Temperatura;

namespace TestProject1
{
    [TestClass]
    public class TemperatureTests
    {
        [TestMethod]
        public void Equals_ReturnsTrue_WhenTemperaturesAreEqual()
        {
            // Arrange
            Temperature t1 = new Temperature(25, TemperatureUnit.Celsius);
            Temperature t2 = new Temperature(298.15, TemperatureUnit.Kelvin);

            // Act
            bool result = t1 == t2;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EqualsKiedyTemperaturySaRowne()
        {
            // Arrange
            Temperature t1 = new Temperature(0, TemperatureUnit.Celsius);
            Temperature t2 = new Temperature(32, TemperatureUnit.Fahrenheit);

            // Act
            bool result = t1 == t2;

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ZwracaPrawdeKiedyTemperaturaPoPrawejJEstMniejsza()
        {
            // Arrange
            Temperature t1 = new Temperature(20, TemperatureUnit.Celsius);
            Temperature t2 = new Temperature(300, TemperatureUnit.Kelvin);

            // Act
            bool result = t1 < t2;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ZwracaFalseKiedyTemperaturapolewejJestMniejsza()
        {
            // Arrange
            Temperature t1 = new Temperature(100, TemperatureUnit.Celsius);
            Temperature t2 = new Temperature(212, TemperatureUnit.Fahrenheit);

            // Act
            bool result = t1 < t2;

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void JednaTemperaturaMniejszal()
        {
            // Arrange
            Temperature t1 = new Temperature(25, TemperatureUnit.Celsius);
            Temperature t2 = new Temperature(298.15, TemperatureUnit.Kelvin);

            // Act
            bool result = t1 < t2;

            // Assert
            Assert.IsFalse(result);
        }
    }
    }
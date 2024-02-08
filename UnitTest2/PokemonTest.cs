namespace UnitTest2
{
    public class PokemonTest
    {
        [SetUp]
        public static void Setup()
        {
        }

        // Test the CalculateXp method
        [TestCase(20,100)]
        [TestCase(5,50)]
        public void TestCalculateXp(int enemyLevel, int expected)
        {
            // Arrange
            Pokemon pokemon = new("Pikachu", 10, 10, "Electric", 10, 10, true, 10, "Tackle", 10, "Tackle", 10, "Tackle", 10, "Tackle", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, false);
            // Act
            int actual = pokemon.CalculateXp(enemyLevel);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        //Test the AddXp method
        [TestCase(50, 50)]
        public void TestAddXp(int xp, int expected)
        {
            // Arrange
            Pokemon pokemon = new("Pikachu", 10, 10, "Electric", 5, 10, true, 10, "Tackle", 10, "Tackle", 10, "Tackle", 10, "Tackle", 10, 0, 10, 10, 10, 10, 10, 10, 10, 10, false);
            // Act
            pokemon.AddXp(xp);
            // Assert
            Assert.AreEqual(expected, pokemon.xp);
        }

        // Test the AddEgg method
        [Test]
        public void TestAddEgg()
        {
            Player player = new Player("Test");

            // Arrange
            Pokemon egg = new("Egg", 0, 0, "Normal", 1, 0, true, 0, "Tackle", 0, "Tackle", 0, "Tackle", 0, "Tackle", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, false);
            // Act
            Pokemon.AddEgg(player);
            // Assert
            Assert.AreEqual(egg.Name, player.Team[0].Name);
        }

        // Test the Evolve method
        [TestCase("pikachu", "raichu")]
        [TestCase("salameche", "reptincel")]
        [TestCase("bulbizarre", "herbizarre")]
        [TestCase("carapuce", "carabaffe")]
        public void TestEvolve(string Base, string Expected)
        {
            Pokemon pokemon = new(Base, 10, 10, "Electric", 5, 10, true, 10, "Tackle", 10, "Tackle", 10, "Tackle", 10, "Tackle", 10, 0, 10, 10, 10, 10, 10, 10, 10, 10, false);
            Player player = new Player("Test");
            player.Team[0] = pokemon;
            Pokemon.Evolve(Base, player);
            // Assert
            Assert.AreEqual(Expected, player.Team[0].Name);
        }


    }
}
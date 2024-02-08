namespace UnitTest2
{
    internal class PlayerTest
    {

        // Test the SetStarter method
        [TestCase("bulbizarre", "2")]
        [TestCase("carapuce", "3")]
        [TestCase("salameche", "1")]
        public void TestSetStarter(string expected, string choice)
        {
            // Arrange
            Player player = new("Test");
            // Act
            Player.SetStarter(choice, player);
            // Assert
            Assert.AreEqual(expected, player.Team[0].Name);
        }

        // Test the AddItem method
        [TestCase(1,"Potion","ultra")]
        [TestCase(1,"Pokeball", "standard")]
        [TestCase(4,"Potion", "great")]
        public void TestAddItem(int amount,string item, string type)
        {
            int type_id = 0;
            switch (type)
            {
                case "standard":
                    type_id = 0;
                    break;
                case "great":
                    type_id = 1;
                    break;
                case "ultra":
                    type_id = 2;
                    break;
            }
            // Arrange
            Player player = new ("Test");
            // Act
            player.AddItem(amount, item, type);
            // Assert
            if (item == "Potion")
            {
                Assert.AreEqual(amount, player.potion[type_id]);
            }
            else
            {
                Assert.AreEqual(amount, player.pokeball[type_id]);
            }
        }

        // Test the CheckEgg method
        [Test]
        public void TestCheckEgg()
        {
            // Arrange
            Player player = new("Test");
            // Act
            player.Team[0] = new("Egg", 0, 0, "Normal", 1, 0, true, 0, "Tackle", 0, "Tackle", 0, "Tackle", 0, "Tackle", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, false);
            // Assert
            Assert.AreEqual(true, Player.CheckEgg(player));
        }

        //Test the CheckStep method
        [TestCase(9,10)]
        [TestCase(10,11)]
        [TestCase(11,12)]
        public void TestCheckStep(int Base, int Expected)
        {

            // Arrange
            Player player = new("Test")
            {
                // Act
                Step = Base
            };

            player.Team[0] = new("Egg", 0, 0, "Normal", 1, 0, true, 0, "Tackle", 0, "Tackle", 0, "Tackle", 0, "Tackle", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, false);

            Player.CheckStep(player);
            // Assert
            Assert.AreEqual(Expected, player.Step);
        }
    }
}

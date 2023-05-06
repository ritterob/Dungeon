using AdventureLibrary;
using Xunit.Sdk;

namespace AdventureTests {
    public class UnitTest1 {
        [Fact]
        public void SwapWeaponOnceTest() {
            Player player = new ("", 1 , 1, 1, 1, 1,
                new List<Weapon> {new Whip(), new Webley()}, WeaponType.Whip);
            // Swap weapon
            string expected = "Webley";
            player.SwapWeapon();
            string actual = player.Wielded.Name;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void SwapWeaponTwiceTest() {
            Player player = new("", 1, 1, 1, 1, 1,
                new List<Weapon> { new Whip(), new Webley() }, WeaponType.Whip);
            // Swap weapon
            string expected = "Whip";
            player.SwapWeapon();
            player.SwapWeapon();
            string actual = player.Wielded.Name;
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(10, 4, 6)]
        [InlineData(7, 2, 6)]
        [InlineData(4, 4, 6)]
        [InlineData(4, 2, 6)]
        [InlineData(2, 2, 4)]
        [InlineData(0, 1, 1)]
        [InlineData(0, 0, 0)]
        public void ReloadTest(int ammoPouch, int cylinder, int expected) {
            Webley webley = new ();
            webley.Rounds = ammoPouch;
            webley.ShotsPerEncounter = cylinder;
            webley.Reload();
            int actual = webley.ShotsPerEncounter;
            Assert.Equal(expected, actual);
        }
    }
}
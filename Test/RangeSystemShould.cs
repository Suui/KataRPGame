using FluentAssertions;
using KataRPGame;
using NSubstitute;
using NUnit.Framework;


namespace Test
{
	[TestFixture]
	public class RangeSystemShould
	{
		[Test]
		public void prevent_from_attacking_an_enemy_that_is_too_far_away()
		{
			var player = Substitute.For<Character>();
			var enemy = new Character();

			player.AttackRange = 200.0;
			player.DistanceTo(enemy).Returns(201.0);
			player.ApplyDamageTo(enemy, 200.0);

			enemy.Health.Should().Be(1000.0);
		}
	}
}
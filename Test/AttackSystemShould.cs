using FluentAssertions;
using KataRPGame;
using NUnit.Framework;


namespace Test
{
	[TestFixture]
	public class AttackSystemShould
	{
		[Test]
		public void apply_damage_to_enemy()
		{
			var player = new Character();
			var enemy = new Character();

			player.ApplyDamageTo(enemy, 200.0);

			enemy.Health.Should().Be(800.0);
		}

		[Test]
		public void not_attack_himself()
		{
			var player = new Character();

			player.ApplyDamageTo(player, 200.0);

			player.Health.Should().Be(1000.0);
		}

		[Test]
		public void be_able_to_heal_himself()
		{
			var player = new Character();
			var enemy = new Character();

			enemy.ApplyDamageTo(player, 500.0);
			player.ApplyHealingTo(player, 300.0);

			player.Health.Should().Be(800.0);
		}

		[Test]
		public void not_heal_the_enemy()
		{
			var player = new Character();
			var enemy = new Character();

			player.ApplyDamageTo(enemy, 500.0);
			player.ApplyHealingTo(enemy, 300.0);

			enemy.Health.Should().Be(500.0);
		}

		[Test]
		public void not_damage_the_enemy_if_he_is_5_levels_over_you()
		{
			var player = new Character(20);
			var enemy = new Character(15);

			enemy.ApplyDamageTo(player, 500.0);

			player.Health.Should().Be(1000.0);
		}
	}
}
using FluentAssertions;
using KataRPGame;
using NUnit.Framework;

/*
	TODO:
	Character:	1000 health (starts with 1k)
				Level	(1-60)
				ReceiveDmg
				ReceiveHealing

	Tests
		ReceiveDmg < 0 ==> health = 0;
		ReceiveHealth > 1k ==> health = 1k;
*/


namespace Test
{
	[TestFixture]
	public class HealthSystemShould
	{
		[Test]
		public void be_zero_when_the_applied_damage_exceeds_current_health()
		{
			var character = new Character();

			character.ReceiveDamage(1200.0);

			character.Health.Should().Be(0.0);
		}

		[Test]
		public void be_death_when_at_zero_health()
		{
			var character = new Character();

			character.ReceiveDamage(1200);

			character.IsDeath().Should().BeTrue();
		}

		[Test]
		public void be_max_health_when_applied_healing_exceeds_max_health()
		{
			var character = new Character();

			character.ReceiveHealing(1200.0);

			character.Health.Should().Be(1000.0);
		}

		[Test]
		public void not_add_up_when_player_is_death()
		{
			var character = new Character();

			character.ReceiveDamage(1200);
			character.ReceiveHealing(1200);

			character.Health.Should().Be(0.0);
			character.IsDeath().Should().BeTrue();
		}
	}
}

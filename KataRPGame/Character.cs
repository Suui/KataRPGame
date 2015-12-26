namespace KataRPGame
{
	public class Character
	{
		public double Health { get; set; }
		public double MaxHealth { get; private set; }
		public double AttackRange { get; set; }
		public int Level { get; private set; }

		public Character()
		{
			Level = 1;
			MaxHealth = 1000.0;
			Health = MaxHealth;
			AttackRange = 200.0;
		}

		public Character(int level) : this()
		{
			Level = level;
		}

		public void ReceiveDamage(double damage)
		{
			Health -= damage;
			if (Health < 0.0) Health = 0.0;
		}

		public void ReceiveHealing(double healing)
		{
			if (IsDeath()) return;

			Health += healing;
			if (Health > MaxHealth) Health = MaxHealth;
		}

		public bool IsDeath()
		{
			return Health <= 0.0;
		}

		public void ApplyDamageTo(Character target, double damage)
		{
			if (target == this) return;
			if (Target(target).Has(5).LevelsOver(this)) return;
			if (DistanceTo(target) >= AttackRange) return;

			target.ReceiveDamage(damage);
		}

		private LevelComparator Target(Character target)
		{
			return new LevelComparator(target);
		}

		public void ApplyHealingTo(Character target, double healing)
		{
			if (target != this) return;

			target.ReceiveHealing(healing);
		}

		public virtual double DistanceTo(Character target)
		{
			return 0.0;
		}
	}

	internal class LevelComparator
	{
		private readonly Character _target;
		private int _levelDifference;

		public LevelComparator(Character target)
		{
			_target = target;
		}

		public bool LevelsOver(Character character)
		{
			return _target.Level - _levelDifference >= character.Level;
		}

		public LevelComparator Has(int levelDifference)
		{
			_levelDifference = levelDifference;

			return this;
		}
	}
}
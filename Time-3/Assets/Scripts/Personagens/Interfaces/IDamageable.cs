public interface IDamageable<HP>
{
	public bool ApplyDamage(HP damage);
	public void ApplyHealing(HP healing);
	public void Heal();
	public void Die();
}

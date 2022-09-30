using Player;

namespace Enemies
{
    public class MeleeEnemy : EnemyBase
    {
        protected override void Attack(PlayerController target)
        {
            target.TakeDamage(damage);
        }
    }
}
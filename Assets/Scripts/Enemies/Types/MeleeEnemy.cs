using Player;

namespace Enemies.Types
{
    public class MeleeEnemy : EnemyBase
    {
        protected override void Attack(PlayerController target)
        {
            target.TakeDamage(damage);
        }
    }
}
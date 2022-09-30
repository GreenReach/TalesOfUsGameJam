using Player;
using Unity.Mathematics;
using UnityEngine;

namespace Enemies
{
    public class RangedEnemy : EnemyBase
    {
        [SerializeField] private EnemyProjectile projectilePrefab;

        protected override void Attack(PlayerController target)
        {
            LaunchProjectileAt(target);
        }

        private void LaunchProjectileAt(PlayerController target)
        {
            var projectile = Instantiate(projectilePrefab, transform.position, quaternion.identity, transform);
            projectile.transform.right = projectile.transform.position - target.transform.position;
            projectile.Init(target);
        }
    }
}
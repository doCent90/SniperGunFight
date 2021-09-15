using UnityEngine;

public class EnemyBullet : Bullet
{
    public override void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.TakeDamage();
            Destroy(gameObject);
        }
    }
}

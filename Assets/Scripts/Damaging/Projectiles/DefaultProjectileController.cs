using UnityEngine;

public class DefaultProjectileController : MonoBehaviour, IProjectile
{
    [SerializeField] private ProjectileScriptableObject projectileData;    

    public void FlipProjectile()
    {
        this.GetComponent<SpriteRenderer>().flipY = true;
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {

            //Hit a Damageable Object
            damageable.TakeDamage(projectileData.damage);           
            
            //find object with tag "Player" and get the position of the object
            Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

            Vector2 direction =  other.transform.position - playerTransform.position;
            direction.Normalize();

            //Apply Knockback to the object
            damageable.CallKnockBack(direction, projectileData.knockBackForce, projectileData.knockBackDuration);

            //Destroy Bullet
            Destroy(gameObject);
        }
    }
    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Colosseum"))
        {
            Destroy(gameObject);
        }
    }

}

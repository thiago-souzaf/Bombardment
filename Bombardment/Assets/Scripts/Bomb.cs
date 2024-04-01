using UnityEngine;

public class Bomb : MonoBehaviour
{
	public float ExplosionDelay = 5.0f;
    [SerializeField] private GameObject go_explosionObject;
    [SerializeField] private LayerMask PlatformLayer;
    [SerializeField] private float ExplosionRadius;
    [SerializeField] private int ExplosionDamage;

    private void Start()
    {
        Invoke(nameof(Explode), ExplosionDelay);
    }

    private void Explode()
    {
        // Create VFX
        GameObject explosionFX = Instantiate(go_explosionObject, transform.position, Quaternion.identity);
        Destroy(explosionFX, 5f);

        // Destroy platforms
        Collider[] platformColliders = Physics.OverlapSphere(transform.position, ExplosionRadius, PlatformLayer);
        foreach(Collider collider in platformColliders)
        {
            if (collider.gameObject.TryGetComponent(out Life platformLife))
            {
                // Deal damage based on distance from explosion center
                float distance = (collider.transform.position - transform.position).magnitude;
                float distanceRate = Mathf.Clamp01(distance / ExplosionRadius);
                float damageRate = 1f - Mathf.Pow(distanceRate, 4);
                int damage = (int)Mathf.Ceil(damageRate * ExplosionDamage);
                platformLife.TakeDamage(damage);
            }
        }

        // Destroy bomb
        Destroy(gameObject);
    }
}

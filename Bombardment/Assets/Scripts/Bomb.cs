using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
	public float ExplosionDelay = 5.0f;
    [SerializeField] private GameObject go_explosionObject;

    private void Start()
    {
        StartCoroutine(ExplosionCoroutine());
    }

    private IEnumerator ExplosionCoroutine()
    {
        // Wait
        yield return new WaitForSeconds(ExplosionDelay);

        // Explode
        Explode();
    }

    private void Explode()
    {
        // Create VFX
        GameObject explosionFX = Instantiate(go_explosionObject, transform.position, Quaternion.identity);
        Destroy(explosionFX, 5f);

        // TODO

        // Destroy platforms
        // TODO


        // Destroy bomb
        Destroy(gameObject);
    }
}

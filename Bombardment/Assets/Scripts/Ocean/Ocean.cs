using UnityEngine;

public class Ocean : MonoBehaviour
{
    [SerializeField] GameObject[] splashEffects;
    [SerializeField] AudioClip[] splashSounds;

    private AudioSource audioSrc;

    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.EndGame();
            Splash(other.transform.position);
        }
        else if (other.gameObject.CompareTag("Bomb"))
        {
            Splash(other.transform.position);
        }

    }

    private void Splash(Vector3 position)
    {
        // Play splash sound
        AudioClip randomSound = splashSounds[Random.Range(0, splashSounds.Length)];
        audioSrc.PlayOneShot(randomSound, .4f);

        // Create splash visual effects
        GameObject randomSplash = splashEffects[Random.Range(0, splashEffects.Length)];
        GameObject go_Splash = Instantiate(randomSplash, position, randomSplash.transform.rotation, this.transform);

        Destroy(go_Splash, 3f);
    }
}

using UnityEngine;

public class Ocean : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.EndGame();
        }
    }
}

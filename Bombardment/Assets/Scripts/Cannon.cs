using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
	public List<GameObject> bombPrefabs;
	public Vector2 timeInterval = new(1, 1);
	public GameObject spawnPoint;
	public GameObject target;
	public float rangeInDegrees;
	public Vector2 force;
    public float arcDegrees = 45f;

	private float cooldown;

    private void Start()
    {
        cooldown = Random.Range(timeInterval.x, timeInterval.y);

    }

    private void Update()
    {

        // Ignore if game over
        if (GameManager.Instance.IsGameOver) return;

        cooldown -= Time.deltaTime;
        if (cooldown < 0)
        {
            cooldown = Random.Range(timeInterval.x, timeInterval.y);
            Fire();
        }
    }

    private void Fire()
    {
        GameObject bombPrefab = bombPrefabs[Random.Range(0, bombPrefabs.Count)];

        GameObject bomb = Instantiate(bombPrefab, spawnPoint.transform.position, bombPrefab.transform.rotation);
        Rigidbody bombRb = bomb.GetComponent<Rigidbody>();

        Vector3 impulseVector = target.transform.position - spawnPoint.transform.position;
        impulseVector.Scale(new(1, 0, 1));
        impulseVector.Normalize();
        impulseVector = Quaternion.AngleAxis(arcDegrees, -transform.forward) * impulseVector;
        impulseVector = Quaternion.AngleAxis(rangeInDegrees * Random.Range(-1f, 1f), Vector3.up) * impulseVector;

        impulseVector *= Random.Range(force.x, force.y);
        bombRb.AddForce(impulseVector, ForceMode.Impulse);
    }
}

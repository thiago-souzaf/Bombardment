using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	public bool IsGameOver { get; private set; }

	[SerializeField] private AudioSource music;
	[SerializeField] private AudioSource deadSFX;

	public void EndGame()
	{
		if (IsGameOver) return;

		IsGameOver = true;

		// Stop music
		music.Stop();

		// Play dead sfx
		deadSFX.Play();
	}
}

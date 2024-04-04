using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{

	[SerializeField] private static readonly string GameSceneName = "GameScene";
	public void LoadMainScene()
	{
		SceneManager.LoadScene(GameSceneName);
	}
}

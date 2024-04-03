using UnityEngine;
using TMPro;

public class GameplayUI : MonoBehaviour
{
    private readonly int SCORE_FACTOR = 10;

	[SerializeField] private TextMeshProUGUI scoreTMP;
	[SerializeField] private TextMeshProUGUI highScoreTMP;

    private void Start()
    {
        scoreTMP.text = GetScoreString();
        highScoreTMP.text = GetHighestScoreString();
    }

    private void Update()
    {
        scoreTMP.text = GetScoreString();
        highScoreTMP.text = GetHighestScoreString();
    }

    private string GetScoreString()
    {
        return (GameManager.Instance.GetScore() *  SCORE_FACTOR).ToString();
    }

    private string GetHighestScoreString()
    {
        return (GameManager.Instance.GetHighestScore() * SCORE_FACTOR).ToString();
    }

}

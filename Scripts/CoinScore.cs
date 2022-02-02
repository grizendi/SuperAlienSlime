using TMPro;
using UnityEngine;

public class CoinScore : MonoBehaviour
{
    private void Start()
    {
        int score = GameManager.Instance.Score;
        GetComponent<TextMeshProUGUI>().text = $"SCORE: {score}";
    }
}

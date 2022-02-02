using UnityEngine;
using TMPro;

public class TotalScore : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private int _score;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        _score = GameManager.Instance.Score;
        _text.text = $"total score: {_score}";
    }

}

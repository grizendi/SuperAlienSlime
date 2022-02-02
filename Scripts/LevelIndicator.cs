using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelIndicator : MonoBehaviour
{
    private void Start()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        GetComponent<TextMeshProUGUI>().text = $"LEVEL: {currentLevel}";
    }
}

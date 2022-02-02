using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Score { get; private set; }
    private int _currentLevelScore = 0;
    
    public int LightningCounter {get; private set;}
    public bool PlayerHasKey { get; private set; }

    private void Awake()
    {
        Score = 0;
        LightningCounter = 0;
        PlayerHasKey = false;

        DontDestroyOnLoad(this);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void AddLightningCounter() 
    {
        LightningCounter++;
        FindObjectOfType<SpeedUI>().AddLightning(LightningCounter);
    }
   
    public void AddScore() 
    { 
        Score++;
        FindObjectOfType<CoinScore>().GetComponent<TextMeshProUGUI>().text = $"SCORE: {Score}";
    }

    public void AddKey() 
    {
        PlayerHasKey = true;
    }


    IEnumerator LoadNextScene()
        {
            PlayerHasKey = false;
            LightningCounter = 0;
            _currentLevelScore = Score;
            ScreenFade.Instance.Animator.SetTrigger("NewScene");
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    
    IEnumerator ResetScene()
    {
        PlayerHasKey = false;
        LightningCounter = 0;
        Score = _currentLevelScore;
        ScreenFade.Instance.Animator.SetTrigger("NewScene");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}

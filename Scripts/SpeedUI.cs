using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUI : MonoBehaviour
{
    private Image _sprite;
    private TextMeshProUGUI _text;

    private void Start()
    {
        _sprite = GetComponent<Image>();
        _sprite.enabled = false;
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _text.enabled = false;
    }

    public void AddLightning(int lightningCounter) 
    {
        _sprite.enabled = true;
        _text.enabled = true;
        _text.text = lightningCounter.ToString();
    }


}

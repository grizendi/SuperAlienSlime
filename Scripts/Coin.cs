using UnityEngine;

public class Coin: MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.AddScore();
        Destroy(gameObject);
    }
}

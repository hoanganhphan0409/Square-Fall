using DG.Tweening;
using UnityEngine;

public class GoodSquare : Square
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.gameObject.GetComponent<Player>();
            if (player) player.ActiveFx();
            Observer.UpdateScore?.Invoke();
            transform.DOKill();
            gameObject.SetActive(false);
        }
    }
}

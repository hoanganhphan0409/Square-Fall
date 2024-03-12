using DG.Tweening;
using UnityEngine;

public class BadSquare : Square
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.gameObject.GetComponent<Player>();
            if (player) player.ActiveFx();
            DOTween.Sequence().AppendInterval(.1f).OnComplete(() => other.gameObject.SetActive(false));
            Observer.PlaySound?.Invoke(ESound.Lose);
            DOTween.Sequence().AppendInterval(.3f).OnComplete(() => Observer.LoseGame?.Invoke());
        }
    }
}

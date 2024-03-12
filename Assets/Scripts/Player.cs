using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float durationMove = 1f;
    [SerializeField] private ParticleSystem fx;
    private bool _moveToEnd;
    private bool _touchOrClickDetected;
    private bool _startGame;
    void Start()
    {
        transform.position = slider.StartPos;
        Observer.ReplayGame += OnReplayGame;
        Observer.StartGame += StartToPlay;

    }

    void StartToPlay()
    {
        DOTween.Sequence().AppendInterval(.2f).OnComplete(
            ()=>_startGame = true);
    }
    void RevertMove()
    {
        _moveToEnd = !_moveToEnd;
        transform.DOKill();
        transform.DOMove(_moveToEnd ? slider.EndPos : slider.StartPos, durationMove).OnComplete(()=> Observer.PlaySound?.Invoke(ESound.RevertMove));
    }
    void Update()
    {
        if (!_startGame) return;
        if (Input.touchCount == 0 && !Input.GetMouseButtonDown(0))
        {
            _touchOrClickDetected = false;
        }
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            if (_touchOrClickDetected == false)
            {
                _touchOrClickDetected = true;
                Observer.PlaySound?.Invoke(ESound.Tap);
                RevertMove();
            }
        }
    }

    void OnReplayGame()
    {
        gameObject.SetActive(true);
        transform.position = slider.StartPos;
    }

    private void OnDestroy()
    {
        Observer.ReplayGame -= OnReplayGame;
        Observer.StartGame -= StartToPlay;
    }

    public void ActiveFx()
    {
        fx.Play();
    }
}

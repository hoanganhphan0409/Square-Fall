using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PopupLose popupLose;
    [SerializeField] private GameObject popupStartGame;
    [SerializeField] private TextMeshProUGUI scoreTextGamePlay;
    private int _score;

    private void Start()
    {
        _score = 0;
        Observer.UpdateScore += IncreaseScore;
        Observer.LoseGame += OnLoseGame;
    }

    public void OnStartGame()
    {
        _score = 0;
        scoreTextGamePlay.text = _score.ToString();
        Observer.PlaySound?.Invoke(ESound.Button);
        popupStartGame.gameObject.SetActive(false);
        Observer.StartGame?.Invoke();
    }

    private void OnLoseGame()
    {
        popupLose.SetUpScoreText(_score);
        popupLose.gameObject.SetActive(true);
    }

    public void OnReplayGame()
    {
        Observer.PlaySound?.Invoke(ESound.Button);
        Observer.ReplayGame?.Invoke();
        _score = 0;
        scoreTextGamePlay.text = _score.ToString();
        popupLose.gameObject.SetActive(false);
    }
    
    private void IncreaseScore()
    {
        Observer.PlaySound?.Invoke(ESound.GetPoint);
        _score++;
        scoreTextGamePlay.text = _score.ToString();
    }

    private void OnDestroy()
    {
        Observer.UpdateScore -= IncreaseScore;
        Observer.LoseGame -= OnLoseGame;
    }
}

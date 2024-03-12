using TMPro;
using UnityEngine;

public class PopupLose : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCurrentScore;
    [SerializeField] private TextMeshProUGUI textBestScore;
    
    public void SetUpScoreText(int score)
    {
        if (Data.BestScore < score) Data.BestScore = score;
        textCurrentScore.text = score.ToString();
        textBestScore.text = "BEST " + Data.BestScore;
    }
}

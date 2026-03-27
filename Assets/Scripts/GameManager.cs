using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int playerScore;
    public int AIScore;
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI AIScoreText;

   public void PlayerPoint()
    {
        playerScore++;
        playerScoreText.text = playerScore.ToString();

    }

    public void AIPoint()
    {
        AIScore++;
        AIScoreText.text = AIScore.ToString();
    }

}

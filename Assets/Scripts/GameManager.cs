using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int playerScore;
    public int AIScore;
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI AIScoreText;

    public int pointsToWin = 10;

    [Header("Audios")]
    public AudioSource audioSource;
    public AudioClip scoreSfx;

    [Header("UI")]
    public GameObject winPanel;

    [Header("Paddles")]
    public GameObject paddleAI;
    public GameObject paddlePlayer2;

    public bool IsGameEnded 
    { 
        get; 
        private set; 
    }


    private void Awake()
    {
        ApplyGameMode();
    }

    private void Start()
    {
        Time.timeScale = 1f;
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }

    }

    void ApplyGameMode()
    {
        bool pvp = GameMode.IsPvP;

        if (paddleAI != null)
        {
            paddleAI.SetActive(!pvp);
        }

        if (paddlePlayer2 != null)
        {
            paddlePlayer2.SetActive(pvp);
        }
    }

    public void PlayerPoint()
    {
        if (IsGameEnded) return;

        JuiceText(playerScoreText);
        
        playerScore++;
        playerScoreText.text = playerScore.ToString();

        CheckWin();
    }

    public void AIPoint()
    {
        if (IsGameEnded) return;

        JuiceText(AIScoreText);
        
        AIScore++;
        AIScoreText.text = AIScore.ToString();

        CheckWin();
    }

    void JuiceText(TextMeshProUGUI text)
    {

        audioSource.PlayOneShot(scoreSfx);

        text.transform.DOKill();
        text.transform.localScale = Vector3.one;
        text.transform.DOScale(1.5f, 0.5f).SetLoops(2, LoopType.Yoyo);

        text.DOColor(Color.yellow, 0.5f).SetLoops(2, LoopType.Yoyo);

    }

    void CheckWin()
    {
        if (playerScore >= pointsToWin)
            EndGame("Player");
        else if (AIScore >= pointsToWin)
            EndGame("AI");
    }

    void EndGame(string winner)
    {
        IsGameEnded = true;

        if (winPanel != null)
            winPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

}

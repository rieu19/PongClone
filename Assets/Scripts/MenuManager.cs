using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [Header("AI Level")]
    public float easySpeed = 4f;
    public float hardSpeed = 7f;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayVsAiEasy()
    {
        GameMode.IsPvP = false;

        GameMode.AISpeed = easySpeed;

        SceneManager.LoadScene("GameScene");
    }

    public void PlayVsAIHard()
    {
        GameMode.IsPvP = false;

        GameMode.AISpeed = hardSpeed;

        SceneManager.LoadScene("GameScene");
    }

    public void PlayVsPlayer()
    {
        GameMode.IsPvP = true;
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

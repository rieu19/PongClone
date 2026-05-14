using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayVsAi()
    {
        GameMode.IsPvP = false;
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

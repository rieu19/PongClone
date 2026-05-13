using UnityEngine;

public class Wall : MonoBehaviour
{

    public GameManager gameManager;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ball")
        {
            if (gameManager.IsGameEnded)
                return;

            if (CompareTag("AIWall"))
            {
                gameManager.PlayerPoint();
            }

            if (CompareTag("PlayerWall"))
            {
                gameManager.AIPoint();
            }
            if (!gameManager.IsGameEnded)
                other.gameObject.GetComponent<Ball>().ResetBall();

        }
    }
}

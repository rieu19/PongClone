using DG.Tweening;
using UnityEngine;

public class PaddleJuice : MonoBehaviour
{
    public float bounceForce;
    public Transform paddleSprite;

    public void PlayHitEffect()
    {
        paddleSprite.transform.DOScale(1.3f, 0.1f).SetLoops(2, LoopType.Yoyo);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ball")
        {
            Rigidbody2D ballRig = other.gameObject.GetComponent<Rigidbody2D>();
            float yOffeset = other.transform.position.y - transform.position.y;
            float paddleHeight = GetComponent<Collider2D>().bounds.size.y;
            //transforma em -1 (bater embaixo) / 0 se bater no centro / 1 se bater em cima
            float normalizedY = yOffeset / (paddleHeight / 2f);

            Vector2 direction = new Vector2(Mathf.Sign(ballRig.linearVelocity.x), normalizedY).normalized;

            ballRig.linearVelocity = direction * bounceForce;
        }
    }
}

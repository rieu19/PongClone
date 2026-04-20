using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rig;
    private SpriteRenderer sprite;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine(PlayBall());
    }

    void Launch()
    {
        Vector2 direction = Vector2.zero;

        //quero que vá para esquerda
        if (Random.value < 0.5f)
        {
            direction = Vector2.left;
        }
        //quero que vá para a direita
        else
        {
            direction = Vector2.right;
        }

        direction.y = Random.Range(-0.5f, 0.5f);

        rig.linearVelocity = direction * speed;
    }

    public void ResetBall()
    {
        rig.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;

        StartCoroutine(PlayBall());
    }

    IEnumerator PlayBall()
    {
        sprite.enabled = true;
        yield return new WaitForSeconds(0.5f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.5f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.5f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.5f);
        sprite.enabled = true;
        Launch();
    }
    
}

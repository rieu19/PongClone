using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rig;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Launch();
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
    
}

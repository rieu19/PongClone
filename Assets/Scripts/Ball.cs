using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public TrailRenderer trail;

    private Rigidbody2D rig;
    public SpriteRenderer sprite;

    public GameObject explosion;

    [Header("Audios")]
    public AudioSource audioSource;
    public AudioClip explode;
    public AudioClip ballHit;
    public AudioClip gameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        

        StartCoroutine(PlayBall());
    }

    void Launch()
    {
        audioSource.PlayOneShot(ballHit);


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
        PlayExplode();

        GameObject exp = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(exp, 2f);

        sprite.transform.localScale = Vector3.one;
        rig.linearVelocity = Vector2.zero;
        trail.Clear();
        trail.enabled = false;
        transform.position = Vector2.zero;
        trail.enabled = true;
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Paddle")
        {
            other.gameObject.GetComponent<PaddleJuice>().PlayHitEffect();

            BallJuice();
        }

        if(other.gameObject.layer == 6)
        {
            BallJuice();
        }
    }

    void BallJuice()
    {
        audioSource.PlayOneShot(ballHit);

        sprite.transform.DOKill();
        sprite.transform.localScale = Vector3.one;

        sprite.transform.DOScale(1.8f, 0.1f).SetLoops(2, LoopType.Yoyo);

        Camera.main.transform.DOKill();
        Camera.main.transform.DOShakePosition(
            0.1f, //duração
            0.2f, //força do shake
            10,   //vibraçoes
            90,  // aleatoriedade
            false, //nao mudar o eixo z
            true // fade out
            );
    }

    void PlayExplode()
    {
        audioSource.PlayOneShot(explode);
        audioSource.PlayOneShot(gameOver);
    }
}

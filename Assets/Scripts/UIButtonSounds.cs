using UnityEngine;

public class UIButtonSounds : MonoBehaviour
{


    // Referência do AudioSource
    public AudioSource audioSource;

    // Som do botão
    public AudioClip clickSfx;

    // Método chamado pelo botão
    public void PlayClick()
    {
        audioSource.PlayOneShot(clickSfx);
    }

}

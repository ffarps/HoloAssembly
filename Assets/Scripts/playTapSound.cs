using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playTapSound : MonoBehaviour
{
    public AudioClip clip;
    public AudioClip quit;
    public float volume = 1f;
    public void PlaySound()
    {
        AudioSource.PlayClipAtPoint(clip, transform.position, volume);
    }
    public void QuitSound()
    {
        AudioSource.PlayClipAtPoint(quit, transform.position, volume);
    }
}

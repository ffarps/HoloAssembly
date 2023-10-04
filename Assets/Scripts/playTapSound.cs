using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playTapSound : MonoBehaviour
{
    public AudioClip tap;
    public AudioClip quit;
    public float volume = 1f;
    public void PlayTapSound()
    {
        AudioSource.PlayClipAtPoint(tap, transform.position, volume);
    }
    public void PlayQuitSound()
    {
        AudioSource.PlayClipAtPoint(quit, transform.position, volume);
    }
}

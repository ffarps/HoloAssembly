using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTapSound : MonoBehaviour
{
    public AudioClip tap;
    public AudioClip quit;
    public float volume;
    public void PlayTapSoundNow()
    {
        AudioSource.PlayClipAtPoint(tap, transform.position, volume);
    }
    public void PlayQuitSoundNow()
    {
        AudioSource.PlayClipAtPoint(quit, transform.position, volume);
    }
}

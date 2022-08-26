using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public AudioSource[] audioEffects;

    private void Awake()
    {
        instance = this;

    }

    public void MakeASoundEffect(int whichSound)
    {
        audioEffects[whichSound].Stop();
        audioEffects[whichSound].Play();
    }

    public void MakeAMixedSound(int whichSound)
    {
        audioEffects[whichSound].Stop();
        audioEffects[whichSound].pitch = Random.Range(0.8f, 1.3f);

        audioEffects[whichSound].Play();
    }
}

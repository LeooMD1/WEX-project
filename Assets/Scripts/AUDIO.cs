using UnityEngine;

public class Audio : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSouce;
    [SerializeField] AudioSource SFXSource;

    //[Header("---------- Audio Clip ----------")]
    //public AudioClip Football;
  
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
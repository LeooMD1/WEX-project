using UnityEngine;

public class Audio : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSouce;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip Football;
    public AudioClip Hit;
    public AudioClip Cheering;
    public AudioClip Pop;
    public AudioClip Whistle;
    public AudioClip coin;
  
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
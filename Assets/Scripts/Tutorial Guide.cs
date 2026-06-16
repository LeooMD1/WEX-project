using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialGuide : MonoBehaviour
{
    public float fadeOutTime = 4f;
    public float FadeInTime = 4.5f;
    public GameObject fadeOut;
    public GameObject fadeIn;



    private void Start()
    {
        StartCoroutine(IntroAnim());
        fadeOut.gameObject.SetActive(false);
    }

    IEnumerator IntroAnim() // Fade in and out stuff 
    {
        fadeIn.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        yield return new WaitForSeconds(FadeInTime);
        fadeIn.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }

    IEnumerator OutroAnim()
    {
        fadeOut.gameObject.SetActive(true);
        yield return new WaitForSeconds(fadeOutTime);
    }



}

using System.Collections;
using Unity.VisualScripting;
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
        yield return new WaitForSeconds(FadeInTime);
        fadeIn.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    IEnumerator OutroAnim()
    {
        fadeOut.gameObject.SetActive(true);
        yield return new WaitForSeconds(fadeOutTime);
        // trigger 
    }

    public void StartTutorialLevel1()
    {
        Time.timeScale = 1f;
        
    }

    public void StartTutorialLevel2()
    {

    }

    public void StartTutorialLevel3()
    {

    }



}

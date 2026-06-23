using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialGuide : MonoBehaviour
{
    public float fadeOutTime = 2.5f;
    public float FadeInTime = 2.5f;
    public GameObject fadeOut;
    public GameObject fadeIn;
    [SerializeField] PlayerController playerController;
    [SerializeField] Stopwatch stopwatch;
    public static int tutorialPart;
    public GameObject tutorialPopUp1;
    public GameObject tutorialPopUp2;
    public GameObject tutorialPopUp3;
    private bool canClick;
    public GameObject cannotClickpopUp;
    public float alertTime = 1.2f;
    public GameObject tutorialStartPopUp;

    int randomNum;


    private void Start()
    {
        StartCoroutine(IntroAnim());
        fadeOut.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !canClick)
        {
            StartCoroutine(cannotClickAlert());
        }
    }

    IEnumerator IntroAnim() // Fade in and out stuff 
    {
        canClick = false;
        stopwatch.enabled = false;
        playerController.enabled = false;
        fadeIn.gameObject.SetActive(true);
        yield return new WaitForSeconds(FadeInTime);
        fadeIn.gameObject.SetActive(false);
        Time.timeScale = 0f;

        if (tutorialPart == 0)
        {
            tutorialStartPopUp.gameObject.SetActive(true);
        }

        if (tutorialPart == 2)
        {
            tutorialPopUp2.gameObject.SetActive(true);
        }

        if (tutorialPart == 3)
        {
            tutorialPopUp3.gameObject.SetActive(true);
        }
    }

    public void startTutorial()
    {
        tutorialPart = 1;
        Time.timeScale = 1;
        tutorialPopUp1.gameObject.SetActive(true);
    }


    public void UnfreezePlayer()
    {
        playerController.enabled = true;
        stopwatch.enabled = true;
        canClick = true;
        Time.timeScale = 1f;
    }

    public void EndLevel1()
    {
        StartCoroutine(Level1Outro());
    }

    public void EndLevel2()
    {
        StartCoroutine(Level2Outro());
    }

    public void EndLevel3()
    {
        StartCoroutine(Level3Outros());
    }

    IEnumerator cannotClickAlert()
    {
        cannotClickpopUp.gameObject.SetActive(true);
        yield return new WaitForSeconds(alertTime);
        cannotClickpopUp.gameObject.SetActive(false);
    }

    IEnumerator Level1Outro()
    {
        fadeOut.gameObject.SetActive(true);
        yield return new WaitForSeconds(fadeOutTime);
        SceneManager.LoadSceneAsync(2);
        tutorialPart = 2;
    }

     IEnumerator Level2Outro()
    {
        fadeOut.gameObject.SetActive(true);
        yield return new WaitForSeconds(fadeOutTime);
        SceneManager.LoadSceneAsync(3);
        tutorialPart = 3;
    }

    IEnumerator Level3Outros()
    {
        fadeOut.gameObject.SetActive(true);
        yield return new WaitForSeconds(fadeOutTime);
        randomNum = Random.Range(4, 7); //change the "3" to however many levels there are gonna be in by the build index for example if there are 20 scenes then do (0, 20)
        Debug.Log("Selected Scene: " + randomNum); //or if there are levels you want to skip then youd need to play around with the build profiles and then change the first number
        SceneManager.LoadScene(randomNum); // PUT THE RANDOM SCENE SWAP HERE (either a method or a the whole script)
        MainMenu.tutorialIsDone = true;
    } 
}

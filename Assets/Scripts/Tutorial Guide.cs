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
    [SerializeField] PlayerController playerController;
    [SerializeField] Stopwatch stopwatch;
    [SerializeField] private int tutorialPart = 1;
    public GameObject tutorialPopUp1;
    private bool canClick;
    public GameObject cannotClickpopUp;
    public float alertTime = 2;

    int randomNum;


    private void Start()
    {
        StartCoroutine(IntroAnim());
        fadeOut.gameObject.SetActive(false);
        tutorialPart = PlayerPrefs.GetInt("tutorialPart", 1);
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

        if (tutorialPart == 1)
        {
            tutorialPopUp1.gameObject.SetActive(true);
        }

        if (tutorialPart == 2)
        {
            //tutorialPopUp2.gameObject.SetActive(true); (HAVENT CREATED OBJECTS YET)
        }

        if (tutorialPart == 3)
        {
            //tutorialPopUp3.gameObject.SetActive(true); (HAVENT CREATED OBJECTS YET)
        }
    }

    IEnumerator OutroAnim()
    {
        fadeOut.gameObject.SetActive(true);
        yield return new WaitForSeconds(fadeOutTime);
        tutorialPart++;
        PlayerPrefs.SetInt("tutorialPart", tutorialPart); // saves the tutorial part value onto the disk

        if (tutorialPart == 1)
        {
            SceneManager.LoadSceneAsync(2);
        }

        if (tutorialPart == 2)
        {
            SceneManager.LoadScene(3);
        }

        if (tutorialPart == 3)
        {
            MainMenu.tutorialIsDone = true;
            randomNum = Random.Range(4, 6); //change the "3" to however many levels there are gonna be in by the build index for example if there are 20 scenes then do (0, 20)
            Debug.Log("Selected Scene: " + randomNum); //or if there are levels you want to skip then youd need to play around with the build profiles and then change the first number
            SceneManager.LoadScene(randomNum); // PUT THE RANDOM SCENE SWAP HERE (either a method or a the whole script)
        }
    }

    public void UnfreezePlayer()
    {
        playerController.enabled = true;
        stopwatch.enabled = true;
        canClick = true;
    }

    IEnumerator cannotClickAlert()
    {
        cannotClickpopUp.gameObject.SetActive(true);
        yield return new WaitForSeconds(alertTime);
        cannotClickpopUp.gameObject.SetActive(false);
    }
}

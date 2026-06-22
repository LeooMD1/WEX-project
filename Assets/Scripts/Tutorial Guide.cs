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
        // trigger level change
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

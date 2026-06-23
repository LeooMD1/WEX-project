using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalPost : MonoBehaviour
{
    private BoxCollider2D col;
    [SerializeField] private CircleCollider2D playerCol;

    public GameObject endLevelScreen;
    public GameObject fadeOut;
    public float transitionTime;
    public GameObject nextLevelButton;
    public GameObject mainMenuButton;
    public GameObject playerObject;
    public GameObject mainStopWatchText;
   
    int randomNum;

    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") // changed this so then it doesn't rely on the player collider as much, and is something I know works - Ben
        {
            endLevelScreen.gameObject.SetActive(true);
            Stopwatch.isCounting = false;
            mainStopWatchText.gameObject.SetActive(false);
        }
    }

    public void nextLevel() // set to public because I want this method to be ran when the player clicks the "next level" button - Ben
    {
        StartCoroutine(TriggerNextLevel());
    }

    public void mainMenu()
    {
        StartCoroutine(ReturnToMainMenu());
    }

    IEnumerator ReturnToMainMenu()
    {
        fadeOut.gameObject.SetActive(true); // sets the fade out effect as active
        mainMenuButton.gameObject.GetComponent<Button>().interactable = false;
        nextLevelButton.gameObject.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(transitionTime); // puts a delay before changing the scene
        SceneManager.LoadSceneAsync(0); // chnages the scene to the main menu
    }

    IEnumerator TriggerNextLevel()
    {
        fadeOut.gameObject.SetActive(true); // sets the fade out effect as active
        mainMenuButton.gameObject.GetComponent<Button>().interactable = false;
        nextLevelButton.gameObject.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(transitionTime); // puts a delay before changing the scene
        Debug.Log("Scene change!");
        randomNum = Random.Range(4, 7); //change the "3" to however many levels there are gonna be in by the build index for example if there are 20 scenes then do (0, 20)
        Debug.Log("Selected Scene: " + randomNum);           //or if there are levels you want to skip then youd need to play around with the build profiles and then change the first number
        SceneManager.LoadScene(randomNum); // PUT THE RANDOM SCENE SWAP HERE (either a method or a the whole script)

    }

    IEnumerator TriggernextTutorialLevel() // This is for NON Random level changes (gets the level id and adds +1 onto it)
    {
        fadeOut.gameObject.SetActive(true); // sets the fade out effect as active
        mainMenuButton.gameObject.GetComponent<Button>().interactable = false;
        nextLevelButton.gameObject.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(transitionTime); // puts a delay before changing the scene
        Debug.Log("Scene change!");
        // SceneManager.

    }

}

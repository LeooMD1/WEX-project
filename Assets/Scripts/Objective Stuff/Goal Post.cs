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
   
    float randomNum;

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
            playerObject.gameObject.GetComponent<PlayerController>().enabled = false; // freezes player movement 
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // PUT THE RANDOM SCENE SWAP HERE (either a method or a the whole script)

    }

}

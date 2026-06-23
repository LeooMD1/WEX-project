using System.Collections;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public float fadeOutTime = 4f;
    public float FadeInTime = 4.5f;
    public GameObject fadeOut;
    public GameObject fadeIn;
    public GameObject startButton;
    public GameObject quitButton;

    public static bool tutorialIsDone = false;


    int randomNum;

    public void Start()
    {
        StartCoroutine(IntroAnim());
        fadeOut.gameObject.SetActive(false);
    }

    public void GameBegin()
    {
        Debug.Log("Game has begun");
        StartCoroutine(FadeOutandstart());
    }

    public void GameQuit()
    {
        if (Application.isPlaying)
        {
            StartCoroutine(FadeOutandQuitEditor());
        }

        else
        {
            StartCoroutine(FadeOutandQuit());
        }

    }

    IEnumerator FadeOutandstart()
    {
        fadeOut.gameObject.SetActive(true);
        startButton.GetComponent<Button>().interactable = false;
        quitButton.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(fadeOutTime);
        if (tutorialIsDone == false) { SceneManager.LoadSceneAsync(1);}
        else
        {
            randomNum = Random.Range(4, 6); //change the "3" to however many levels there are gonna be in by the build index for example if there are 20 scenes then do (0, 20)
            Debug.Log("Selected Scene: " + randomNum); //or if there are levels you want to skip then youd need to play around with the build profiles and then change the first number
            SceneManager.LoadScene(randomNum); // random scene swap
        }
        
    }

    IEnumerator FadeOutandQuit()
    {
        fadeOut.gameObject.SetActive(true);
        startButton.GetComponent<Button>().interactable = false;
        quitButton.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(fadeOutTime);
        Application.Quit();
        Debug.Log("Player has Quit the game!"); // This is for me to check that the method is actually running beacuse there is no way of showing it within editor
    }

    IEnumerator FadeOutandQuitEditor()
    {
        fadeOut.gameObject.SetActive(true);
        startButton.GetComponent<Button>().interactable = false;
        quitButton.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(fadeOutTime);
        Debug.Log("Player has Quit the game!"); // This is for me to check that the method is actually running beacuse there is no way of showing it within editor
        UnityEditor.EditorApplication.isPlaying = false;
    }

    IEnumerator IntroAnim()
    {
        fadeIn.gameObject.SetActive(true);
        startButton.GetComponent<Button>().interactable = false;
        quitButton.GetComponent<Button>().interactable = false;
        Cursor.lockState = CursorLockMode.Locked;
        yield return new WaitForSeconds(FadeInTime);
        startButton.GetComponent<Button>().interactable = true;
        quitButton.GetComponent<Button>().interactable = true;
        fadeIn.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;

    }
}

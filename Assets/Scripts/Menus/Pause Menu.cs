using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseManager;
    
    public GameObject quitMenu;
    public GameObject pauseMenu;
    public GameObject quitButton;
    public GameObject restartButton;
    public GameObject resumeButton;

    public GameObject leaveGameButton;
    public GameObject leaveLevelButton;

    public float fadeOutTime = 4f;
    public GameObject fadeOut;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.gameObject.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        // disable player interaction 
        StartCoroutine(FadeOutandRestart());
    }

    public void Resume()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitOverallGame()
    {
        Time.timeScale = 1f;
        StartCoroutine(QuitGame());
        // disable player interaction 
    }

    public void QuitOverallLEvel()
    {
        Time.timeScale = 1f;
        StartCoroutine(QuitLevel());
        // disable player interaction 
    }


    IEnumerator FadeOutandRestart()
    {
        fadeOut.gameObject.SetActive(true);
        resumeButton.GetComponent<Button>().interactable = false;
        quitButton.GetComponent<Button>().interactable = false;
        restartButton.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(fadeOutTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator QuitGame()
    {
        fadeOut.gameObject.SetActive(true);
        leaveGameButton.GetComponent<Button>().interactable = false;
        leaveLevelButton.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(fadeOutTime);
        Application.Quit();
        
        if (Application.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    IEnumerator QuitLevel()
    {
        fadeOut.gameObject.SetActive(true);
        leaveGameButton.GetComponent<Button>().interactable = false;
        leaveLevelButton.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(fadeOutTime);
        SceneManager.LoadSceneAsync(0);
    }


    // this script should be attached to either: a scene manager object or a general UI canvas




}

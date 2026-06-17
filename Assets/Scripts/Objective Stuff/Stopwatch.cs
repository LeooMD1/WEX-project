using System.Threading;
using TMPro;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI mainStopWatchText; // This is a reference to the stop watch counter displayed while in level
    [SerializeField] TextMeshProUGUI completeStopWatchText; // This is a refrence to the stop watch counter on the game complete screen
    public float time = 0;

    public static bool isCounting;

    private void Start()
    {
        isCounting = true;
    }

    public void Update()
    {
        if (isCounting == true)
        {
            time += Time.deltaTime;
        }

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        // if you can figure out how to add a millesecond counter here using a simlar method I would really appreciate it :) - Ben

        // this is for the main stop watch in the corner
        mainStopWatchText.text = time.ToString();
        mainStopWatchText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // this is for the level complete stopwatch text
        completeStopWatchText.text = time.ToString();
        completeStopWatchText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    public void freezeTime()
    {
        isCounting = false;
    }

    public void stopWatchStart()
    {
        isCounting = true;
    }

}

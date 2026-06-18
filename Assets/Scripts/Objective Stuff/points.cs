using UnityEngine;
using TMPro;

public class points : MonoBehaviour
{
    public int playerPoints;
    public TextMeshProUGUI pointsCounter;

    [SerializeField] private PlayerController playerController;
    [SerializeField] Stopwatch stopwatch;
    [SerializeField] Obstacle obstacle;

    private void Start()
    {
        playerPoints = 0;
    }

    private void Update()
    {
        pointsCounter.text = playerPoints.ToString();
    }

    
}

using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private static int coinsAmount;
    public TextMeshProUGUI coinsCounterMain;
    public TextMeshProUGUI coinsCounterEnd;

    private void Start()
    {
        coinsAmount = 0;
        
    }


    private void Update()
    {
        coinsCounterMain.text = "Coins: " + coinsAmount.ToString();
        coinsCounterEnd.text = "Coins Collected: " + coinsAmount.ToString();

        if (PlayerController.canCountdown == true) {coinsCounterMain.gameObject.SetActive(true);}
        else if (PlayerController.canCountdown == false) {coinsCounterMain.gameObject.SetActive(false);}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            coinsAmount += 1;
            Destroy(gameObject);
            // play sound effect
            Debug.Log("Coins Collected: " + coinsAmount);
        }
    }

}

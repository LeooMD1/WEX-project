using UnityEngine;

public class DEBUGPlayerManagerScript : MonoBehaviour
{
    public GameObject player;

    public bool playerCanMove;

    private void Start()
    {
        player.gameObject.GetComponent<DEBUGplayermovement>().enabled = true;
        playerCanMove = true;
        Debug.Log("DEBUG Player Movement Active!");
    }

    private void Update()
    {
        if (playerCanMove = true && (Input.GetKeyDown(KeyCode.O)))
        {
            player.gameObject.GetComponent<DEBUGplayermovement>().enabled = false;
            playerCanMove = false;
            Debug.Log("DEBUG Player Movement Inactive");
        }

        if (playerCanMove = false && (Input.GetKeyUp(KeyCode.O) && !playerCanMove))
        {
            player.gameObject.GetComponent<DEBUGplayermovement>().enabled = true;
            playerCanMove = true;
            Debug.Log("DEBUG Player Movement Active!");
        }
    }

    // This script just toggles the debug player movement On / Off 
    // This script should be attached to the game manager object on EVERY SCENE

}

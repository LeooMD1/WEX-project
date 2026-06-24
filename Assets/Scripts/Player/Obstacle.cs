using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
    public Transform playerspawn;
    public GameObject player;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private PlayerController pc;

    public float playerDeathCount;


    // sound effect here

    private void Start()
    {
        playerDeathCount = 0;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.position = playerspawn.transform.position;
            player.gameObject.GetComponent<PlayerController>().LosePoints();
            playerRb.linearVelocity = Vector2.zero;
            pc.moveSpeed = 0;
            pc.directionPicked = false;
        }
    }

}

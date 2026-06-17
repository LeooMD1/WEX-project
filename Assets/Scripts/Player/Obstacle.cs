using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
    public Transform playerspawn;
    public GameObject player;

    // sound effect here

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.position = playerspawn.transform.position;
        }
    }

}

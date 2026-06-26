using System.Collections.Generic;
using UnityEngine;

public class GoalKeeper : MonoBehaviour
{
    [Header("Player Death References")]
    public Transform playerspawn;
    public GameObject player;
    [SerializeField] private Rigidbody2D playerRb; // reference to the player object's rigidbody.
    [SerializeField] private PlayerController pc;
    [SerializeField] private Audio audios;


    [Header("Goal Keeper Movement References")]
    public List<GameObject> waypoints;
    public float speed = 2f;
    public int index = 0; // an integer which keeps track of what number place the player is heading to.
    public bool canLoop = true;

    private void Start()
    {
        
    }
    private void Update()
    {
        Vector2 destination = waypoints[index].transform.position; // sets the 
        Vector2 newPos = Vector2.MoveTowards(transform.position, waypoints[index].transform.position, speed * Time.deltaTime);
        transform.position = newPos;

        float distance = Vector2.Distance(transform.position, destination);

        if (distance <= 0.05)
        {
            if (index < waypoints.Count - 1) 
            {
                index++; 
            }

            else
            {
                if (canLoop == true)
                {
                    index = 0;
                }
            }
        }

    }


    // sound effect here

    private void OnCollisionEnter2D(Collision2D collision) // used for detecting player collisions 
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.position = playerspawn.transform.position;
            player.gameObject.GetComponent<PlayerController>().LosePoints();
            playerRb.linearVelocity = Vector2.zero;
            pc.moveSpeed = 0;
            pc.directionPicked = false;
            audios.PlaySFX(audios.Whistle);
        }
    }


}

using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    #region Variables
    [SerializeField] private float moveSpeed;
    [SerializeField] private float juumpForce;
    [SerializeField] private float rotateForce;
    [SerializeField] private float holdTime;
    [SerializeField] private float mouseRotate;
    
    [SerializeField] private float timer = 20;
    [SerializeField] private float timerCooldown = 20;
    [SerializeField] private float points = 100;
    
    [SerializeField] private bool isMoving;
    [SerializeField] private bool directionPicked;
    [SerializeField] private bool directionConfirmed; // why are they private if you just end up seralizing them?
    public int shotsTaken; //  the number of shots that the player takes 


    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform pointer;
    
    [SerializeField] private GameObject pointerObj;

    [SerializeField] private Transform centrePoint;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private Transform sprite;

    private float mouseX;
    private float mouseY;

    private float horizontal;

    [SerializeField] private Vector3 mousePosition;

    [SerializeField] private TextMeshProUGUI shotCounter;
    [SerializeField] private TextMeshProUGUI shotEndCounter;
    [SerializeField] private TextMeshProUGUI pointCounter;

    #endregion


    void Start()
    {
        directionConfirmed = false;
        directionPicked = false;

        pointerObj.SetActive(false);
        shotsTaken = 0;
        points = 100;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); // creates a circle which will allow the player to jump when colliding with the ground layer.
    }

    // Update is called once per frame
    void Update()
    {
        if (moveSpeed > 0.1)
            isMoving = true;
        else
            isMoving = false;

        if (moveSpeed < 0.1f)
            moveSpeed = 0;

        if (rotateForce < 1)
            rotateForce = 0;

        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
            OnClick();

        if (directionPicked)
            StartCoroutine(ShootBall());
        //horizontal = Input.GetAxis("Horizontal");
  

        //rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);

        moveSpeed = Mathf.Lerp(moveSpeed, 0, 0.002f);


        
        //rotateForce = Mathf.Lerp(rotateForce, 0, 0.0005f);
        
        sprite.rotation = Quaternion.Euler(0, 0, rotateForce * rb.linearVelocity.x);

        shotCounter.text = "Shots:" + shotsTaken.ToString();
        shotEndCounter.text = "Shots Taken: " + shotsTaken.ToString();

    
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            points -= 10;
            print ("Points: " + points);
            timer = timerCooldown;
        }

        if (points < 0)
        {
            points = 0;
        }

        
        pointCounter.text = points.ToString();
    }

    private void OnClick()
    {
        if (!directionPicked && !directionConfirmed && !isMoving && IsGrounded())
        {
            pointerObj.SetActive(true);

            mousePosition = Input.mousePosition;

            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            mousePosition -= gameObject.transform.position;

            centrePoint.position = mousePosition;

            mouseRotate = Mathf.Atan2(centrePoint.position.y, centrePoint.position.x) * Mathf.Rad2Deg;
            pointer.rotation = Quaternion.Euler(0, 0, mouseRotate);

            directionPicked = true;

        }

    }

    private IEnumerator ShootBall()
    {
        yield return new WaitForSeconds(0.1f);

        if (directionPicked && Input.GetKeyDown(KeyCode.Mouse0) && !isMoving && IsGrounded())
        {
            pointerObj.SetActive(false);
            moveSpeed = 3;
            juumpForce = 4;
            rotateForce = 180;

            //rb.AddForce(centrePoint.transform.position * moveSpeed, ForceMode2D.Impulse);

            rb.AddForceX(centrePoint.position.x * moveSpeed, ForceMode2D.Impulse);
            rb.AddForceY(centrePoint.position.y * juumpForce, ForceMode2D.Impulse);

            directionPicked = false;
            shotsTaken += 1;
            LosePoints();
        }

    }

    public void LosePoints()
    {
        points -= 2;
    }
}

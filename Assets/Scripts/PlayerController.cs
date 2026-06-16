using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    [SerializeField] private float moveSpeed;
    [SerializeField] private float juumpForce;
    [SerializeField] private float holdTime;
    [SerializeField] private float mouseRotate;
    
    [SerializeField] private bool isMoving;
    [SerializeField] private bool directionPicked;


    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform pointer;
    [SerializeField] private Transform centrePoint;

    private float mouseX;
    private float mouseY;

    private float horizontal;

    [SerializeField] private Vector3 mousePosition;


    #endregion


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
            OnClick();

        horizontal = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);

        
    }

    private void OnClick()
    {
        mousePosition = Input.mousePosition;

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        centrePoint.position = mousePosition;

        mouseRotate = Mathf.Atan2(centrePoint.position.y, centrePoint.position.x) * Mathf.Rad2Deg;
        pointer.rotation = Quaternion.Euler(0, 0, mouseRotate);
        
        print(mousePosition);

    }
}

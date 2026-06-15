using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    [SerializeField] private float moveSpeed;
    [SerializeField] private float juumpForce;
    [SerializeField] private float holdTime;
    [SerializeField] private float mouseRotate;


    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private RectTransform pointer;

    private float mouseX;
    private float mouseY;
    
    [SerializeField] Vector2 difference;
    [SerializeField] Vector3 mousePosition;


    #endregion


    void Start()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
            OnClick();

        difference = transform.position - mousePosition;

        mousePosition = Input.mousePosition;
        
        mouseRotate = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;

        pointer.rotation = Quaternion.Euler(mouseX, mouseY, mouseRotate);        
    }

    private void OnClick()
    {
        print(mousePosition);
    }
}

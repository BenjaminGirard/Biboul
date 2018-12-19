using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerController : MonoBehaviour {

    public float minimumX = -60f;
    public float maximumX = 60f;
    public float minimumY = -360f;
    public float maximumY = 360f;

    public float sensitivityX = 15f;
    public float sensitivityY = 15f;

    public float walkSpeed;
    public float jumpSpeed;

    float rotationY = 0f;
    float rotationX = 0f;

    Rigidbody rb;
    GameObject cam;

    Vector3 moveDirection;
    CapsuleCollider col;

    int isGrounded = 0;

    public Vector3 target;
    public float speed = 100;

    public bool isRotating = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        col = GetComponent<CapsuleCollider>();
    }

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        target = new Vector3(0f, 0f, 0f);
    }

    bool CanMove(Vector3 direction)
    {
        float distanceToPoints = col.height / 2 - col.radius;

        Vector3 point1 = col.center + Vector3.up * distanceToPoints;
        Vector3 point2 = col.center - Vector3.up * distanceToPoints;

        float radius = col.radius * 0.95f;
        float castDistance = 0.5f;

        RaycastHit[] hits = Physics.CapsuleCastAll(point1, point2, radius, direction, castDistance);
        foreach (RaycastHit objectHit in hits)
        {
            if (objectHit.transform.tag == "Wall")
            {
                return false;
            }
        }

        return true;
    }

    void Move()
    {
//        Vector3 yVelFix = new Vector3(0, rb.velocity.y, 0);
        transform.position += moveDirection * walkSpeed * Time.deltaTime;
        //rb.velocity += yVelFix;
    }

/*    bool isGrounded()
    {
        float distanceToPoints = col.height / 2 - col.radius;

        Vector3 point1 = col.center + Vector3.up * distanceToPoints;
        Vector3 point2 = col.center - Vector3.up * distanceToPoints;

        float radius = col.radius * 0.95f;
        float castDistance = 0.5f;

        RaycastHit[] hits = Physics.CapsuleCastAll(point1, point2, radius, Vector3.down, castDistance);
        foreach (RaycastHit objectHit in hits)
        {
            if (objectHit.transform.tag == "Wall")
            {
                return true;
            }
        }

        return false;
    }*/

    void Jump()
    {
        rb.velocity += transform.up * (jumpSpeed * Time.deltaTime);
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        float horizontalMovement = 0;
        float verticalMovement = 0;

        if (CanMove(transform.right * Input.GetAxisRaw("Horizontal")))
            horizontalMovement = Input.GetAxisRaw("Horizontal");

        if (CanMove(transform.right * Input.GetAxisRaw("Vertical")))
            verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = (horizontalMovement * transform.right + verticalMovement * transform.forward).normalized;

        rotationY = Input.GetAxis("Mouse X") * sensitivityY;
        rotationX += Input.GetAxis("Mouse Y") * sensitivityX;

        rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);
        //transform.localEulerAngles = target;
        //        var step = speed * Time.deltaTime;
        //        target.y = transform.rotation.y;

        cam.transform.localEulerAngles = new Vector3(-rotationX, 0, 0);

        if (isRotating)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(target), 0.05f);
            if (Quaternion.Angle(transform.rotation, Quaternion.Euler(target)) < 1f)
            {
                isRotating = false;
            }
        }
        else
        {
            transform.RotateAround(transform.position, transform.up, rotationY);
        }
    }

    private void FixedUpdate()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded > 0)
        {
            Jump();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isGrounded += 1;
    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded -= 1;
    }
}
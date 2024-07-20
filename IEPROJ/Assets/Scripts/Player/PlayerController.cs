using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerHeight;
    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField]
    private float speed;
    private float horizontal;
    private float vertical;
    Vector3 movementDir = Vector3.zero;
    [SerializeField]
    private Transform orientation;
    private Rigidbody rb;

    [SerializeField]
    private float groundDrag;
    private bool grounded;

    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 2f, whatIsGround);

        this.SpeedControl();
        this.ProcessInput();

        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        this.movePlayer();
    }

    private void ProcessInput()
    {
        this.horizontal = Input.GetAxisRaw("Horizontal");
        this.vertical = Input.GetAxisRaw("Vertical");
    }

    private void movePlayer()
    {

        Vector3 direction = new Vector3(this.horizontal,0,this.vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg + orientation.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            this.movementDir = Quaternion.Euler(0f,targetAngle,0f) * Vector3.forward;
            this.rb.AddForce(this.movementDir.normalized * speed * 10f, ForceMode.Force);
        }
       
    }

    private void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if (flatVelocity.magnitude > speed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * speed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    // Health - Shield
    public short minHealth = 0;
    public short maxHealth = 100;
    public short currentHealth;
    public short maxShield = 100;
    public short currentShield;
    public short minShield = 0;

    public HealthBar healthBar;
    public ShieldBar shieldBar;


    [Header("Camera")]
    public Transform cam;
    public bool lockCursor;

    [Range(0.1f, 10)] public float lookSensitivity;

    public float maxUpRotation;
    public float maxDownRotation;

    private float xRotation = 0;

    [Header("Movement")]
    public CharacterController controller;

    // Speed of forwards and backwards movement
    [Range(0.5f, 20)] public float walkSpeed;

    // Speed of sideways (left and right) movement
    [Range(0.5f, 15)] public float strafeSpeed;

    public KeyCode sprintKey;
    public KeyCode crouchKey;

    // How many times faster movement along the X and Z axes
    // is when sprinting
    [Range(1, 3)] public float sprintFactor;

    [Range(0.5f, 10)] public float jumpHeight;
    public int maxJumps;

    private Vector3 velocity = Vector3.zero;
    private int jumpsSinceLastLand = 0;

    void Start()
    {

        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentShield = minShield;
        shieldBar.SetMinShield(minShield);


        
    }

    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * lookSensitivity, 0);
        xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;
        xRotation = Mathf.Clamp(xRotation, -maxUpRotation, maxDownRotation);
        cam.localRotation = Quaternion.Euler(xRotation, 0, 0);

        velocity.z = Input.GetAxis("Vertical") * walkSpeed;
        velocity.x = Input.GetAxis("Horizontal") * strafeSpeed;
        velocity = transform.TransformDirection(velocity);

        //Crouch

        if (Input.GetKeyDown(crouchKey))
        {
            transform.position += new Vector3(0, 1f, 0);
        }

        if (Input.GetKeyUp(crouchKey))
        {
            transform.position += new Vector3(0, -1f, 0);

        }

        //Sprint
        if (Input.GetKey(sprintKey)) { Sprint(); }

        // Apply manual gravity
        velocity.y += Physics.gravity.y * Time.deltaTime;

        if (controller.isGrounded && velocity.y < 0) { Land(); }

        if (Input.GetButtonDown("Jump"))
        {
            if (controller.isGrounded)
            {
                Jump();
            }
            else if (jumpsSinceLastLand < maxJumps)
            {
                Jump();
            }
        }

        controller.Move(velocity * Time.deltaTime);
    }

    private void Sprint()
    {
        velocity.z *= sprintFactor;
        velocity.x *= sprintFactor;
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * Physics.gravity.y);
        jumpsSinceLastLand++;
    }

    private void Land()
    {
        velocity.y = 0;
        jumpsSinceLastLand = 0;
    }
}
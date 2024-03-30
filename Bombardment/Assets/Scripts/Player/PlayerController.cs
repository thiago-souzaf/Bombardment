using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Public fields
    public float movementSpeed = 10f;

    // StateMachine
    public StateMachine stateMachine;
    public Idle idleState;
    public Walking walkingState;

    // Internal fields
    [HideInInspector] public Vector2 movementVector;
    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        stateMachine = new();
        idleState = new(this);
        walkingState = new(this);
        stateMachine.ChangeState(idleState);
    }

    private void Update()
    {
        // Read Input
        bool isUp = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        bool isDown = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        bool isLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        bool isRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);

        // Create movement vector
        float inputX = isRight ? 1f : isLeft ? -1f : 0f;
        float inputY = isUp ? 1f : isDown ? -1f : 0f;
        movementVector = new(inputX, inputY);

        float speed = rb.velocity.magnitude;
        float speedRate = speed / movementSpeed;
        anim.SetFloat("fVelocity", speedRate);

        stateMachine.Update();
        
    }

    private void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }

    private void LateUpdate()
    {
        stateMachine.LateUpdate();
    }

    public Quaternion GetVectorAwayFromCamera()
    {
        Camera cam = Camera.main;
        float eulerY = cam.transform.eulerAngles.y;
        return Quaternion.Euler(0, eulerY, 0);
    }

    public void RotateBodyToFaceInput()
    {
        // Calculate rotation
        Camera cam = Camera.main;
        Vector3 inputVector = new(movementVector.x, 0, movementVector.y);
        Quaternion q1 = Quaternion.LookRotation(inputVector);
        Quaternion q2 = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0);
        Quaternion toRotation = q1 * q2;
        Quaternion smoothRotation = Quaternion.Lerp(transform.rotation, toRotation, 0.15f);

        // Apply rotation
        rb.MoveRotation(smoothRotation);
    }
}

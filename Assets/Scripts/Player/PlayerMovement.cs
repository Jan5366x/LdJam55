using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    public Vector3 CurrentDirection { get; set; }
    public float CurrentSpeed { get; set; }

    public Animator animator;
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Speed = Animator.StringToHash("Speed");

    private Rigidbody2D _rigidbody2D;

    public float verticalInput { get; set; }
    public float horizontalInput { get; set; }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        animator.SetFloat(Horizontal, CurrentDirection.x);
        animator.SetFloat(Vertical, CurrentDirection.y);
        animator.SetFloat(Speed, CurrentSpeed);
    }

    private void FixedUpdate()
    {

        _rigidbody2D.AddForce(new Vector3 ( + horizontalInput * speed * Time.deltaTime, verticalInput * speed* Time.deltaTime));

        CurrentSpeed = _rigidbody2D.velocity.magnitude;
        if (CurrentSpeed > 0.00001f)
        {
            CurrentDirection = _rigidbody2D.velocity.normalized;
        }
    }
}

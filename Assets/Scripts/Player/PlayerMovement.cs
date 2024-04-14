using System;
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
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        
        _rigidbody2D.AddForce(new Vector3 ( + horizontal * speed * Time.deltaTime, vertical * speed* Time.deltaTime));

        CurrentSpeed = _rigidbody2D.velocity.magnitude;
        if (CurrentSpeed > 0.00001f)
        {
            CurrentDirection = _rigidbody2D.velocity.normalized;
        }
    }
}

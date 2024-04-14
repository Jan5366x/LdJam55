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

        var lastPosition = transform.position;
        gameObject.transform.position = new Vector3 (transform.position.x + (horizontal * speed),
            transform.position.y + (vertical * speed));

        CurrentSpeed = Vector3.Distance(transform.position, lastPosition);
        Vector3 direction = transform.position - lastPosition;
        if (direction.magnitude > 0.00001f)
        {
            CurrentDirection = direction.normalized;
        }
    }
}

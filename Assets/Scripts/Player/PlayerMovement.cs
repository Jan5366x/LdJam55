using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    
    public Vector3 CurrentDirection { get; set; }
    public float CurrentSpeed { get; set; }

    private void FixedUpdate()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        var lastPosition = transform.position;
        gameObject.transform.position = new Vector3 (transform.position.x + (horizontal * speed), 
            transform.position.y + (vertical * speed));
        
        CurrentSpeed = Vector3.Distance(transform.position, lastPosition);
        CurrentDirection = (transform.position - lastPosition).normalized;
    }
}

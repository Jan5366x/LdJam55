using System;
using UnityEngine;

[ExecuteInEditMode]
public class GridSnap : MonoBehaviour
{
    private Vector3 lastPos = new();
  
    [ContextMenu("Align")]
    public void Align()
    {
        var position = transform.position;
        
        if (lastPos == position)
            return;
        
        position.x = MathF.Round(position.x);
        position.y = MathF.Round(position.y);
        position.z = 0f;

        transform.position = position;
        lastPos = position;

        gameObject.name = "Grid_" + (int)position.x + "_" + (int)position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Align();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    
    void Start()
    {
        InvokeRepeating(nameof(RollMethod), 1f,0.02f);
    }

    private void RollMethod()
    {
        transform.Rotate(Vector3.up,5f);
    }
    
}

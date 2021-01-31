using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class BugMovement : MonoBehaviour
{
    Transform _transform;
    Vector3 originalPos;
    float randTimeShift;

    private void Awake()
    {
        _transform = transform;
        originalPos = transform.position;
        randTimeShift = Random.Range(0f, 10f);
    }

    private void Update()
    {
        _transform.position = originalPos + new Vector3((float)Sin(randTimeShift +Time.time * 6f), 
                                                        (float)Sin(randTimeShift +Time.time * 8f), 0f) * 0.5f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitSpawner : MonoBehaviour
{
    public GameObject shit;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var newShit = Instantiate(shit);
            newShit.transform.position = transform.position - new Vector3(0f, 1.8f, 0f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatable : MonoBehaviour
{
    public float[] attribute;

    public void Eat()
    {
        Debug.Log("Eatable Eat");
        Destroy(gameObject);
        //GetComponent<SpriteRenderer>().enabled = false;
    }
}

public enum Attribute
{
    HEALTH,
    MANA
}

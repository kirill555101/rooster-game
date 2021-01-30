using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatable : MonoBehaviour
{
    public float[] attribute;

    public void Eat()
    {
        Destroy(gameObject);
    }
}

public enum Attribute
{
    HEALTH,
    MANA
}

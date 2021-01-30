using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    float[] attribute;

    public Collider2D checkField;
    public float maxHealth;
    public float maxMana;
    bool tryToEat;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryToEat();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Coolision");
        Eatable obj;
        if (tryToEat && (obj = collision.gameObject.GetComponent<Eatable>()) != null)
        {
            Health += obj.attribute[(int)Attribute.HEALTH];
            Mana += obj.attribute[(int)Attribute.MANA];
            tryToEat = false;
        }
    }

    public float Health
    {
        get => attribute[(int)Attribute.HEALTH];
        set
        {
            float result = attribute[(int)Attribute.HEALTH] + value;
            if (result > maxHealth) result = maxHealth;
            else if (result < maxHealth) Debug.Log("DIE");
            attribute[(int)Attribute.HEALTH] = result;
        }
    }

    public float Mana
    {
        get => attribute[(int)Attribute.MANA];
        set
        {
            float result = attribute[(int)Attribute.MANA] + value;
            if (result > maxMana) result = maxMana;
            else if (result < maxMana) Debug.Log("Can't poop");
            attribute[(int)Attribute.MANA] = result;
        }
    }

    public void TryToEat()
    {
        tryToEat = true;
        StopAllCoroutines();
        StartCoroutine(NoFoodDelay());
    }

    IEnumerator NoFoodDelay()
    {
        yield return new WaitForSeconds(0.1f);
        tryToEat = false;
    }
}

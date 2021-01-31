using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    float[] attribute;

    //public Collider2D checkField;
    public float maxHealth;
    public float maxMana;
    bool tryToEat;

    private void Awake()
    {
        attribute = new float[2] { maxHealth, 0f };
    }

    public void OnTriggerStay2D(Collider2D collider)
    {
        //Debug.Log("Coolision");
        Eatable obj;
        //Debug.Log(collider.GetComponent<Eatable>() == null);

        if (tryToEat && (obj = collider.GetComponent<Eatable>()) != null)
        {
            //Debug.Log("EEEEE");
            Health += obj.attribute[(int)Attribute.HEALTH];
            Mana += obj.attribute[(int)Attribute.MANA];
            tryToEat = false;
            //checkField.enabled = false;
            obj.Eat();
        }
    }

    public float Health
    {
        get => attribute[(int)Attribute.HEALTH];
        set
        {
            float result = attribute[(int)Attribute.HEALTH] + value;
            if (result > maxHealth) result = maxHealth;
            else if (result < 0) Debug.Log("DIE");
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
            else if (result < 0) Debug.Log("Can't poop");
            attribute[(int)Attribute.MANA] = result;
        }
    }

    public void TryToEat()
    {
        tryToEat = true;
        //checkField.enabled = true;
        StopAllCoroutines();
        StartCoroutine(NoFoodDelay());
    }

    IEnumerator NoFoodDelay()
    {
        yield return new WaitForSeconds(0.1f);
        tryToEat = false;
        //checkField.enabled = false;
    }
}

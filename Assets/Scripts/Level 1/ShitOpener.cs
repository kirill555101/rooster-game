using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitOpener : MonoBehaviour
{
    public Sprite openedLock, closedLock;
    public GameObject openedSign, closedSign;
    public bool isActive = false;

    GameObject door;

    private void Start()
    {
        door = GameObject.Find("Дверь");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isActive)
        {
            return;
        }

        print(other.tag);
        if (other.tag == "Shit" || other.tag == "Player")
        {
            GetComponent<SpriteRenderer>().sprite = openedLock;
            door.GetComponent<BoxCollider2D>().enabled = false;
            closedSign.SetActive(false);
            openedSign.SetActive(true);

            if (other.tag == "Shit")
            {
                isActive = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (isActive)
        {
            return;
        }

        if (other.tag == "Player")
        {
            GetComponent<SpriteRenderer>().sprite = closedLock;
            door.GetComponent<BoxCollider2D>().enabled = true;
            closedSign.SetActive(true);
            openedSign.SetActive(false);
        }
    }
}

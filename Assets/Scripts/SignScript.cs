using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignScript : MonoBehaviour
{
    public GameObject lockedSign, openedSign;

    ShitOpener shitOpener;

    private void Start()
    {
        shitOpener = GameObject.Find("Кнопка открытия решеткки не нажатая").GetComponent<ShitOpener>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (shitOpener.isActive)
        {
            openedSign.SetActive(true);
            return;
        }

        if (other.tag == "Player")
        {
            lockedSign.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (shitOpener.isActive)
        {
            openedSign.SetActive(false);
            return;
        }

        if (other.tag == "Player")
        {
            lockedSign.SetActive(false);
        }
    }
}

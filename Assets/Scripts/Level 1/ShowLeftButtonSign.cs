using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLeftButtonSign : MonoBehaviour
{
    public GameObject sign;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            sign.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            sign.SetActive(false);
        }
    }
}

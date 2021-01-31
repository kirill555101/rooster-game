using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    public GameObject sign, lastSign, exitSign, end;
    public Sprite sprite;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetMouseButtonDown(0))
        {
            sign.SetActive(true);
            end.SetActive(true);
            Destroy(lastSign);
            exitSign.GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }
}

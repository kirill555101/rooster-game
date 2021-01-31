using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameObject panel;
    public Sprite killedOnRightSide, killedOnLeftSide, deadCock;

    public bool isOnRightSide = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            panel.SetActive(true);
            Connector.player.GetComponent<SpriteRenderer>().sortingOrder = 7;
            collision.GetComponent<PlayerMovement>().isMovable = false;
            Connector.player.GetComponent<SpriteRenderer>().sprite = deadCock;
            StartCoroutine(GameObject.Find("GameManager").GetComponent<SceneManager>().KillPlayer());

            if (isOnRightSide)
            {
                GetComponent<SpriteRenderer>().sprite = killedOnRightSide;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = killedOnLeftSide;
            }
        }
    }
}

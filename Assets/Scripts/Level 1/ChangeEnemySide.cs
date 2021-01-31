using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnemySide : MonoBehaviour
{
    public GameObject enemy, sign;
    public Sprite leftSide, rightSide;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ChangeSide());
        }
    }

    IEnumerator ChangeSide()
    {
        sign.SetActive(true);
        yield return new WaitForSeconds(2f);
        var killPlayer = enemy.GetComponent<KillPlayer>();
        enemy.GetComponent<BoxCollider2D>().offset *= new Vector2(-1, 1);
        sign.SetActive(false);

        if (killPlayer.isOnRightSide)
        { 
            killPlayer.isOnRightSide = false;
            enemy.GetComponent<SpriteRenderer>().sprite = leftSide;
        }
        else
        {
            killPlayer.isOnRightSide = true;
            enemy.GetComponent<SpriteRenderer>().sprite = rightSide;
        }
    }
}

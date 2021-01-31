using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShownEnemySign : MonoBehaviour
{
    public GameObject sign;

    bool isActive = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isActive)
        {
            sign.SetActive(true);
            Destroy(sign, 2f);
            isActive = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNextLocation : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            collision.transform.position = new Vector3(20.02f, 64.07f, 0f);
        }
    }
}

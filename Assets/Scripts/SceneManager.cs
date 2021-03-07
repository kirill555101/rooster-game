using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    bool isDead = false;

    public IEnumerator KillPlayer()
    {
        yield return new WaitForSeconds(2f);
        isDead = true;
    }

    void Update()
    {
        if (isDead && Input.anyKey)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
    }
}

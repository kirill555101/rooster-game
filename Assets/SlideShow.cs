using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideShow : MonoBehaviour
{
    public Sprite[] images;

    int currentImage = 0;
    UnityEngine.UI.Image image;

    private void Start()
    {

        image = GetComponent<UnityEngine.UI.Image>();
        image.sprite = images[currentImage];
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            image.sprite = images[currentImage++];

            if (currentImage >= images.Length)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            }
        }
    }
}

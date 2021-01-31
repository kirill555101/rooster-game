using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayer : MonoBehaviour
{
    Bounds mapRectangle;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        mapRectangle = spriteRenderer.bounds;
    }

    void Update()
    {
        var playerRectangle = Connector.player.GetComponent<SpriteRenderer>().bounds;

        if (mapRectangle.min.y <= playerRectangle.min.y)
        {
            spriteRenderer.sortingOrder = 4;
        }
        else
        {
            spriteRenderer.sortingOrder = 2;
        }
    }
}

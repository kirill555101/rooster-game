using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Sprite[] leftRun, rightRun, forwardRun;

    Vector3 moveDiff;
    int currentSprite = 0;
    SpriteRenderer spriteRenderer;
    Bounds mapRectangle;
    bool walksOnLeftFoot = true;

    void Start()
    {
        spriteRenderer = Connector.player.GetComponent<SpriteRenderer>();
        mapRectangle = Connector.map.GetComponent<SpriteRenderer>().bounds;
    }

    void Update()
    {
        moveDiff = new Vector3(0f, 0f, 0f);

        if (Input.GetKey(KeyCode.W))
        {
            MovePlayer(ref forwardRun);
            moveDiff.y+= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDiff.y -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            MovePlayer(ref leftRun);
            moveDiff.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            MovePlayer(ref rightRun);
            moveDiff.x += 1;
        }

        moveDiff.Normalize();                                  
        moveDiff = moveDiff * moveSpeed * Time.deltaTime;

        var y = transform.position.y + moveDiff.y;

        if (y >= mapRectangle.max.y - 135 / 100.0 || y <= mapRectangle.min.y + 170 / 100.0) 
        { 
            return; 
        }
        transform.position += moveDiff;                      
    }

    IEnumerator ChangeSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
        yield return new WaitForSeconds(0.01f);
    }

    void MovePlayer(ref Sprite[] move)
    {
        StartCoroutine(ChangeSprite(move[currentSprite]));

        if (walksOnLeftFoot)
        {
            currentSprite += 1;
        }
        else
        {
            currentSprite = 3;
        }

        if (currentSprite == 3)
        {
            currentSprite = 0;
            walksOnLeftFoot = true;
        }
        else if (currentSprite == 2 && walksOnLeftFoot)
        {
            currentSprite = 0;
            walksOnLeftFoot = false;
        }
    }
}

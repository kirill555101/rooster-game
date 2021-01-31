using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Sprite[] leftRun, rightRun, forwardRun, backwardRun;
    public GameObject sign;
    public bool isMovable = true;

    Vector3 moveDiff;
    int currentFrame = 0;
    SpriteRenderer spriteRenderer;
    int[] currentFramess;
    bool hasStartedCorountine = false, hasShownSign = false;
    PlayerAttributes playerAttributes;

    void Start()
    {
        currentFramess = new int[4] { 0, 1, 0, 2 };
        spriteRenderer = Connector.player.GetComponent<SpriteRenderer>();
        playerAttributes = GetComponent<PlayerAttributes>();
    }

    void Update()
    {
        if (!isMovable)
        {
            return;
        }

        moveDiff = new Vector3(0f, 0f, 0f);

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse 0");
            playerAttributes.TryToEat();
            if (!hasShownSign)
            {
                StartCoroutine(ShowSign());
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (!hasStartedCorountine)
                StartCoroutine(ChangeSprite(forwardRun[currentFramess[currentFrame]]));
            moveDiff.y+= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (!hasStartedCorountine)
                StartCoroutine(ChangeSprite(backwardRun[currentFramess[currentFrame]]));
            moveDiff.y -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (!hasStartedCorountine)
                StartCoroutine(ChangeSprite(leftRun[currentFramess[currentFrame]]));
            moveDiff.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (!hasStartedCorountine)
                StartCoroutine(ChangeSprite(rightRun[currentFramess[currentFrame]]));
            moveDiff.x += 1;
        }

        moveDiff.Normalize();                                  
        moveDiff = moveDiff * moveSpeed * Time.deltaTime;
        transform.position += moveDiff;                      
    }

    IEnumerator ChangeSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
        hasStartedCorountine = true;
        yield return new WaitForSeconds(0.1f);
        currentFrame++;
        if (currentFrame > 3)
        {
            currentFrame = 0;
        }
        hasStartedCorountine = false;
    }

    IEnumerator ShowSign()
    {
        hasShownSign = true;
        sign.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        sign.SetActive(false);
        hasShownSign = false;
    }
}

using System.Collections;
using UnityEngine;

public class PersonView : MonoBehaviour
{
    //public float speed = 5f; // Speed of movement
    //public float distanceToMove = 3f; // Distance to move

    //private SpriteRenderer spriteRenderer;
    //private Vector3 leftPosition;
    //private Vector3 centerPosition;
    //private Vector3 rightPosition;
    //private Vector3 targetPosition;
    //private bool isMoving = false;

    //void Start()
    //{
    //    spriteRenderer = GetComponent<SpriteRenderer>();

    //    leftPosition = new Vector3(leftPosition.x - distanceToMove, leftPosition.y, leftPosition.z);
    //    centerPosition = transform.position;
    //    rightPosition = new Vector3(leftPosition.x + distanceToMove, leftPosition.y, leftPosition.z);
    //}

    //void Update()
    //{
    //    if (isMoving)
    //    {
    //        // Move towards the target position
    //        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

    //        // Check if reached the target position
    //        if (transform.position == targetPosition)
    //            isMoving = false;
    //    }
    //}

    //// Method to move sprite from left to center
    //public void MoveLeftToCenter()
    //{
    //    transform.position = leftPosition;
    //    targetPosition = centerPosition;
    //    isMoving = true;
    //}

    //// Method to move sprite from center to right
    //public void MoveCenterToRight()
    //{
    //    targetPosition = rightPosition;
    //    isMoving = true;
    //}

    public Transform leftPosition;
    public Transform centerPosition;
    public Transform rightPosition;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void MoveLeftToCenter()
    {
        transform.position = leftPosition.position;
        StartCoroutine(MoveSprite(centerPosition.position));
    }

    public void MoveCenterToRight()
    {
        transform.position = centerPosition.position;
        StartCoroutine(MoveSprite(rightPosition.position));
    }

    private IEnumerator MoveSprite(Vector3 targetPosition)
    {
        float duration = 1.0f;
        Vector3 startPosition = transform.position;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }

    public void SetPersonSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
}
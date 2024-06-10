using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public enum Direction { Horizontal, Vertical }
    public Direction moveDirection = Direction.Horizontal;
    public float moveDistance = 5f;
    public float moveSpeed = 2f;

    private Vector3 startPosition;
    private bool movingForward = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        float movement = moveSpeed * Time.deltaTime;
        if (moveDirection == Direction.Horizontal)
        {
            if (movingForward)
                transform.position += new Vector3(movement, 0, 0);
            else
                transform.position -= new Vector3(movement, 0, 0);
        }
        else
        {
            if (movingForward)
                transform.position += new Vector3(0, movement, 0);
            else
                transform.position -= new Vector3(0, movement, 0);
        }

        if (Vector3.Distance(startPosition, transform.position) >= moveDistance)
            movingForward = !movingForward;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.collider.transform.SetParent(transform);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.collider.transform.SetParent(null);
    }
}

using UnityEngine;

public class treeScript : MonoBehaviour
{
    public float speed;
    private bool isMoving = false;
    //maybe change these based on difficulty / time played?
    public float dropInterval;
    public float dropChance;
    private float dropTimer = 0f;
    private float globalTimer = 0f;
    private Vector2 targetPosition;
    Rigidbody2D rb;
    public GameObject applePrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        chooseNewTarget();
    }

    void FixedUpdate()
    {
        moveTree();
        dropApple();
        globalTimer += Time.fixedDeltaTime;
        //game gets harder every 10 seconds
        if (globalTimer >= 10f)
        {
            globalTimer = 0f;
            if (dropChance < 0.6f)
            {
                dropChance += 0.1f;
            }
            if (dropInterval > 0.2)
            {
                dropInterval -= 0.1f;
            }
            if (speed < 20f)
            {
                speed += 5f;
            }
        }
    }


    void moveTree()
    {
        if (isMoving)
        {
            Vector2 currentPosition = rb.position;
            float distance = Vector2.Distance(currentPosition, targetPosition);
            if (distance < 0.2f)
            {
                isMoving = false;
                chooseNewTarget();
            }
            else
            {
                Vector2 direction = (targetPosition - currentPosition).normalized;
                rb.MovePosition(currentPosition + direction * speed * Time.fixedDeltaTime);
            }
        }
    }

    void chooseNewTarget()
    {
        float randomX = Random.Range(-8f, 8f);
        targetPosition = new Vector2(randomX, rb.position.y);
        isMoving = true;
    }
    void dropApple()
    {
        dropTimer += Time.fixedDeltaTime;
        if (dropTimer >= dropInterval)
        {
            dropTimer = 0f;
            float randomValue = Random.Range(0f, 1f);
            if (randomValue <= dropChance)
            {
                Instantiate(applePrefab, transform.position, Quaternion.identity);
            }
        }
    }
}

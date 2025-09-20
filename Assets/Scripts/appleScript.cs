using UnityEngine;

public class appleScript : MonoBehaviour
{
    public float fallSpeed;
    float rotationSpeed;

    void Start()
    {
        rotationSpeed = Random.Range(-200f, 200f);
    }
    void FixedUpdate()
    {
        transform.position += Vector3.down * fallSpeed * Time.fixedDeltaTime;
        //make apple keep rotating  as it falls
        transform.Rotate(0f, 0f, rotationSpeed * Time.fixedDeltaTime);
    }
}
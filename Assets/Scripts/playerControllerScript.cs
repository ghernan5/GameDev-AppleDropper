using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerControllerScript : MonoBehaviour
{
    public float moveSpeed;
    ScoreManagerScript scoreManager;
    private AudioSource audioSource;

    void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManagerScript>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnMove(InputValue value)
    {
        float deltaX = value.Get<float>();
        Vector3 newPosition = transform.position + new Vector3(deltaX * moveSpeed * Time.deltaTime, 0, 0);
        newPosition.x = Mathf.Clamp(newPosition.x, -8f, 8f);
        transform.position = newPosition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            //play sound from audio source
            audioSource.Play();
            Destroy(other.gameObject);
            scoreManager.addScore();
        }
    }
}

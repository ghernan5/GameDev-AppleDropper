using UnityEngine;

public class groundScript : MonoBehaviour
{
    public GameObject player;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (player != null && player.transform.childCount == 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            Destroy(other.gameObject);

            //remove the basket sprite from player 
            if (player.transform.childCount > 0)
            {
                Destroy(player.transform.GetChild(0).gameObject);
                if (player.transform.childCount == 0)
                {
                    //RESET SCENE!
                    UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
                }
            }
            audioSource.Play();
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody player;
    [SerializeField] private GameManager GameManager;
    [SerializeField] private Animator birdanimator;
    [SerializeField] private GameObject Crashsmoke;

    public float strength = 5f;
    public float gravity = -9.81f;
    public float tilt = 5f;

    public AudioClip FlyAudioClip, DeathAudioClip, ScoredAudioClip;

    private AudioSource audioSource;

    private void Start()
    {
        player = GetComponent<Rigidbody>();
        birdanimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        if (GameManager == null)
        {
            GameManager = FindFirstObjectByType<GameManager>(); 
        }
    }

    private void Update()
    {
        if (GameManager.isGameOver) return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            player.linearVelocity = Vector3.up * strength;
            audioSource.PlayOneShot(FlyAudioClip);
        }

        if (player.linearVelocity.y > 0)
        {
            birdanimator.SetBool("flying", true);
            birdanimator.SetBool("falling", false);
        }
        else
        {
            birdanimator.SetBool("flying", false);
            birdanimator.SetBool("falling", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Scoring"))
        {
            GameManager.IncreaseScore();
            audioSource.PlayOneShot(ScoredAudioClip);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            birdanimator.enabled = false;
            GameManager.GameOver();
            audioSource.PlayOneShot(DeathAudioClip);

            if (Crashsmoke != null)
            {
                Instantiate(Crashsmoke, transform.position, Quaternion.identity);
            }
        }
    }
}

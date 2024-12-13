using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;
    public float speed = 10;
    public Rigidbody rb;

    public ScoreManager scoreManager;
    public GameObject gameOverPanel;
    public static bool gameOver;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;
    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] private float jumpCooldown = 0.2f;
    private bool canJump = true;

    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    // Update is called once per frame
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (transform.position.y < -5)
        {
            Die();
        }

        if (gameOver)
        {
            Debug.Log("Game Over Triggered!");
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

    }
    public void Die()
    {
        alive = false;

        // Ensure ScoreManager is notified
        if (scoreManager != null)
        {
            scoreManager.PlayerDied(); // This stops the score
        }

        // Restart the game after 2 seconds
        Invoke("Restart", 2);
    }


    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    void Jump()
    {
        if (!canJump) return;
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
            canJump = false; // Matikan kemampuan lompat sementara
            Invoke(nameof(ResetJump), jumpCooldown); // Aktifkan kembali setelah cooldown
        }
    }

    void ResetJump()
    {
        canJump = true; // Aktifkan kembali kemampuan lompat
    }
}

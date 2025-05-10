using UnityEngine;

public class Player : MonoBehaviour
{
    bool isAlive = true;
    private Rigidbody rb;
    [SerializeField] float speed = 20f;
    private float horizontalInput;

    // Jump
    [SerializeField] float jumpForce = 100f;
    private bool isGrounded = false;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        if (transform.position.y < -5 && isAlive)
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        if (!isAlive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + horizontalMove + forwardMove);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void Jump()
    {
        animator.SetTrigger("Jump");
        rb.AddForce(Vector3.up * jumpForce);
    }

    public void Die()
    {
        isAlive = false;

        GameOverManager gameOverManager = FindObjectOfType<GameOverManager>();
        if (gameOverManager != null)
        {
            gameOverManager.ShowGameOver();
        }
        else
        {
            Debug.LogError("GameOverManager not found in the scene.");
        }
    }
}

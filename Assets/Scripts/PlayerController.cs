using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool hasPowerup = false;
    private Rigidbody2D playerRb2d;
    private GameManager gameManager;
    private float yBound = -5;
    private float xRange = 9;
    // Start is called before the first frame update
    void Start()
    {
        playerRb2d = GetComponent <Rigidbody2D>();
        Physics.gravity *= gravityModifier;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1;
        }
        else
        {
            horizontalInput = 0;
        }
        
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb2d.AddForce(Vector2.up* jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }

        if (transform.position.y < yBound)
        {
            Destroy(gameObject);
            gameManager.GameOver();
        }

        if (transform.position.x > xRange)
        {
            Destroy(gameObject);
            gameManager.GameOver();
        }
        else if (transform.position.x < -xRange)
        {
            Destroy(gameObject);
            gameManager.GameOver();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        isOnGround = true;
        if (collision2D.gameObject.CompareTag("Player2") && hasPowerup)
            Debug.Log("Collided with " + collision2D.gameObject.name + " with powerup set to " + hasPowerup);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        hasPowerup = false;
    }
}

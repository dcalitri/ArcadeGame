using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 5.0f;
    public float jumpForce;
    public float gravityModifier;
    public float powerupStrength = 5.0f;
    public float powerupSpeedBoost = 12.0f;
    public bool isOnGround = true;
    public bool hasPowerup = false;
    public bool hasPowerup2 = false;
    private Rigidbody2D player2Rb2d;
    private GameManager gameManager;
    private float yBound = -5;
    private float xRange = 9;
    private float boostTimer;
    private bool boosting;

    // Start is called before the first frame update
    void Start()
    {
        player2Rb2d = GetComponent<Rigidbody2D>();
        Physics.gravity *= gravityModifier;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // How to Quit back to the Arcade Machine main menu
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }

        speed = 5;
        boostTimer = 0;
        boosting = false;
    }

    // Update is called once per frame
    void Update()
    {
       if(gameManager.isGameActive)
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

            if (Input.GetKeyDown(KeyCode.Z) && isOnGround)
            {
                player2Rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isOnGround = false;
            }
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

        if (boosting)
        {
            boostTimer += Time.deltaTime;

            if (boostTimer >= 3)
            {
                speed = 5;
                boostTimer = 0;
                boosting = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        isOnGround = true;

        if (collision2D.gameObject.CompareTag("Player2") && hasPowerup)
        {
            Rigidbody2D player2RigidBody2D = collision2D.gameObject.GetComponent<Rigidbody2D>();
            Vector3 awayFromPlayer = (collision2D.gameObject.transform.position - transform.position);

            player2RigidBody2D.AddForce(awayFromPlayer * powerupStrength, ForceMode2D.Impulse);
            Debug.Log("Collided with " + collision2D.gameObject.name + " with powerup set to " + hasPowerup);
        }

        if (collision2D.gameObject.CompareTag("Player2") && hasPowerup)
        {
            Rigidbody2D player2RigidBody2D = collision2D.gameObject.GetComponent<Rigidbody2D>();
            Vector3 awayFromPlayer = (collision2D.gameObject.transform.position - transform.position);

            player2RigidBody2D.AddForce(awayFromPlayer * powerupSpeedBoost, ForceMode2D.Impulse);
            Debug.Log("Collided with " + collision2D.gameObject.name + " with powerup set to " + hasPowerup2);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }

        if (other.CompareTag("Powerup2"))
        {
            hasPowerup2 = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }

        if (other.CompareTag("Powerup2"))
        {
            boosting = true;
            speed = 12.0f;
            Destroy(other.gameObject);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(10);
        hasPowerup = false;
    }
}

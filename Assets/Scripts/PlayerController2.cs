using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float jumpForce;
    public float gravityModifier;
    public float powerupStrength = 15.0f;
    public bool isOnGround = true;
    public bool hasPowerup = false;
    private Rigidbody2D player2Rb2d;
    private GameManager gameManager;
    private float yBound = -5;
    private float xRange = 9;

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
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = 1;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1;
        }
        else
        {
            horizontalInput = 0;
        }

        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        if (Input.GetKeyDown(KeyCode.Alpha4) && isOnGround)
        {
            player2Rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }

        if(transform.position.y < yBound)
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

        if (collision2D.gameObject.CompareTag("Player1") && hasPowerup)
        {
            Rigidbody2D player2RigidBody2D = collision2D.gameObject.GetComponent<Rigidbody2D>();
            Vector3 awayFromPlayer = (collision2D.gameObject.transform.position - transform.position);

            player2RigidBody2D.AddForce(awayFromPlayer * powerupStrength, ForceMode2D.Impulse);
            Debug.Log("Collided with " + collision2D.gameObject.name + " with powerup set to " + hasPowerup);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
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
    }
}

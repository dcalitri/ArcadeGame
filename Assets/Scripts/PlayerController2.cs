using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    private Rigidbody2D player2Rb2d;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    private float yBound = -5;

    // Start is called before the first frame update
    void Start()
    {
        player2Rb2d = GetComponent<Rigidbody2D>();
        Physics.gravity *= gravityModifier;
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

        if (Input.GetKeyDown(KeyCode.Keypad4) && isOnGround)
        {
            player2Rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }

        if(transform.position.y < yBound)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        isOnGround = true;
    }
}

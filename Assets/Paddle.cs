using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 5f;
    private float input;

    public GameObject left;
    public GameObject right;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Player 2")
        {
            if (Input.GetKey("a"))
            {
                input = -1;
            }
            else if (Input.GetKey("d"))
            {
                input = 1;
            }
            else
            {
                input = 0;
            }
        }

        if (gameObject.tag == "Player 1")
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                input = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                input = 1;
            }
            else
            {
                input = 0;
            }
        }

        var paddleRight = transform.position.x + (GetComponent<Collider2D>().bounds.size.x / 2);
        var leftWallRight = left.transform.position.x + (left.GetComponent<Collider2D>().bounds.size.x / 2);
        var rightWallLeft = right.transform.position.x - (right.GetComponent<Collider2D>().bounds.size.x / 2);

        if (paddleRight < leftWallRight)
        {
            transform.position = new Vector3(rightWallLeft + (GetComponent<Collider2D>().bounds.size.x / 2), transform.position.y, transform.position.z);
        }

        var paddleLeft = transform.position.x - (GetComponent<Collider2D>().bounds.size.x / 2);

        if (paddleLeft > rightWallLeft)
        {
            transform.position = new Vector3(leftWallRight - (GetComponent<Collider2D>().bounds.size.x / 2), transform.position.y, transform.position.z);
        }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * input * speed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (FindObjectOfType<BrickManager>().playSoundOnDestroyBrick)
        {
            Camera.main.GetComponents<AudioSource>()[1].Play();
        }

        if (other.gameObject.tag == "wall")
        {
            Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
        }
    }
}

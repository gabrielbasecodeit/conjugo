using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 5f;
    private float input;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
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
    }
}

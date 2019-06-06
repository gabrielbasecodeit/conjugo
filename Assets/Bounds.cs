using UnityEngine;

public class Bounds : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Ball>().Respawn();
        FindObjectOfType<BrickManager>().ResetLevel(0);
        ScoreScript.scoreValue = 0;
    }
}

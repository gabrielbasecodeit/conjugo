using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public int rows;
    public int columns;
    public float spacing;
    public GameObject brickPrefab;
    private List<GameObject> bricks = new List<GameObject>();
    public bool stretchBricks;
    public bool playSoundOnDestroyBrick;
		public bool enableParticleSystem;
		public bool enableCameraShake;
		public GameObject particleSystem;

    // private Color brickColor;

    // Use this for initialization
    void Start()
    {
        ResetLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetLevel()
    {
        foreach (var brick in bricks)
        {
            Destroy(brick);
        }

        bricks.Clear();

        for (var x = 0; x < columns; x++)
        {
            for (var y = 0; y < rows; y++)
            {
                var newX = x * (brickPrefab.transform.localScale.x + spacing);
                var newY = -y * (brickPrefab.transform.localScale.y + spacing);
                var spawnPosition = (Vector2)transform.position + new Vector2(newX, newY);

                var newBrick = Instantiate(brickPrefab, spawnPosition, Quaternion.identity);
                //newBrick.GetComponent<SpriteRenderer>().color = brickColor;

                newBrick.transform.parent = this.transform;
                bricks.Add(newBrick);
            }
        }
    }

    public void RemoveBrick(Brick brick)
    {
        bricks.Remove(brick.gameObject);
        if (bricks.Count == 0)
        {
            ResetLevel();
        }
    }
}

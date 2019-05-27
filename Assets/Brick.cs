using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        var brickManager = FindObjectOfType<BrickManager>();

        if (brickManager.stretchBricks)
        {
            var lerper = gameObject.AddComponent<ScaleLerper>();
            lerper.maxScale.x = -2;
            lerper.maxScale.y = -2;
            lerper.repeatable = true;

            if (brickManager.playSoundOnDestroyBrick)
            {
                Camera.main.GetComponents<AudioSource>()[0].Play();
            }

            if (brickManager.enableParticleSystem)
            {
                GameObject firework = Instantiate(brickManager.particleSystem, gameObject.transform.position, Quaternion.identity);
                firework.GetComponent<ParticleSystem>().Play();
            }

            StartCoroutine(WaitSecondsAndDestroy(1, brickManager));

            brickManager.RemoveBrick(this);
        }
        else
        {
            Destroy(gameObject);
            brickManager.RemoveBrick(this);
        }
    }

    IEnumerator WaitSecondsAndDestroy(int seconds, BrickManager manager)
    {
        if (manager.enableCameraShake)
        {
            var cameraShake = Camera.main.gameObject.AddComponent<CameraShake>();
            cameraShake.camTransform = Camera.main.transform;
        }

        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}

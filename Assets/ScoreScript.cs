using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    // Use this for initialization
    public static int scoreValue = 0;
    public static int levelValue = 0;
    Text score;
    Text level;
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreValue;
        level.text = "Level: " + levelValue;
    }
}
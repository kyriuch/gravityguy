using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStarter : MonoBehaviour {

    public ScrollingBackground Obstacles;

    public TextMeshProUGUI TextMesh;

    public static int Score = 0;


    private float startTime;

	// Use this for initialization
	void Start () {
        Invoke("startGame", 3);
    }
	
	// Update is called once per frame
	void Update () {
        if(startTime != 0)
        {
            Score = (int)((Time.time - startTime) * 10);

            TextMesh.text = "Score: " + Score;
        }
	}

    private void startGame()
    {
        ObstaclesMover.started = true;
        ScrollingBackground.started = true;

        startTime = Time.time;

        InvokeRepeating("increaseSpeed", 0.5f, 0.5f);
    }

    private void increaseSpeed()
    {
        Obstacles.ScrollingSpeed += 0.05f;
    }
}

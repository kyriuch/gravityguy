using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesMover : MonoBehaviour {

    public float MovingSpeed = 4f;
    public static bool started = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(started)
            transform.Translate(MovingSpeed * -1 * Time.deltaTime, 0f, 0f);

	}
}

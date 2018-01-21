using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

    public Transform[] Background;
    public SpriteRenderer[] SpriteRenderers;
    public float ScrollingSpeed = 5f;
    public float MoveDistance = 19.31f;
    public float ChangePosition = -28;

    private int firstIndex;
    private int lastIndex;

    public static bool started = false;

    // Use this for initialization
    void Start () {
        firstIndex = 0;
        lastIndex = Background.Length - 1;
	}
	
	// Update is called once per frame
	void Update () {
        if(started)
        {
            for (int i = 0; i < Background.Length; i++)
                Background[i].Translate(ScrollingSpeed * (-1) * Time.deltaTime, 0f, 0f);

            if (Background[firstIndex].position.x < ChangePosition)
            {
                Background[firstIndex].position = new Vector2(Background[lastIndex].position.x + MoveDistance, Background[lastIndex].position.y);

                if(SpriteRenderers != null && SpriteRenderers.Length > 0)
                {
                    SpriteRenderers[firstIndex].flipX = !SpriteRenderers[firstIndex].flipX;
                }

                firstIndex = (firstIndex + 1) % Background.Length;
                lastIndex = (lastIndex + 1) % Background.Length;
            }
        }
	}
}

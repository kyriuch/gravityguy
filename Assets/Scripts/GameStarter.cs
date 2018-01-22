using TMPro;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class GameStarter : MonoBehaviour {

    public ScrollingBackground Obstacles;

    public TextMeshProUGUI TextMesh;
	public TextMeshProUGUI TimerMesh;

    public static int Score = 0;


    private float startTime;

	// Use this for initialization
	void Start () {
		Sequence sequence = DOTween.Sequence();

		sequence.Append(TimerMesh.transform.DOScale(3.0f, 0.8f));
		sequence.AppendCallback(() =>
		{
			TimerMesh.rectTransform.localScale = Vector3.zero;
			TimerMesh.text = "2";
		});
		sequence.AppendInterval(0.2f);
		sequence.Append(TimerMesh.transform.DOScale(3.0f, 0.8f));
		sequence.AppendCallback(() =>
		{
			TimerMesh.rectTransform.localScale = Vector3.zero;
			TimerMesh.text = "1";
		});
		sequence.AppendInterval(0.2f);
		sequence.Append(TimerMesh.transform.DOScale(3.0f, 0.8f));
		sequence.AppendCallback(() =>
		{
			TimerMesh.rectTransform.localScale = Vector3.zero;
			TimerMesh.text = "0";
		});
		sequence.AppendInterval(0.2f);
		sequence.AppendCallback(startGame);
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
		GravityChanger.started = true;

        startTime = Time.time;

        InvokeRepeating("increaseSpeed", 0.5f, 0.5f);
    }

    private void increaseSpeed()
    {
        Obstacles.ScrollingSpeed += 0.025f;
    }
}

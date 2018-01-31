using UnityEngine;

public class ScrollingObstacles : MonoBehaviour {

	public GameObject[] obstaclesContainers;
	public float ObstaclesSpeed;
	public float ObstaclesActivatePosition;
	public float ObstaclesDeactivatePosition;
	public float ObstaclesMove;

	public static bool started = false;

	private int currentId;
	private int nextId;

	// Use this for initialization
	void Start () {
		currentId = 0;
		nextId = 1;
	}

	void FixedUpdate()
	{
		if (started)
		{
			for (int i = 0; i < obstaclesContainers.Length; i++)
			{
				obstaclesContainers[i].transform.Translate(new Vector2(-ObstaclesSpeed * Time.deltaTime, 0));
			}
		}
	}

	void Update()
	{
		if(started)
		{
			if(!obstaclesContainers[nextId].activeSelf
				&& obstaclesContainers[nextId].transform.position.x <= ObstaclesActivatePosition)
			{
				obstaclesContainers[nextId].SetActive(true);
			}

			if(obstaclesContainers[currentId].transform.position.x <= ObstaclesDeactivatePosition)
			{
				obstaclesContainers[currentId].SetActive(false);
				obstaclesContainers[currentId].transform.position = obstaclesContainers[(currentId + obstaclesContainers.Length - 1) % obstaclesContainers.Length].transform.position + new Vector3(ObstaclesMove, 0);
				currentId++;
				currentId %= obstaclesContainers.Length;
				nextId++;
				nextId %= obstaclesContainers.Length;
			}
		}
	}
	
	// Update is called once per frame
}

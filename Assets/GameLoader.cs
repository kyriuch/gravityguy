using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SceneManager.LoadScene(2, LoadSceneMode.Single);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

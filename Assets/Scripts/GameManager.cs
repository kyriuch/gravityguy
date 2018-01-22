using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public TextMeshProUGUI Score;

	public void StartGame()
    {
        ObstaclesMover.started = false;
        ScrollingBackground.started = false;
		GravityChanger.started = false;
        Physics2D.gravity = new Vector2(Physics2D.gravity.x, Mathf.Abs(Physics2D.gravity.y) * -1);
        SceneManager.LoadScene(1, LoadSceneMode.Single);

        
    }

    public void Start()
    {
        if (GameStarter.Score > 0)
        {
            Score.text = "Score: " + GameStarter.Score;
        }
        else
        {
            Score.text = "";
        }
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}

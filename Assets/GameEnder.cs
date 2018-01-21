using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnder : MonoBehaviour {

    private int playerLayer;

    void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer == playerLayer)
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}

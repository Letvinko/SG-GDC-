using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject enemy;
    public Vector2 SpawnSpot;
    public float SpawnQuee;
    public Text score_text;
    private int score;
    public Text restart_text;
    public Text gameover_text;

    private bool gameover;
    private bool restart;
   
	// Use this for initialization
	void Start () {
        score = 0;
        restart = false;
        gameover = false;
        restart_text.text="";
        gameover_text.text = "";
        StartCoroutine(SpawnEnemy());
        UpdateScore();
	}
	
	// Update is called once per frame
	void Update () {
        if (restart) {
            if (Input.GetKeyDown(KeyCode.R)) {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
		
	}


    public void Addscore() {
        score++;
        UpdateScore();
    }

    void UpdateScore() {
        score_text.text = "Score: " + score;
    }

    public void game_over() {
        gameover_text.text = "Game Over";
        gameover = true;
    }

    IEnumerator SpawnEnemy() {
        while (true) {
            Vector3 pos = new Vector3(Random.Range(-SpawnSpot.x, SpawnSpot.x), SpawnSpot.y, 0);
            Instantiate(enemy, pos, Quaternion.identity);            
            yield return new WaitForSeconds(SpawnQuee);

            if (gameover)
            {
                restart_text.text = " Press 'R' to restart";
                restart = true;
                break;
            }
        }        
    }

}

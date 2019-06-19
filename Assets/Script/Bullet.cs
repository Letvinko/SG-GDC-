using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed ;
    private Rigidbody2D rb2d;
    private GameController gc;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector2.up * speed;
        gc = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //kalo ada object yang masuk ke colider
    private void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.tag == "Enemy") {
            //menghancurkan object
            Destroy(colision.gameObject);
            Destroy(this.gameObject);
            gc.Addscore();
        }
        
    }
}

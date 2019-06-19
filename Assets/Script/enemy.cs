using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
    public float speed;
    private Rigidbody2D rb2d;
    private GameController gc;
    public GameObject explosion;
    private bool Aktif = false;
    public Transform Post;
    public GameObject peluru;
    public float firerate;
    private float nextfire;
    //public GameObject Explosion;
    //public Animator Animation;
    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        //Animation = GetComponent<Animator>();
        rb2d.velocity = Vector2.down * speed ;
        gc = GameObject.FindWithTag("GameController").GetComponent<GameController>();        
    }
	
	// Update is called once per frame
	void Update () {
        explosion.SetActive(Aktif);
        // if (true)
        //{
          //  Instantiate(peluru, Post.position, Post.rotation);
           // nextfire = Time.time + firerate;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            //Animation.SetBool("Ledakan", true);
            gc.game_over();
        } else if (collision.tag == "Bullet") {
            Aktif = true;
            explosion.SetActive(Aktif);
            GameObject exp = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(exp,0.417f);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            //DestroyImmediate(explosion, true);
        }
        
    }
}

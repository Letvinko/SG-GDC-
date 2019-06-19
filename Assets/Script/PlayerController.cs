using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    private Rigidbody2D rb2d;

    public GameObject bullet;
    public Transform shootsPost;
    public float fireRate;
    private float nextfire;
    private Animator Anim;
    public GameObject Explosion;
    public bool Aktif = false;
    //private Animator Anim2;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        //Anim2 = GetComponent<Animator>();

    }

    

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextfire) {
            Instantiate(bullet, shootsPost.position, shootsPost.rotation);
            nextfire = Time.time + fireRate;
        }
        Explosion.SetActive(Aktif);
    }

    //fixed update buat ngejaga frame konstant di setiap pc
    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 direct = new Vector2(moveX, moveY);
        rb2d.velocity = direct * speed;
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        min.x += 0.285f;
        max.x += -0.285f;

        min.y += 0.285f;
        max.y += 2f;

        Vector2 post = rb2d.position;
        post.x = Mathf.Clamp(post.x, min.x, max.x);
        post.y = Mathf.Clamp(post.y, min.y, max.y);

        rb2d.position = post;

        if (moveX < 0)
        {
            Anim.SetBool("turnleft", true);
        }
        else if (moveX == 0)
        {
            Anim.SetBool("turnleft", false);
        }

        if (moveX > 0)
        {
            Anim.SetBool("turnright", true);
        }
        else if (moveX == 0)
        {
            Anim.SetBool("turnright", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.tag == "Enemy")
        {
            Explosion.SetActive(true);
            Instantiate(Explosion, shootsPost.position, shootsPost.rotation);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            //DestroyImmediate(Explosion, true);
            //Animation.SetBool("Ledakan", true);
        }        
    }


}

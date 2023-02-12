using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ghost : MonoBehaviour
{
    private Rigidbody2D rb;

    public float JForce;

    public float moveX;

    public float moveY;

    public float Speed;

    public bool touchingdown;

    private Animator animator;

    public bool Lookright;

    private SpriteRenderer sp;

    public AudioClip item, bicho;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();


        float ScreenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = Camera.main.orthographicSize * 2;
    }


    void Update()
    {
        Movement();
        Respawn();

        RaycastHit2D kk = Physics2D.Raycast(transform.position, Vector2.down);   // Genera Raycast hacia abajo

        if(kk.distance < 1.1)     // Dectecta si toca el suelo para saltar solo si lo toca
        {
            touchingdown = true;
        }
        else
        {
            touchingdown = false;
        }

        void Movement()
        {
            // Para moverse de un lado a otro
            moveX = Input.GetAxis("Horizontal");

            rb.velocity = new Vector2(moveX * Speed, rb.velocity.y);

            //Para saltar
            if (Input.GetKeyDown(KeyCode.Space)&&touchingdown)
            {
                Jump();
            }

            // Animaci�n

            if (Mathf.Abs(moveX) > 0.1f) { animator.SetBool("isWalking", true); }
            else { animator.SetBool("isWalking", false); }
            
            //Animaci�n de salto
            if (Input.GetKey(KeyCode.Space)||!touchingdown)
            {
                animator.SetBool("isJumping", true);
            }
            else { animator.SetBool("isJumping", false);
            }

            //Direccion a la que mira el jugador
            if (moveX > 0)
            {
                sp.flipX = false;
            }
            else if (moveX < 0)
            {
                sp.flipX = true;
            }
        }

        void Jump() // Se a�ade una fuerza para poder saltar
        {
            rb.AddForce(Vector2.up * JForce);
        }

        // El Respawn
        void Respawn()
        {
            if (transform.position.y < -5.71f) 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

        }
    }

    //Detecta las colisiones
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Cuando se choca con un enemigo se reinicia la escena
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (collision.gameObject.CompareTag("Text")) // Cuando el texto cae sobre el personaje, en vez de matarlo cambia a la siguiente escena
        {
            string SceneName = "";

            if(SceneManager.GetActiveScene().name == "Level 1") { SceneName = "Level 2"; }

            else if (SceneManager.GetActiveScene().name == "Level 2") { SceneName = "Start"; }

            GameManager.instance.ChangeScene(SceneName);
        }
    }

    //Detecta los triggers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Para que muera"))
        {
            AudioManager.instance.PlayAudio(bicho); // Cuanod lo mata suena
            Destroy(collision.transform.parent.gameObject);
            rb.velocity = new Vector2(rb.velocity.x, JForce/80);
        }
        if (collision.gameObject.CompareTag("objeto"))
        {
            AudioManager.instance.PlayAudio(item); // Cuando lo toca suena 
            Destroy(collision.gameObject);

        }
    }

}

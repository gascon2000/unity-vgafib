using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Cinemachine;
using System;


public class Movimiento : MonoBehaviour
{

    [SerializeField]
    public Rigidbody2D rb;
    public float speed;
    public float height;
    private Vector2 dir;
    private bool puede_saltar;
    private float timer;
    public GameObject MENU;
    private bool paused;
    public Transform tr;




    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        dir.x = 1;
        puede_saltar = true;
        timer = 0f;
        paused = true;
        MENU.SetActive(true);
        Time.timeScale = 0;


    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {

        if (Time.timeScale == 1) paused = false;

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                puede_saltar = true;
                rb.velocity -= Vector2.up * height * dir.y;

            }
        }

        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
        //rb.velocity += Vector2.up * height * dir.y;


    }

    public void Vertical(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && puede_saltar)
        {
            dir.y = 1f;
            rb.velocity += Vector2.up * height * dir.y;
            if (rb.velocity.y > 100) rb.velocity = new Vector2(rb.velocity.x, 100f);
            timer = 0.1f;
            puede_saltar = false;
            Debug.Log("hola");
        }

        if (ctx.canceled)
        {
            // dir.y = 0f;
            puede_saltar = true;
        }
    }

    public void Down(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && puede_saltar)
        {
            dir.y = -1f;
            rb.velocity += Vector2.up * height * dir.y;
        }

        if (ctx.canceled)
        {
            rb.velocity -= Vector2.up * height * dir.y;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

        if (collision.gameObject.tag == "Finish")
        {
            //Destroy(collision.gameObject);
            //cam.Screenshake(10, 2);
        }
    }

    private void Pause()
    {
        paused = !paused;
        if (paused)
        {
            Time.timeScale = 0;
            MENU.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            MENU.SetActive(false);
        }


    }

    public void OnPause(InputAction.CallbackContext ctx)
    {
        if (ctx.performed) Pause();
    }

}

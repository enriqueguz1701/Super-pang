using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Personaje : MonoBehaviour
{
    [SerializeField] private float velocidad;
    Animator animator;
    [SerializeField] private GameObject disparo;
    [SerializeField] private Transform posicionDisparo;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        if(x != 0)
        {
            if (x > 0)
            {
                transform.localEulerAngles = new Vector2(0, 180);
            }
            else
            {
                transform.localEulerAngles = new Vector2(0, 0);
            }
            transform.Translate(Vector2.left * velocidad * Time.deltaTime);
            animator.SetBool("caminar", true);
        }
        else
        {
            animator.SetBool("caminar", false);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("disparar");
            Instantiate(disparo, posicionDisparo.position, posicionDisparo.rotation);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Pelota")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

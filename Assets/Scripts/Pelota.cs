using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    [SerializeField] int numeroBolas = 1;
    float impulso = 1f;
    Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        int x, y;
        int aleatoriox = Random.Range(0, 2);

        if(aleatoriox == 0)
        {
            x = 1;
        }
        else
        {
            x = -1;
        }
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(new Vector2(x * impulso, impulso), ForceMode2D.Impulse);
    }

    public void NuevaPelota()
    {
        numeroBolas++;
        if(numeroBolas <= 3)
        {
            for (int i = 0; i <= 1; i++)
            {
                GameObject nuevaPelota = Instantiate(gameObject, transform.position, transform.rotation);
                nuevaPelota.GetComponent<Pelota>().AsignarNumeroPelota(numeroBolas);
            }
        }
        Destroy(gameObject);
    }

    public void AsignarNumeroPelota(int numeroPelota)
    {
        numeroBolas = numeroPelota;
    }
}

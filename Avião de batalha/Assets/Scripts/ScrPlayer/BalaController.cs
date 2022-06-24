using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaController : MonoBehaviour
{
    private float scale = 1f;
    private float distance;
    [SerializeField] private Transform mouse;

    // Start is called before the first frame update
    void Start()
    {
        //Pegando a posição do mouse
        Vector3 mousePos = Input.mousePosition;

        //fazendo minha variavel ficar com a posição do mouse
        mouse.position = Camera.main.ScreenToWorldPoint(mousePos);

        //Descobrindo qual a distancia da torreta do Avião para a Mira do mouse
        distance = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(mouse.position.x, mouse.position.y));
    }
    

    // Update is called once per frame
    void Update()
    {
        //Fazendo um lerp para que ele diminua
        scale = Mathf.Lerp(scale, .80f, 0f);

        //Fazendo o scale dele diminuir, no caso o tamanho da sprite
        transform.localScale -= new Vector3(scale, scale, 0f) * Time.deltaTime;

        //Destruindo a bala caso ela tenha sumido, ou chegando na mira
        if (transform.localScale.x <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Caso bata em um Objeto ele vai se destruir
        if (collision.CompareTag("Objetos"))
        {
            Destroy(gameObject);
        }
    }
}

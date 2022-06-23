using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorretaController : PlayerController
{
    [SerializeField] private GameObject Bala;
    [SerializeField] private float velTiro = 7f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            Atirando();
        }
    }

    //Atirando só se estou visivel
    protected void Atirando()
    {
        //Atirando

        var tiro1 = Instantiate(Bala, transform.position, transform.rotation);

        //Encontrando o valor da direção que é pra ir
        //pegando a direção que é pra ir
        Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //Normalizando a velocidade dele
        dir.Normalize();

        tiro1.transform.eulerAngles = new Vector3(0f, 0f, angle);

        //Dando a direção e velocidade pro tiro
        tiro1.GetComponent<Rigidbody2D>().velocity = dir * velTiro;

        Debug.DrawRay(tiro1.transform.position, dir, Color.red, 5f);
    }
}

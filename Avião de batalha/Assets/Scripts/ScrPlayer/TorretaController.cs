using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorretaController : PlayerController
{
    [SerializeField] private GameObject Bala;
    [SerializeField] private float velTiro = 7f;

    [SerializeField] private int qtdBala = 10;
    [SerializeField] private int maxBala = 10;
    
    [SerializeField] private float timerRecarrega = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Pegando o botão de atirar, vendo se tem bala, e se ele não está recarregando
        if (Input.GetButtonDown("Fire1") && qtdBala > 0 && timerRecarrega <= 0f)
        {
            Atirando();
        }
        //Recarregando caso o timer chegue a zero, e ele não tenha balas
        if(timerRecarrega >= 0f && qtdBala <= 0)
        {
            timerRecarrega -= Time.deltaTime;

            //Colocando o maxmo de balas
            if(timerRecarrega <= 0)
            {
                qtdBala = maxBala;
            }
        }
    }

    //Atirando só se estou visivel
    protected void Atirando()
    {
        //Atirando
        qtdBala--;
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

        if(qtdBala <= 0)
        {
            Debug.Log("to sem");
            timerRecarrega = 3f;
        }
    }
}

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
    private bool recarga = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        //Pegando o bot?o de atirar, vendo se tem bala, e se ele n?o est? recarregando
        if (Input.GetButtonDown("Fire1") && qtdBala > 0 && timerRecarrega <= 0f)
        {
            Atirando();
        }

        Recarregando();
    }

    //Sistema de recarregamento
    private void Recarregando()
    {
        //Apertando R
        recarga = Input.GetKeyDown("r");

        //Vendo se acabou as balas para aumentar o timerRecarregar, ou de ele apertou R e se o tempo acabou
        if ((qtdBala <= 0 || recarga) && timerRecarrega <= 0)
        {
            timerRecarrega = 3f;
            recarga = false;

        }

        //Recarregando caso o timer chegue a zero, e ele n?o tenha balas
        if (timerRecarrega >= 0f)
        {
            timerRecarrega -= Time.deltaTime;

            //Colocando o maxmo de balas
            if (timerRecarrega <= 0)
            {
                qtdBala = maxBala;
            }
        }
    }

    //Atirando s? se estou visivel
    protected void Atirando()
    {
        qtdBala--;
        //Criando a Bala
        var tiro1 = Instantiate(Bala, transform.position, transform.rotation);

        //Encontrando o valor da dire??o que ? pra ir
        //pegando a dire??o que ? pra ir
        Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //Normalizando a velocidade dele
        dir.Normalize();

        tiro1.transform.eulerAngles = new Vector3(0f, 0f, angle);

        //Dando a dire??o e velocidade pro tiro
        tiro1.GetComponent<Rigidbody2D>().velocity = dir * velTiro;
    }
}

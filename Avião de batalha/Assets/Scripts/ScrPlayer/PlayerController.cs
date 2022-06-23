using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D meuRB;

    [SerializeField] private float vel = 3f;
    [SerializeField] private float velTiro = 7f;
    [SerializeField] private GameObject Bala;

    // Start is called before the first frame update
    void Start()
    {
        //pegando o RB
        meuRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movendo();
    }

    private void Movendo()
    {

        //ao apertar a tecla de movimento horizontal fo Input Maneger, ele se movera
        var moviH = Input.GetAxis("Horizontal") * vel;
        var moviV = Input.GetAxis("Vertical") * vel;

        //Aplicando a velocidade horizontal a aou meuRB
        meuRB.velocity = new Vector2(moviH, moviV);

        //Alterando animação de parado para movendo
        if (moviH != 0)
        {
            //Alterando a imagem para que ele olhe para o lado em que está indo
            meuRB.transform.localScale = new Vector3(Mathf.Sign(moviH), meuRB.transform.localScale.y, meuRB.transform.localScale.z);
        }


    }
    //Atirando só se estou visivel
    protected void Atirando()
    {
        
        //Atirando
            
        var tiro1 = Instantiate(Bala, transform.position, transform.rotation);

        //Encontrando o valor da direção que é pra ir
        //pegando a direção que é pra ir
        Vector2  dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //Normalizando a velocidade dele
        dir.Normalize();

        tiro1.transform.eulerAngles = new Vector3(0f, 0f, angle);

        //Dando a direção e velocidade pro tiro
        tiro1.GetComponent<Rigidbody2D>().velocity = dir * velTiro;

        Debug.DrawRay(tiro1.transform.position, dir, Color.red, 5f);
    }
}

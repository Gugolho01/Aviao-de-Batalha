using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D meuRB;
    protected float distance;
    [SerializeField] private float vel = 7f;
    [SerializeField] private Transform mouseObj;
    protected float balaScale = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //pegando o RB
        meuRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Calculando a distancia
        distance = Vector3.Distance(transform.position, mouseObj.transform.position);
        distance -= 9.5f;

        if(distance > 5f)
        {
            balaScale = 0.001f;
        } else if (distance > 3f)
        {
            balaScale = 0.01f;
        } else if (distance < 3f)
        {
            balaScale = .1f;
        }

        Debug.Log(distance);

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
}

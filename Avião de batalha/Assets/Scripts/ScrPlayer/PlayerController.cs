using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D meuRB;

    [SerializeField] private float velH = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //pegando o RB
        meuRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var 
    }
}

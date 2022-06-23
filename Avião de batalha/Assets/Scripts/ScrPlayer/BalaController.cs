using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaController : TorretaController
{
    

    private float scale = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 minScale = new Vector3(balaScale, balaScale, 0f);

        transform.localScale -= new Vector3(balaScale, balaScale, 0f);

        //Destruindo a bala caso ela tenha sumido
        if(transform.localScale.x <= 0.2)
        {
            Destroy(gameObject);
            Debug.Log("destui");
        }
    }
}

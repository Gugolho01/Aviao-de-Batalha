using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiraController : MonoBehaviour
{
    
    [SerializeField] private Transform pointer;
    [SerializeField] protected Transform mouse;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        LocalMouse();
    }

    private void LocalMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0.5f;

        pointer.position = Camera.main.ScreenToWorldPoint(mousePos);
        mouse.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
}

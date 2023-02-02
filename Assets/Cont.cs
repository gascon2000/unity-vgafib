using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cont : MonoBehaviour
{
    public TMP_Text contador;
    public Transform tr;
    private Vector3 pos;
    private int pos_x;


    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        contador = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        pos = tr.position;
        pos_x = (int)pos.x;
        pos_x -= 13;
        pos_x %= 10000;
        contador.text = pos_x.ToString() + "m";
    }
}

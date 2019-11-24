using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePedestrian : MonoBehaviour
{
    public GameObject objPedestrian1;
    public GameObject objPedestrian2;

    private bool bMovePedestrian1 = false;
    private bool bMovePedestrian2 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bMovePedestrian1)
        {
            objPedestrian1.transform.Translate(2 * Time.deltaTime, 0, 0);
        }
        if(bMovePedestrian2)
        {
            objPedestrian2.transform.Translate(2 * Time.deltaTime, 0, 0);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name == "Cube")
        {
            bMovePedestrian1 = true;
        }
        if(collision.gameObject.name == "Cube (1)")
        {
            bMovePedestrian2 = true;
        }
    }
}

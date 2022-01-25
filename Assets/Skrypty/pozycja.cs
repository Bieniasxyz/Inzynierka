using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pozycja : MonoBehaviour
{
    public GameObject pojazd;
    
    void Start()
    {
        transform.position = pojazd.transform.position;
        GetComponent<BoxCollider>().center = pojazd.GetComponent<BoxCollider>().center;
        GetComponent<BoxCollider>().size = pojazd.GetComponent<BoxCollider>().size;
    }
    void Update()
    {
        transform.position = pojazd.transform.position;
        GetComponent<BoxCollider>().center = pojazd.GetComponent<BoxCollider>().center;
        GetComponent<BoxCollider>().size = pojazd.GetComponent<BoxCollider>().size;
    }
}

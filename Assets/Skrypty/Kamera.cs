using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    public GameObject ObiektGry;
    public Vector3 offset;
    void Update()
    {
        transform.position = ObiektGry.transform.position + offset;
    }
}

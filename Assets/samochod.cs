﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class samochod : MonoBehaviour
{
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKey(KeyCode.W))
        {
            rigidbody.AddRelativeForce(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidbody.AddRelativeForce(Vector3.back);
        }
    }
}

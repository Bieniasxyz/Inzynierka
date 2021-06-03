using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Samochod : MonoBehaviour
{
    Rigidbody rigidbody;
    List<KeyValuePair<float, float>> trasa;
    float mnoznikLewo = -0.2f;
    float mnoznikPrawo = 0.2f;
    float mnoznikPrzod = 10f;
    float mnoznikTyl = 6f;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        trasa = new List<KeyValuePair<float, float>>();
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * mnoznikPrzod);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime* mnoznikTyl);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //.Translate(Vector3.left * Time.deltaTime * mnoznikLewo);
            transform.Rotate(new Vector3(0, mnoznikLewo, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            //transform.Translate(Vector3.right * Time.deltaTime * mnoznikPrawo);
            transform.Rotate(new Vector3(0, mnoznikPrawo, 0));
        }
        if (Input.GetKey(KeyCode.T))
        {
            WyswietlTrase();
        }
        ZapiszTrase();
        
    }
    /*
    private double ObliczaCzasNaciskaniaKlawisza()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                poczatek = DateTime.Now;
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                koniec = DateTime.Now;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.A))
            {
                poczatek = DateTime.Now;
            }
            if (Input.GetKey(KeyCode.A))
            {
                koniec = DateTime.Now;
            }
        }
        roznica = koniec - poczatek;
        //koniec = 0;
        //poczatek = 0;
        //roznica = roznica.TotalSeconds;
        return Convert.ToDouble(roznica.Milliseconds.ToString());
       
    }
    */
    public void Przyspieszenie(double wartosc, bool doPrzodu = true)
    {
        if (doPrzodu == true)
        {
            if (wartosc == 0 || wartosc < 0)
            {
                mnoznikPrzod = 0f;
            }
            else if (wartosc > 0 && wartosc < 1)
            {
                mnoznikPrzod = 2f;
            }
            else if (wartosc > 1 && wartosc < 3)
            {
                mnoznikPrzod = 4f;
            }
            else if (wartosc > 3 && wartosc < 5)
            {
                mnoznikPrzod = 6f;
            }
            else
            {
                mnoznikPrzod = 8f;
            }
        }
        else
        {
            if (wartosc == 0 || wartosc < 0)
            {
                mnoznikTyl = 0f;
            }
            else if (wartosc > 0 && wartosc < 1)
            {
                mnoznikTyl = 2f;
            }
            else if (wartosc > 1 && wartosc < 3)
            {
                mnoznikTyl = 4f;
            }
            else if (wartosc > 3 && wartosc < 5)
            {
                mnoznikTyl = 6f;
            }
            else
            {
                mnoznikTyl = 8f;
            }
        }
    }
    private void ZapiszTrase()
    {
        float x, y;
        x = transform.position.x;
        y = transform.position.y;
        //x = GameObject.Find("Samochod").transform.position.x;
       // y = GameObject.Find("Samochod").transform.position.y;
        KeyValuePair<float, float> sprawdzenie = new KeyValuePair<float, float>();
        sprawdzenie = new KeyValuePair<float, float>(x, y);
        if (trasa.Count == 0)
        {
            trasa.Add(sprawdzenie);
        }
        else
        {
            if (!trasa[trasa.Count - 1].Equals(sprawdzenie))
            {
                trasa.Add(sprawdzenie);
            }
        }
        
        
    }
    private void WyswietlTrase()
    {
        foreach (var item in trasa)
        {
            Debug.Log("x to" + item.Key + " y to: " + item.Value);
        }
        //Debug.Log("Wilkosc Tablicy to: " + trasa.Count);
    }
}

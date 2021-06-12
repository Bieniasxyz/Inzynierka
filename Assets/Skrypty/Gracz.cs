using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gracz : MonoBehaviour
{
    [SerializeField]
    private float PunktyZycia;
    [SerializeField]
    private float MnoznikPoziomu;
    private bool GraczZyje;
    private float MaksimumZniszczen;
    private float AktualneZniszczenia;
    private float MnoznikZniszczen;
    List<KeyValuePair<float, float>> trasa;
    
    float mnoznikLewo = 50f;
    float mnoznikPrawo = 50f;
    float mnoznikPrzod = 10f;
    float mnoznikTyl = 6f;

    public void Start()
    {
        PoczatkoweWartosciZmiennych();
        trasa = new List<KeyValuePair<float, float>>();
        //transform.position 
    }
    public float PodajPunktyZycia()
    {
        return PunktyZycia;
    }

    private void PoczatkoweWartosciZmiennych()
    {
        PunktyZycia = 100f;
        MnoznikPoziomu = 1f;
        GraczZyje = true;
        MaksimumZniszczen = 100f;
        AktualneZniszczenia = 0f;
        MnoznikZniszczen = 1f;
    }
    void Update()
    {
        PoruszanieSie();
    }

    private void ZmniejszPunktyZycia()
    {
        if (PunktyZycia > 0)
        {
            PunktyZycia -= LosujPunktyZniszczen(); ;
        }
        else
        {
            GraczZyje = false;
        }
    }
    private void ZapisProfilGracza(string nazwa)
    {
        PlayerPrefs.SetString("NazwaGracza", nazwa);
        PlayerPrefs.Save();
    }
    private string OdczytDanychGracza()
    {
        string NazwaGracza = PlayerPrefs.GetString("NazwaGracza");
        return NazwaGracza;
    }
    private void Smierc()
    {
        GraczZyje = false;
        throw new NotImplementedException();
    }
    private void ZwiekszPunktyZniszczen(float punkty)
    {
        if (punkty > (MaksimumZniszczen - AktualneZniszczenia))
        {
            Smierc();
        }
        else
        {
            AktualneZniszczenia -= punkty;
        }
    }
    private float IlePunktowZniszczen(byte TypZniszczen)
    {
        switch (TypZniszczen)
        {
            case 1: //Pojazdy
                MnoznikZniszczen = 2f;
                break;
            case 2: //Budynki
                MnoznikZniszczen = 3f;
                break;
            case 3: //Osoby
                MnoznikZniszczen = 10f;
                break;
            default:
                MnoznikZniszczen = 1f;
                break;
        }

        return (LosujPunktyZniszczen() * MnoznikZniszczen);
    }
    private float LosujPunktyZniszczen ()
    {
        return UnityEngine.Random.Range(1f, 3f);
    }
    private void ZapiszTrase()
    {
        float x, y;
        x = transform.position.x;
        y = transform.position.y;
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
    }
    void OnTriggerEnter(Collider enter)
    {
        ZmniejszPunktyZycia();
    }
    void PoruszanieSie()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0,1,0) * Time.deltaTime * mnoznikPrzod);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * mnoznikTyl);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(1,0,0) * mnoznikLewo * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(-1, 0, 0) * mnoznikPrawo * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.T))
        {
            WyswietlTrase();
        }
        ZapiszTrase();
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gracz : MonoBehaviour
{
    [SerializeField]
    private float PunktyZycia, PunktyZniszczenBudynkow;
    private float LimitZniszczen;

    private bool GraczZyje;

    private float MaksimumZniszczen;
    private float AktualneZniszczenia;

    List<KeyValuePair<float, float>> trasa;
    
    float mnoznikLewo = 50f;
    float mnoznikPrawo = 50f;
    float mnoznikPrzod = 10f;
    float mnoznikTyl = 6f;

    float Wynik = 0;

    ZarzadzanieScenami sceny;

    public GameObject czasGry;
    CzasGry czasomierz;

    public void Start()
    {
        PoczatkoweWartosciZmiennych();
        trasa = new List<KeyValuePair<float, float>>();
        czasomierz = czasGry.GetComponent<CzasGry>();
    }
    public float PodajPunktyZycia()
    {
        return PunktyZycia;
    }

    private void PoczatkoweWartosciZmiennych()
    {
        PunktyZycia = 100f;
        GraczZyje = true;
        MaksimumZniszczen = 100f;
        AktualneZniszczenia = 0f;
        LimitZniszczen = UnityEngine.Random.Range(0.1f, 4f) * 100;
    }
    void Update()
    {
        PoruszanieSie();
        CzyNastapilaSmierc();
        ObliczWynikGracza();
        Debug.Log(Wynik);
    }

    private void CzyNastapilaSmierc()
    {
        if(GraczZyje == true)
        {
            if (PunktyZycia == 0 || PunktyZycia < 0)
            {
                GraczZyje = false;
            }
            if (PunktyZniszczenBudynkow >= LimitZniszczen)
            {
                GraczZyje = false;
            }
        }
        else
        {
            Smierc();
        }
    }
    private void ObliczWynikGracza()
    {
        float zniszczenia;
        

        zniszczenia = (float)((0.75 * AktualneZniszczenia) + (0.25 * PunktyZniszczenBudynkow));
        Wynik = (float)((0.5 * czasomierz.CzasRozgrywki) * 100 - (0.5 * zniszczenia));
    }
    private void ZmniejszPunktyZycia()
    {
        if (PunktyZycia > 0)
        {
            PunktyZycia -= LosujPunktyZniszczen();
            
        }
        else
        {
            GraczZyje = false;
        }
    }

    private void Smierc()
    {
        GraczZyje = false;
        sceny = gameObject.GetComponentInParent<ZarzadzanieScenami>();
        Debug.Log(sceny);
        sceny.Smierc();
   
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
    private float LosujPunktyZniszczen ()
    {
        return UnityEngine.Random.Range(10f, 21f);
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
        if (enter.tag == "Cel")
        {
            
        }
        else
        {
            ZmniejszPunktyZycia();
            PowiekszPunktyZniszczen();
        }
        
    }
        private void PowiekszPunktyZniszczen()
    {
        PunktyZniszczenBudynkow += UnityEngine.Random.Range(0f, 3f);
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
    public float PodajAktualneZniszczenia()
    {
        return AktualneZniszczenia;
    }
}
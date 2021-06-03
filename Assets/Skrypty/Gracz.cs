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
    
    void Start()
    {
        PoczatkoweWartosciZmiennych();
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
        
    }

    private void ZmniejszPunktyZycia()
    {
        if (PunktyZycia > 0)
        {
            PunktyZycia--;
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
        return UnityEngine.Random.Range(0.1f, 1f);
    }
}

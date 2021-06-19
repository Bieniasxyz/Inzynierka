using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class TablicaWynikow : MonoBehaviour
{
    public float[] wyniki;
    public string[] daty;
    
    void OdczytajWyniki()
    {
        for (int i = 0; i < 10; i++)
        {
           wyniki[i] = PlayerPrefs.GetFloat("Wynik_" + i);
           daty[i] = PlayerPrefs.GetString("Data_" + i); 
        }
        
    }
    void ZapiszWyniki(int indeks, float wynik)
    {

        PlayerPrefs.SetFloat("Wynik_" + indeks, wynik);

        DateTime biezacadata = DateTime.Now;

        string tmp = String.Concat(biezacadata.Year, "-", biezacadata.Month, "-", biezacadata.Day, " ", biezacadata.Hour, ":", biezacadata.Minute);

        PlayerPrefs.SetString("Data_" + indeks, tmp);

    }
    void SprawdzCzyWiekszyNizNaLiscie(float wynik)
    {
        float minimum = float.MaxValue;
        int numerindeksu = 0;
        for (int i = 0; i < 10; i++)
        {
            if (wyniki[i] < minimum)
            {
                minimum = wyniki[i];
                numerindeksu = i;
            }
        }
        if (wynik > minimum)
        {
            wyniki[numerindeksu] = wynik;
        }
    }
    private void Start()
    {
        wyniki = new float[10];
        daty = new string[10];
        OdczytajWyniki();
    }
}
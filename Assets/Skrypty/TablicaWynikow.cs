using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class TablicaWynikow : MonoBehaviour
{
    private float[] wyniki;
    private string[] daty;
    public Text[] WynikText, DatyText;
    void Start()
    {
        wyniki = new float[10];
        daty = new string[10];
        OdczytajWyniki();
        if(this.tag != "WynikGry")
        {
            WyswietlWyniki();
        }
    }
    void OdczytajWyniki()
    {
        SortedList<float, string> lista = new SortedList<float, string>();
        float tmp1;
        string tmp2;
        for (int i = 0; i < 10; i++)
        {
            tmp1 = PlayerPrefs.GetFloat("Wynik_" + i);
            tmp2 = PlayerPrefs.GetString("Data_" + i);

            if (i > 0)
            {
                if (tmp1 == wyniki[i-1])
                {
                    tmp1 -= i;
                }
            }
            lista.Add(tmp1, tmp2);   
        }
        int j = 0;
        var listaDoSortowania = from wybor in lista orderby wybor.Key descending select wybor;
        foreach (var item in listaDoSortowania)
        {
            wyniki[j] = item.Key;
            daty[j] = item.Value;
            j++;
        }
        ZapiszWynikiPosortowane();
    }
    void ZapiszWynikiPosortowane()
    {
        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.SetFloat("Wynik_" + i, wyniki[i]);
            PlayerPrefs.SetString("Data_" + i, daty[i]);
        }
    }
    void WyswietlWyniki()
    {
        for (int i = 0; i < 10; i++)
        { 
            if (wyniki[i] == default)
            {
                WynikText[i].text = "Brak wyniku";
            }
            else
            {
                WynikText[i].text = wyniki[i].ToString();
            }

            if (daty[i] == "Data" || daty[i] =="")
            {
                DatyText[i].text = "Brak wyniku";
            }
            else
            {
                DatyText[i].text = daty[i].ToString();
            }  
        }  
    }
    void ZapiszWynik(int indeks, float wynik)
    {

        PlayerPrefs.SetFloat("Wynik_" + indeks, wynik);

        DateTime biezacadata = DateTime.Now;

        string tmp = String.Concat(biezacadata.Year, "-", biezacadata.Month, "-", biezacadata.Day, " ", biezacadata.Hour, ":", biezacadata.Minute);

        PlayerPrefs.SetString("Data_" + indeks, tmp);

    }
    public void SprawdzWynik(float wynik)
    {
        
        if (wynik > wyniki[9])
        {
            PlayerPrefs.SetFloat("Wynik_9", wynik);
            DateTime biezacadata = DateTime.Now;
            string tmp = String.Concat(biezacadata.Year, "-", biezacadata.Month, "-", biezacadata.Day, " ", biezacadata.Hour, ":", biezacadata.Minute);
            PlayerPrefs.SetString("Data_9", tmp);
        }
    }
}
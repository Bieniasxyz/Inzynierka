using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CelMisji : MonoBehaviour
{
    private string Opis;
    private string CelSzczegolowy;
    private List<KeyValuePair<string, string>> teksty;
    private void Start()
    {
        teksty = new List<KeyValuePair<string, string>>();
        teksty.Add(new KeyValuePair<string, string>("Wstep", "Wprowadzenie do zadania"));
        teksty.Add(new KeyValuePair<string, string>("Pozar", "Nastąpił pożar"));
        teksty.Add(new KeyValuePair<string, string>("Wypadek", "Nastąpił wypadek"));
        teksty.Add(new KeyValuePair<string, string>("NieznanaPrzyczyna", "Przyczyna nie jest aktualnie znana"));
        teksty.Add(new KeyValuePair<string, string>("ŁatwopalnaPrzyczyna", "Przyczyną jest zapalenie się obiektów łatwopalnych"));
        teksty.Add(new KeyValuePair<string, string>("ŁatwopalnaPrzyczyna", "Przyczyną jest ulatniający się gaz"));
        teksty.Add(new KeyValuePair<string, string>("GazPrzyczyna", "Przyczyną jest ulatniający się gaz"));
        teksty.Add(new KeyValuePair<string, string>("PrądPrzyczyna", "Przyczyną jest ulatniający się gaz"));
        teksty.Add(new KeyValuePair<string, string>("Zadanie", "Twoim zadaniem jest"));
        teksty.Add(new KeyValuePair<string, string>("UgasićPożar", "Ugaasić pożar"));
        teksty.Add(new KeyValuePair<string, string>("PrądPrzyczyna", "Przyczyną jest ulatniający się gaz"));




        /*
        typZdarzenia.Add("Pozar");
        typZdarzenia.Add("Wypadek");
        pozarZdarzenia.Add("Ewakuacja");
        pozarZdarzenia.Add("Zabezpieczenie");
        pozarZdarzenia.Add("Pozar_Ogien");
        pozarZdarzenia.Add("Pozar_Latwopalny");
        pozarZdarzenia.Add("Pozar_Gaz");
        pozarZdarzenia.Add("Pozar_Prad");
        wypadekZdarzenia.Add("Zabezpieczenie");
        wypadekZdarzenia.Add("Ewakuacja");
        */
    }
    public string PodajTekst(string key)
    {
        var wartosc = teksty.Find(x => x.Key == key);
        return wartosc.Value;
    }
    private void Update()
    {
        //Debug.Log(PodajTekst("Wypadek"));
    }

}

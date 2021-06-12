using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStop : MonoBehaviour
{
    private GameObject[] listaStartowa;
    private GameObject[] listaKoncowa;
    public GameObject Poczatek, Cel;
    private List<string> typZdarzenia;
    private List<string> pozarZdarzenia;
    private List<string> wypadekZdarzenia;
    public string typAkcji, typSzczegolowy;

    void Start()
    {
        listaStartowa = GameObject.FindGameObjectsWithTag("Poczatek");
        listaKoncowa = GameObject.FindGameObjectsWithTag("Koniec");
        Poczatek = Losuj(listaStartowa);
        SprawdzPunktPoczatekKoniec();
        this.transform.position = Poczatek.transform.position;
        typZdarzenia = new List<string>();
        pozarZdarzenia = new List<string>();
        wypadekZdarzenia = new List<string>();
        DodajTypyZdarzenia();
        LosujTypZdarzenia();
    }

    private void SprawdzPunktPoczatekKoniec()
    {
        do
        {
          Cel = Losuj(listaKoncowa);
        } while (Poczatek == Cel);
    }

    private GameObject Losuj(GameObject[] listaObiektow)
    {
        int los = Random.Range(0, (listaObiektow.Length - 1));
        return listaObiektow[los];
    }
    private void DodajTypyZdarzenia()
    {        
        typZdarzenia.Add("Pozar");
        typZdarzenia.Add("Wypadek");
        pozarZdarzenia.Add("Ewakuacja");
        pozarZdarzenia.Add("Zabezpieczenie");
        pozarZdarzenia.Add("Pozar_Ogien");
        pozarZdarzenia.Add("Pozar_Latwopalny");
        pozarZdarzenia.Add("Pozar_Gaz");
        pozarZdarzenia.Add("Pozar_Prad");
        wypadekZdarzenia.Add("Zabezpieczenie");
        wypadekZdarzenia.Add("ZabezpieczenieMiejsca");
    }
    private void LosujTypZdarzenia()
    {
        int tmp;
        tmp = UnityEngine.Random.Range(0, typZdarzenia.Count);
        typAkcji = typZdarzenia[tmp];
        if (typAkcji == "Pozar")
        {
            tmp = UnityEngine.Random.Range(0, pozarZdarzenia.Count);
            typSzczegolowy = pozarZdarzenia[tmp];
        }
        if (typAkcji == "Wypadek")
        {
            tmp = UnityEngine.Random.Range(0, wypadekZdarzenia.Count);
            typSzczegolowy = wypadekZdarzenia[tmp];
        }
    }

}

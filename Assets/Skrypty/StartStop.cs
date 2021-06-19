using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStop : MonoBehaviour
{
    public GameObject[] listaStartowa;
    public GameObject[] listaKoncowa;
    public GameObject Poczatek, Cel;

    private List<string> typZdarzenia;
    private List<string> pozarZdarzenia;
    private List<string> wypadekZdarzenia;

    public bool[] celOsiagniety;
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
        celOsiagniety = new bool[6];
        for (int i = 0; i < celOsiagniety.Length; i++)
        {
            celOsiagniety[i] = false;
        }
    }

    private void SprawdzPunktPoczatekKoniec()
    {
        do
        {
          Cel = Losuj(listaKoncowa);
        } while (Poczatek == Cel);
        Cel.tag = "Cel";
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
        wypadekZdarzenia.Add("Ewakuacja");
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
    private void ZastosujTypAkcji()
    {
        if (typAkcji == "Pozar")
        {
            switch (typSzczegolowy)
            {
                case "Ewakuacja":
                    if (celOsiagniety[0] == true && celOsiagniety[1] == false)
                    {
                        Cel.transform.position = GameObject.Find("Ewakuacja").transform.position;
                    }                
                    break;
                default:
                    break;
            }
        }
    }

}

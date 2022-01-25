using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartStop : MonoBehaviour
{
    public GameObject[] listaStartowa;
    public GameObject[] listaKoncowa;
    public GameObject Poczatek, Cel, BazaStartowa, BazaKoncowa;

    private List<string> typZdarzenia;
    private List<string> pozarZdarzenia;
    private List<string> wypadekZdarzenia;

    public bool[] celOsiagniety;
    public string typAkcji, typSzczegolowy;

    public GameObject MenuWprowadzenie;
    public GameObject MenuZwyciestwo;

    private Gracz gracz;

    public ParticleSystem ogien;

    public GameObject TablicaWynikowGO;
    private TablicaWynikow tablica;

    public GameObject Samochod;

    void Start()
    {
        Time.timeScale = 0f;
        listaStartowa = GameObject.FindGameObjectsWithTag("Poczatek");
        listaKoncowa = GameObject.FindGameObjectsWithTag("Koniec");

        Poczatek = Losuj(listaStartowa);
        SprawdzPunktPoczatekKoniec();
        this.transform.position = Poczatek.transform.position;
        typZdarzenia = new List<string>();
        pozarZdarzenia = new List<string>();
        wypadekZdarzenia = new List<string>();
        BazaStartowa.transform.position = Poczatek.transform.position;
        BazaKoncowa.transform.position = Cel.transform.position;
        BazaKoncowa.transform.position = new Vector3(BazaKoncowa.transform.position.x, 0.005f, BazaKoncowa.transform.position.z);
        BazaKoncowa.tag = "Cel";

        DodajTypyZdarzenia();
        LosujTypZdarzenia();

        celOsiagniety = new bool[2];
        for (int i = 0; i < celOsiagniety.Length; i++)
        {
            celOsiagniety[i] = false;
        }
        MenuWprowadzenie.SetActive(true);
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
        if (typAkcji == "Pozar")
        {
            ogien.transform.position = Cel.transform.position;
            ogien.Play();
        }
    }
    private void ZastosujTypAkcji()
    {
        if (typAkcji == "Pozar")
        {
            TypSzczegolowyDzialanie();
        }
        if (typAkcji == "Wypadek")
        {
            TypSzczegolowyDzialanie();
        }
    }
    private void TypSzczegolowyDzialanie()
    {
        switch (typSzczegolowy)
        {
            case "Ewakuacja":
                if (celOsiagniety[0] == false && celOsiagniety[1] == false)
                {
                    ZmianaCelu("Ewakuacja");
                }
                break;
            case "Zabezpieczenie":
                if (celOsiagniety[0] == true && celOsiagniety[1] == false)
                {
                    ZmianaCelu("Zabezpieczenie");
                }
                break;
            case "Pozar_Ogien":
                DzialanieWPozarze();
                break;
            case "Pozar_Gaz":
                DzialanieWPozarze();
                break;
            case "Pozar_Prad":
                DzialanieWPozarze();
                break;
            default:
                
                break;
        }
    }
    private void DzialanieWPozarze()
    {
        celOsiagniety[0] = true;
        celOsiagniety[1] = true;
        Zwyciestwo();
        ogien.Stop();
    }
    private void ZmianaCelu(string typAkcji)
    {
        Cel.tag = "Koniec";
        Cel.transform.position = GameObject.Find(typAkcji).transform.position;
        BazaKoncowa.tag = "Untagged";
        
        BazaKoncowa.transform.position = Cel.transform.position;
        BazaKoncowa.tag = "Cel";
        Cel.tag = "Cel";
    }
    public void OnTriggerEnter(Collider enter)
    {

        if (enter.tag == "Cel")
        {
            if (celOsiagniety[0] == false)
            {
                celOsiagniety[0] = true;
                ZastosujTypAkcji();
                
            }
            else
            {
                celOsiagniety[1] = true;
                Zwyciestwo();
            }            
        }  
    }
    public void WywolajKolizje(Collider enter)
    {
        OnTriggerEnter(enter);
    }
    private void Zwyciestwo()
    {
        Time.timeScale = 0f;
        gracz = Samochod.GetComponent<Gracz>();
        MenuZwyciestwo.SetActive(true);
        MenuZwyciestwo.GetComponentInChildren<Text>().text = gracz.Wynik.ToString();
        tablica = TablicaWynikowGO.GetComponentInChildren<TablicaWynikow>();
        tablica.SprawdzWynik(gracz.Wynik);
    }
    public void ZmienCelMisji(Transform pozycja)
    {
        Cel.transform.position = pozycja.position;
    }
    public string PodajTypAkcji()
    {
        return typAkcji;
    }
    public string PodajTypSzczegolowy()
    {
        return typSzczegolowy;
    }
}

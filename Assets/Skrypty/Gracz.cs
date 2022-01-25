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

    readonly float mnoznikLewo = 50f;
    readonly float mnoznikPrawo = 50f;
    readonly float mnoznikPrzod = 10f;
    readonly float mnoznikTyl = 6f;

    public float Wynik;
    public float zniszczenia;

    ZarzadzanieScenami sceny;

    public GameObject czasGry;
    CzasGry czasomierz;

    public GameObject obiekt;
    StartStop skrypt;

    public void Start()
    {
        PoczatkoweWartosciZmiennych();
        trasa = new List<KeyValuePair<float, float>>();
        czasomierz = czasGry.GetComponent<CzasGry>();
        skrypt = obiekt.GetComponent<StartStop>();
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
        PunktyZniszczenBudynkow = 0f;
        Wynik = 0;
        LimitZniszczen = UnityEngine.Random.Range(0.1f, 4f) * 100;
    }
    void Update()
    {
        PoruszanieSie();
        CzyNastapilaSmierc();
        ObliczWynikGracza();
    }
    private void CzyNastapilaSmierc()
    {
        if (GraczZyje == true)
        {
            if (PunktyZycia == 0 || PunktyZycia < 0)
            {
                GraczZyje = false;
            }
            if (PunktyZniszczenBudynkow >= LimitZniszczen)
            {
                GraczZyje = false;
            }
            if (czasomierz.PozostalyCzas == 0 || czasomierz.PozostalyCzas < 0)
            {
                GraczZyje = false;
            }
        }
        else
        {
            Smierc();
        }
    }
    public void ObliczWynikGracza()
    {
        zniszczenia = (float)((0.75 * AktualneZniszczenia) + (0.25 * PunktyZniszczenBudynkow));
        Wynik = (float)(((0.5 * czasomierz.PozostalyCzas) * 10) - (0.5 * zniszczenia));
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
    private float LosujPunktyZniszczen()
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
    void OnTriggerEnter(Collider enter)
    {
        if (enter.CompareTag("Cel") == false)
        {
            ZmniejszPunktyZycia();
            PowiekszPunktyZniszczen();
        }
        skrypt.WywolajKolizje(enter);

    }
    private void PowiekszPunktyZniszczen()
    {
        PunktyZniszczenBudynkow += UnityEngine.Random.Range(0f, 3f);
    }
    void PoruszanieSie()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(mnoznikPrzod * Time.deltaTime * new Vector3(0, 0, -1));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(mnoznikTyl * Time.deltaTime * new Vector3(0, 0, 1));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(mnoznikLewo * Time.deltaTime * new Vector3(0, -1, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(mnoznikPrawo * Time.deltaTime * new Vector3(0, 1, 0));
        }
        ZapiszTrase();
    }
    public float PodajAktualneZniszczenia()
    {
        return AktualneZniszczenia;
    }
}
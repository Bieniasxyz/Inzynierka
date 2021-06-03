using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CzasGry : MonoBehaviour
{
    [SerializeField]
    private float CzasRozgrywki;
    [SerializeField]
    private float PozostalyCzas;
    [SerializeField]
    private float CzasPoziomu;
    private bool LicznikCzasuJestAktywny = true;
    public Text WyswietlaczCzasu;
    void Start()
    {
        PoczatkoweWartosciZmiennych();
    }

    private void PoczatkoweWartosciZmiennych()
    {
        CzasRozgrywki = 0f;
        CzasPoziomu = 100f;
        PozostalyCzas = CzasPoziomu - CzasRozgrywki;
    }

    // Update is called once per frame
    void Update()
    {
        if (LicznikCzasuJestAktywny == true)
        {
            
            if (PozostalyCzas == 0 || PozostalyCzas < 0)
            {
                //Smierc();
            }
            else
            {
                LicznikCzasu();
            }
        }
    }
    private void LicznikCzasu()
    {
        CzasRozgrywki += Time.deltaTime;
        PozostalyCzas = CzasPoziomu - CzasRozgrywki;
        float Minuty = Mathf.FloorToInt(PozostalyCzas / 60);
        float Sekundy = Mathf.FloorToInt(PozostalyCzas % 60);
        WyswietlaczCzasu = gameObject.GetComponent<Text>();
        
        string tekst = string.Format("{0:00}:{1:00}", Minuty, Sekundy);
        WyswietlaczCzasu.text = tekst;
        Debug.Log(tekst);
    }
}

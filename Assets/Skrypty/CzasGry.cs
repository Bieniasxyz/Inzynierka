using UnityEngine;
using UnityEngine.UI;

public class CzasGry : MonoBehaviour
{
    [SerializeField]
    public float CzasRozgrywki;
    [SerializeField]
    public float PozostalyCzas;
    [SerializeField]
    private float CzasPoziomu;
    private bool LicznikCzasuJestAktywny = true;
    public Text WyswietlaczCzasu, LicznikZniszczen;
    float minuty, sekundy;
    void Start()
    {
        PoczatkoweWartosciZmiennych();
    }

    private void PoczatkoweWartosciZmiennych()
    {
        CzasRozgrywki = 0f;
        CzasPoziomu = 100f;
        PozostalyCzas = CzasPoziomu - CzasRozgrywki;
        WyswietlaczCzasu = gameObject.GetComponentInChildren<Text>();
    }
    void Update()
    {
        if (LicznikCzasuJestAktywny == true)
        {
            
            if (PozostalyCzas == 0 || PozostalyCzas < 0)
            {
                LicznikCzasuJestAktywny = false;
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
        minuty = Mathf.FloorToInt(PozostalyCzas / 60);
        sekundy = Mathf.FloorToInt(PozostalyCzas % 60);
        WyswietlCzas();
    }
    private void WyswietlCzas()
    {
        string tekst = string.Format("{0:00}:{1:00}", minuty, sekundy);
        WyswietlaczCzasu.text = tekst;
    }
}

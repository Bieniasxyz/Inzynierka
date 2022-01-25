using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CelMisji : MonoBehaviour
{
    private List<KeyValuePair<string, string>> teksty;
    public GameObject gracz;
    public GameObject PojazdRatunkowy;
    public GameObject MenuWprowadzenie;
    public GameObject KomunikatBleduWyboruSprzetu;
    public StartStop startStop;
    public GameObject WyborSprzetu;
    public Toggle GasnicaProszkowa;
    public Toggle KocGasniczy;
    public Toggle Woda;
    public Toggle GasnicaPianowa;
    public GameObject KomunikatOBledieWyboru;
    public Text textwprowadzenia;

    private string tmp1="", tmp2="", tmp3="";

    private void Start()
    {
        startStop = PojazdRatunkowy.GetComponent<StartStop>();
        teksty = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("Pozar", "Nastąpił pożar."),
            new KeyValuePair<string, string>("Wypadek", "Nastąpił wypadek."),
            new KeyValuePair<string, string>("ZadanieEwakuacja", "Twoim zadaniem jest ewakuacja zagrożonych z miejsca zdarzenia do bezpiecznego punktu."),
            new KeyValuePair<string, string>("ZadanieZabezpieczenie", "Twoim zadaniem jest zabezpieczenie niebezpiecznych miejsc."),
            new KeyValuePair<string, string>("ZadaniePozar", "Twoim zadaniem jest ugasic pożar."),

            new KeyValuePair<string, string>("GazPrzyczyna", "Przyczyną jest ulatniający się gaz."),
            new KeyValuePair<string, string>("PradPrzyczyna", "Przyczyną jest prąd."),
            new KeyValuePair<string, string>("WybierzSposobGaszenia", "Wybierz sprzęt jakim będziesz gasić pożar"),
            new KeyValuePair<string, string>("GasnicaProszkowa", "Gaśnica Proszkowa"),
            new KeyValuePair<string, string>("Woda", "Gaszenie wodą z węża strażackiego"),
            new KeyValuePair<string, string>("Koc", "Koc gaśniczy"),
            new KeyValuePair<string, string>("GasnicaPianowa", "Gaśnica Pianowa")
        };
        ZbudujPolecenie();
    }
    public string PodajTekst(string key)
    {
        var wartosc = teksty.Find(x => x.Key == key);
        return wartosc.Value;
    }
    private void ZbudujPolecenie()
    {
   
        switch (startStop.typAkcji)
        {
            case "Pozar":
                tmp1 = PodajTekst("Pozar");
                break;
            case "Wypadek":
                tmp1 = PodajTekst("Wypadek");
                break;
        }
        switch (startStop.typSzczegolowy)
        {
            case "Pozar_Ogien":
                tmp2 = PodajTekst("ZadaniePozar");
                tmp3 = PodajTekst("WybierzSposobGaszenia");
                break;
            case "Pozar_Gaz":
                tmp2 = PodajTekst("GazPrzyczyna");
                tmp3 = PodajTekst("WybierzSposobGaszenia");
                break;
            case "Pozar_Prad":
                tmp2 = PodajTekst("PradPrzyczyna");
                tmp3 = PodajTekst("WybierzSposobGaszenia");            
                break;
            case "Ewakuacja":
                tmp2 = PodajTekst("ZadanieEwakuacja");   
                break;
            case "Zabezpieczenie":
                tmp2 = PodajTekst("ZadanieZabezpieczenie");
                break;
        }
        if (tmp3 != "")
        {
            WyborSprzetu.SetActive(true);
        }
        string komunikatDoWyswietlenia = string.Concat(tmp1, " ", tmp2, " ", tmp3);
        textwprowadzenia.text = komunikatDoWyswietlenia; 
    }
    bool SprawdzCzyPoprawnySprzet()
    {

        switch (startStop.PodajTypSzczegolowy())
        {
            case "Pozar_Ogien":
                if (Woda.isOn == true || GasnicaPianowa.isOn == true )
                {
                    return true;
                }
                break;
            case "Pozar_Gaz":
                if (GasnicaProszkowa.isOn == true)
                {
                    return true;
                }
                break;
            case "Pozar_Prad":
                if (GasnicaProszkowa.isOn == true)
                {
                    return true;
                }
                break;
            default:
                return true;
                break;
        }
        return false;
    }
    public void ReakcjaNaPrzyciskRozpocznij()
    {
        if (SprawdzCzyPoprawnySprzet() == false)
        {
            KomunikatOBledieWyboru.SetActive(true);
            KomunikatOBledieWyboru.GetComponentInChildren<Text>().text = "Wybrałeś niepoprawny sprzęt ratunkowy. Proszę wybrać ponownie";
        }
        else
        {
            KomunikatBleduWyboruSprzetu.GetComponent<MenuWprowadzenie>().WylaczWprowadzenie();
            if (KomunikatBleduWyboruSprzetu.activeInHierarchy == true)
            {
                KomunikatOBledieWyboru.SetActive(false);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LicznikZycia : MonoBehaviour
{
    public GameObject gracz;
    public Gracz skrypt;
    private Text wyswietlanaWartoscCzasu;
    private float zmiennaTymczasowa;
    private string minuty;
    private string sekundy;

    void Start()
    {
        skrypt = gracz.GetComponent<Gracz>();
        wyswietlanaWartoscCzasu = this.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        zmiennaTymczasowa = skrypt.PodajPunktyZycia();
        minuty = Mathf.Floor(zmiennaTymczasowa / 60).ToString("00");
        sekundy = (zmiennaTymczasowa % 60).ToString("00");
        //Debug.Log(sekundy);
       // string tmp = 
        wyswietlanaWartoscCzasu.text = string.Concat("Pozostało: ", minuty, ": ",sekundy);
    }
}

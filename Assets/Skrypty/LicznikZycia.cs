using System;
using UnityEngine;
using UnityEngine.UI;

public class LicznikZycia : MonoBehaviour
{
    public GameObject odwolanie;
    Gracz postac;
    public Text WyswietlaczZycia;
    void Start()
    {
        postac = odwolanie.GetComponent<Gracz>();
    }

    void Update()
    {
        WyswietlZycie(postac.PodajPunktyZycia());
    }
    private void WyswietlZycie(float wartosc)
    {
        decimal tmp = (decimal)wartosc;
        tmp = Math.Round(tmp, 2);
        WyswietlaczZycia.text = tmp.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
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
        WyswietlZycie(postac.PodajPunktyZycia().ToString());
    }
    private void WyswietlZycie(string wartosc)
    {
        WyswietlaczZycia.text = wartosc;
    }
}

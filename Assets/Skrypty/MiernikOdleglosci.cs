using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiernikOdleglosci : MonoBehaviour
{
    
    public GameObject Gracz, Cel;
    //public GameObject pozycjegry;
    public Text WyswietlaczOdleglosci;
    public float Odleglosc;
    public StartStop skrypt;

    void Start()
    {
        WyswietlaczOdleglosci = this.GetComponent<Text>();
        skrypt = gameObject.GetComponent<StartStop>();
        
    }
  
    void Update()
    {
        Odleglosc = Vector3.Distance(Gracz.transform.position, Cel.transform.position);
        WyswietlaczOdleglosci.text = Odleglosc.ToString("F2");
    }
}

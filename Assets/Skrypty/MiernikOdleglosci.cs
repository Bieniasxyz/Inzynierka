using UnityEngine;
using UnityEngine.UI;

public class MiernikOdleglosci : MonoBehaviour
{
    public GameObject Gracz;
    public Text WyswietlaczOdleglosci;
    public float Odleglosc;
    private StartStop skrypt;
    void Start()
    {
        WyswietlaczOdleglosci = this.GetComponent<Text>();
        skrypt = Gracz.GetComponent<StartStop>();
        
    }
    void Update()
    {
        Odleglosc = Vector3.Distance(Gracz.transform.position, skrypt.Cel.transform.position);
        WyswietlaczOdleglosci.text = Odleglosc.ToString("F2");
    }
}

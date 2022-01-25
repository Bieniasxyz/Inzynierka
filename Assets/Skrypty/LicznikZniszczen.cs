using UnityEngine;
using UnityEngine.UI;

public class LicznikZniszczen : MonoBehaviour
{
    public GameObject pojazd;
    public Gracz gracz;
    Text wyswietlaczZniszczen; 
        
    void Start()
    {
        wyswietlaczZniszczen = gameObject.GetComponent<Text>();
        gracz = gameObject.GetComponent<Gracz>();
    }
    void Update()
    {
         wyswietlaczZniszczen.text = gracz.PodajAktualneZniszczenia().ToString();
    }
}

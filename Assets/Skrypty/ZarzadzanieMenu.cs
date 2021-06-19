using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ZarzadzanieMenu : MonoBehaviour
{
    //public GameObject NazwaGracza;
    public GameObject MenuWGrze;
    //public Text WyswietlczNazwyGracza;
    private bool GraJestAktywna;
    private void Start()
    {
        GraJestAktywna = true;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            MenuGryJestAktywne();
        }
    }
    private void WpiszNazweGraczaDoPola()
    {
        InputField text;
        text = gameObject.GetComponentInChildren<InputField>();
        
    }
    public void MenuGryJestAktywne()
    {
        MenuWGrze.SetActive(true);
        GraJestAktywna = false;
        Time.timeScale = 0f;
    }
    public void MenuGryJestWylaczone()
    {
        MenuWGrze.SetActive(false);
        GraJestAktywna = true;
        Time.timeScale = 1f;
    }

}

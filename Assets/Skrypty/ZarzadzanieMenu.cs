using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ZarzadzanieMenu : MonoBehaviour
{
    public GameObject NazwaGracza;
    public GameObject MenuWGrze;
    public Text WyswietlczNazwyGracza;
    private bool GraJestAktywna = true;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            MenuGryJestAktywne();
        }
    }
    public void WyjdzZGry()
    {
        Application.Quit();
    }
    public void LadujScene(int numer)
    {
        SceneManager.LoadScene(numer);
    }
    public void RozpocznijGre()
    {
        LadujScene(1);
    }
    public void OdczytNazwyGracza()
    {
        string NazwaGracza = PlayerPrefs.GetString("NazwaGracza");
        WyswietlczNazwyGracza.GetComponent<Text>().text = NazwaGracza;

    }
    public void ZapiszNazweGracza()
    {
        string nazwa = NazwaGracza.GetComponent<Text>().text;
        PlayerPrefs.SetString("NazwaGracza", nazwa);
        PlayerPrefs.Save();
    }
    private void WpiszNazweGraczaDoPola()
    {
        InputField text;
        text = gameObject.GetComponentInChildren<InputField>();
        
    }
    void MenuGryJestAktywne()
    {
        MenuWGrze.SetActive(true);
        GraJestAktywna = false;
        Time.timeScale = 0f;
    }
    void MenuGryJestWylaczone()
    {
        MenuWGrze.SetActive(false);
        GraJestAktywna = true;
        Time.timeScale = 1f;
    }

}

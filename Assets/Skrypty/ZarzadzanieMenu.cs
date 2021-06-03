using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZarzadzanieMenu : MonoBehaviour
{
    public void WyjdzZGry()
    {
        Application.Quit();
    }
    public void LadujScene(int numer)
    {
        SceneManager.LoadScene(numer);
    }
    public void OdczytDanychGracza()
    {
        string NazwaGracza = PlayerPrefs.GetString("NazwaGracza");
       // return NazwaGracza;
    }
    public void ZapisProfilGracza(string nazwa)
    {
        PlayerPrefs.SetString("NazwaGracza", nazwa);
        PlayerPrefs.Save();
    }
    private void WpiszNazweGraczaDoPola()
    {
        TextMesh text;
        text = gameObject.GetComponentInChildren<TextMesh>();
        text.text = "Moja wazna wiadomosc";
    }
}

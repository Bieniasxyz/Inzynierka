using UnityEngine;
using UnityEngine.UI;

public class MenuWprowadzenie : MonoBehaviour
{
    public GameObject MenuWprowadzenieCanvas;
    public void Start()
    {
        MenuWprowadzenieCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void WylaczWprowadzenie()
    {
        MenuWprowadzenieCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
    public void WyswietlTekst(string tekst)
    {
        this.gameObject.GetComponent<Text>().text = tekst;
    }
    public void WylaczBladWyboru()
    {
        GameObject[] menu = MenuWprowadzenieCanvas.GetComponentsInChildren<GameObject>();
        foreach (var item in menu)
        {
            if (item.name == "BladSprzetuGO")
            {
                item.SetActive(false);
            }
        }
        ZmienTekstPrzycisku();
    }
    public void ZmienTekstPrzycisku()
    {
        MenuWprowadzenieCanvas.GetComponentInChildren<Button>().gameObject.GetComponentInChildren<Text>().text = "Kontynuuj grę";
    }
    public void ZatrzymajCzas()
    {
        Time.timeScale = 0f;
    }
}

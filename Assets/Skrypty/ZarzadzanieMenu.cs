using UnityEngine;

public class ZarzadzanieMenu : MonoBehaviour
{
    public GameObject MenuWGrze;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGry : MonoBehaviour
{
    public GameObject MenuWGrze;
    private bool GraJestAktywna = true;
    private void Start()
    {
        //MenuGryJestWylaczone();
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

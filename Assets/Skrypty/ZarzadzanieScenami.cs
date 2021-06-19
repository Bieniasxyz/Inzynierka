using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ZarzadzanieScenami : MonoBehaviour
{
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
        LadujScene(2);
    }
    public void Smierc ()
    {
        LadujScene(3);
    }
    public void Autor()
    {
        LadujScene(4);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

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
        System.Random rand = new System.Random();
        int[] tablica = new int[3] { 2, 6, 7 };
        int tmp = rand.Next(1, tablica.Length);
        LadujScene(tablica[tmp]);
    }
    public void Smierc ()
    {
        LadujScene(3);
    }
    public void Autor()
    {
        LadujScene(5);
    }
}

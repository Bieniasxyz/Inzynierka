using UnityEngine;
using UnityEngine.UI;

public class Strzalka : MonoBehaviour
{
    private Image strzalka;
    public Transform gracz;
    private Transform cel;
    public GameObject pojazd;
    private StartStop skrypt;
    void Start()
    {
        strzalka = GetComponent<Image>();
        skrypt = pojazd.GetComponent<StartStop>();
        cel = skrypt.BazaKoncowa.transform;
    }
    void Update()
    {
        Vector3 pozycjaGracza = new Vector3(gracz.position.x, 0, gracz.position.z); 
        Vector3 pozycjaCelu = new Vector3(cel.position.x, 0, cel.position.z);

        Vector3 KierunekGracza = (new Vector3(gracz.position.x, 0, gracz.position.z)).normalized;
        Vector3 KierunekCelu = (pozycjaCelu - pozycjaGracza).normalized;

        float kat = Mathf.Acos(Vector3.Dot(KierunekGracza, KierunekCelu)) * Mathf.Rad2Deg;

        if (Vector3.Cross (KierunekGracza, KierunekCelu).y < 0 )
        {
            strzalka.rectTransform.rotation = Quaternion.Euler(new Vector3(0, 0, kat));
        }
        else
        {
            strzalka.rectTransform.rotation = Quaternion.Euler(new Vector3(0, 0, -kat));
        }
    }
}

using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    [Header("Ustawienia otwierania")]
    public float openAngle = -90f; // k¹t otwarcia (negatywny obraca drzwi w jedn¹ stronê; zmieñ, jeœli potrzeba)
    public float openSpeed = 2f;   // szybkoœæ animacji otwierania/zamykania drzwi

    private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        // Zapamiêtanie zamkniêtej (domyœlnej) rotacji pivotu
        closedRotation = transform.localRotation;
        // Obliczenie docelowej rotacji: dodajemy openAngle do bie¿¹cej rotacji w osi Y
        openRotation = Quaternion.Euler(transform.localEulerAngles.x,
                                        transform.localEulerAngles.y + openAngle,
                                        transform.localEulerAngles.z);
    }

    void Update()
    {
        // Dla testu u¿ywamy klawisza spacji do prze³¹czania stanu drzwi
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleDoor();
        }
    }

    public void ToggleDoor()
    {
        StopAllCoroutines();
        StartCoroutine(RotateDoor());
    }

    IEnumerator RotateDoor()
    {
        float t = 0f;
        Quaternion startRotation = transform.localRotation;
        // Okreœl docelow¹ rotacjê – jeœli drzwi s¹ otwarte, wracamy do zamkniêtej pozycji, inaczej otwieramy
        Quaternion targetRotation = isOpen ? closedRotation : openRotation;

        while (t < 1f)
        {
            t += Time.deltaTime * openSpeed;
            transform.localRotation = Quaternion.Slerp(startRotation, targetRotation, t);
            yield return null;
        }
        // Zmiana stanu drzwi
        isOpen = !isOpen;
    }
}

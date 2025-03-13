using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    // Przeci¹gnij przycisk UI (np. GameObject, który zawiera Button) do tego pola w Inspectorze
    public GameObject doorButton;

    // Upewnij siê, ¿e obiekt gracza ma tag "Player" lub zmodyfikuj warunek wed³ug potrzeb
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Aktywuj przycisk gdy gracz wejdzie do triggera
            doorButton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Wy³¹cz przycisk, gdy gracz opuœci trigger
            doorButton.SetActive(false);
        }
    }
}

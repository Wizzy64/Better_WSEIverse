using UnityEngine;
using System.Collections;
using Valve.VR; // SteamVR Input

public class DoorController : MonoBehaviour
{
    [Header("Ustawienia otwierania")]
    public float openAngle = -90f; // k¹t otwarcia drzwi
    public float openSpeed = 2f;   // szybkoœæ animacji

    [Header("SteamVR Input")]
    public SteamVR_Action_Boolean openDoorAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("PressAButton");
    public SteamVR_Input_Sources handType = SteamVR_Input_Sources.RightHand; // Prawy kontroler

    private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        closedRotation = transform.localRotation;
        openRotation = Quaternion.Euler(transform.localEulerAngles.x,
                                        transform.localEulerAngles.y + openAngle,
                                        transform.localEulerAngles.z);
    }

    void Update()
    {
        // Sprawdzamy, czy przycisk A na prawym kontrolerze zosta³ naciœniêty
        if (openDoorAction.GetStateDown(handType))
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
        Quaternion targetRotation = isOpen ? closedRotation : openRotation;

        while (t < 1f)
        {
            t += Time.deltaTime * openSpeed;
            transform.localRotation = Quaternion.Slerp(startRotation, targetRotation, t);
            yield return null;
        }
        isOpen = !isOpen;
    }
}

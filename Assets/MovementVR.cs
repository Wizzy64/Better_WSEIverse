using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
public class MovementVR : MonoBehaviour
{
    public SteamVR_Action_Vector2 input;
    public float speed = 1;
    void Update()
    {
       transform.position += speed *Time.deltaTime * new Vector3(input.axis.x, 0, input.axis.y);
    }
}

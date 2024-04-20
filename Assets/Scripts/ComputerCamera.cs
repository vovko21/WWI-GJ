using UnityEngine;
using Cinemachine;

public class ComputerCamera : MonoBehaviour, IInteractable
{
    public CinemachineVirtualCamera virtualCamera;
    public void Interact(RaycastHit hit)
    {
        virtualCamera.Priority = 20;
    }
}
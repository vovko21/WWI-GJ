using UnityEngine;

public class Computer : MonoBehaviour, IInteractable
{
    [SerializeField] private CursorView _cursorView;

    public void Interact(RaycastHit hit)
    {
        CameraController.Instance.SetComputerCamera();
        Cursor.lockState = CursorLockMode.Confined;
        _cursorView.SetCursorActive(false);
    }

    public void LeaveComputer()
    {
        CameraController.Instance.SetMainCamera();
        Cursor.lockState = CursorLockMode.Locked;
        _cursorView.SetCursorActive(true);
    }
}
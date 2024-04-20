using UnityEngine;

public class PositiveButton : MonoBehaviour, IInteractable
{
    public void Interact(RaycastHit hit)
    {
        Debug.Log("PositiveButton was pressed!");
    }
}
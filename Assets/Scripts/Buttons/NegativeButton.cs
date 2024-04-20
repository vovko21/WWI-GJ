using UnityEngine;

public class NegativeButton : MonoBehaviour, IInteractable
{
    public void Interact(RaycastHit hit)
    {
        Debug.Log("NegativeButton was pressed!");
    }
}

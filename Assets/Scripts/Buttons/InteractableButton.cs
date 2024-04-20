using UnityEngine;

public struct ButtonClickedEvent
{
    public bool isPositive;
}

public class InteractableButton : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _isPositive;

    public void Interact(RaycastHit hit)
    {
        EventManager.TriggerEvent(new ButtonClickedEvent() { isPositive = _isPositive });
    }
}
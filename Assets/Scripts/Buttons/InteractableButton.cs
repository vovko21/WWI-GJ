using UnityEngine;

public struct ButtonClickedEvent
{
    public bool isPositive;
}

public class InteractableButton : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _isPositive;
    Animator animator;
    private void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    public void Interact(RaycastHit hit)
    {
        EventManager.TriggerEvent(new ButtonClickedEvent() { isPositive = _isPositive });

        animator.SetTrigger("Press");
    }
}
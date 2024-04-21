using UnityEngine;

public struct ButtonClickedEvent
{
    public bool isPositive;
}

public class InteractableButton : MonoBehaviour, IInteractable
{
    public AudioSource audioSource;

    [SerializeField] private bool _isPositive;
    Animator animator;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = this.GetComponent<Animator>();
    }

    public void Interact(RaycastHit hit)
    {
        EventManager.TriggerEvent(new ButtonClickedEvent() { isPositive = _isPositive });

        animator.SetTrigger("Press");
    
        audioSource.Play();
    }
}
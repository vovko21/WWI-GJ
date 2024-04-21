using UnityEngine;

public class CardFolder : MonoBehaviour, IInteractable
{
    [SerializeField] private GameplayController _gameplayController;
    [SerializeField] private CardUI _cardsUI;

    public void Interact(RaycastHit hit)
    {
        _cardsUI.Initialize(_gameplayController.CurrentPerson);
    }
}

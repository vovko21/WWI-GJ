using UnityEngine;

public class GameplayController : MonoBehaviour, IEventListener<ButtonClickedEvent>
{
    private PersonData _currentPerson;

    private void OnEnable()
    {
        this.StartListeningEvent();
    }

    private void OnDisable()
    {
        this.StopListeningEvent();
    }

    public void Initialize()
    {
        _currentPerson = DataGenerator.GetPersonData(GameData.Instance.PersonsData, GameData.Instance.ImpostersData);
    }

    public void OnEvent(ButtonClickedEvent eventParams)
    {
        if (eventParams.isPositive)
        {
            AcceptPerson();
        }
        else
        {
            RejectPerson();
        }
    }

    private void AcceptPerson()
    {

    }

    private void RejectPerson()
    {

    }
}
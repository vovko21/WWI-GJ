using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour, IEventListener<ButtonClickedEvent>
{
    [SerializeField] private PersonView _personView;

    private PersonData _currentPerson;
    private List<PersonData> _errorPersons;

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
        _errorPersons = new List<PersonData>();

        _currentPerson = DataGenerator.GetPersonData(GameData.Instance.PersonsData, GameData.Instance.ImpostersData);

        StartCoroutine(CallNextPerson());
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
        bool isImposter = GameData.Instance.IsImposter(_currentPerson);

        if(isImposter)
        {
            _errorPersons.Add(_currentPerson);
        }

        StartCoroutine(CallNextPerson());
    }

    private void RejectPerson()
    {
        bool isImposter = GameData.Instance.IsImposter(_currentPerson);

        if (!isImposter)
        {
            _errorPersons.Add(_currentPerson);
        }

        StartCoroutine(CallNextPerson());
    }

    private IEnumerator CallNextPerson()
    {
        if(_currentPerson != null)
        {
            _personView.MoveCenterToRight();

            yield return new WaitForSeconds(3f);

            _personView.MoveLeftToCenter();
        }
        else
        {
            _personView.MoveLeftToCenter();
        }
    }
}
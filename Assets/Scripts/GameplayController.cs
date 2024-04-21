using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameplayController : MonoBehaviour, IEventListener<ButtonClickedEvent>
{
    [SerializeField] private PersonView _personView;
    [SerializeField] private List<ImageSO> _ImagesId;

    private PersonData _currentPerson;
    private List<PersonData> _errorPersons;

    public PersonData CurrentPerson => _currentPerson;

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
            _currentPerson = DataGenerator.GetPersonData(GameData.Instance.PersonsData, GameData.Instance.ImpostersData);

            _personView.MoveCenterToRight();

            yield return new WaitForSeconds(1.2f);

            _personView.SetPersonSprite(GetCurrentPersonSprite());

            _personView.MoveLeftToCenter();
        }
        else
        {
            _currentPerson = DataGenerator.GetPersonData(GameData.Instance.PersonsData, GameData.Instance.ImpostersData);

            _personView.SetPersonSprite(GetCurrentPersonSprite());

            yield return new WaitForSeconds(1f);

            _personView.MoveLeftToCenter();
        }

        Debug.Log("NEXT PERSON");
    }

    private Sprite GetCurrentPersonSprite()
    {
        return _ImagesId.FirstOrDefault(x => x.PassportId == _currentPerson.number).Sprite;
    }
}
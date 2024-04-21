using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour, IEventListener<ButtonClickedEvent>
{
    [SerializeField] private PersonView _personView;
    [SerializeField] private EndScreenUI _endScreenUI;
    [SerializeField] private List<ImageSO> _ImagesId;

    private PersonData _currentPerson;
    private List<PersonData> _errorPersons;
    private IEnumerator _nextPersonCoroutine;

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

        StartNextPersonCoroutine();
    }

    public void OnEvent(ButtonClickedEvent eventParams)
    {
        if (eventParams.isPositive)
        {
            Debug.Log("<ACCEPT");
            AcceptPerson();
        }
        else
        {
            Debug.Log("REJECT");
            RejectPerson();
        }
    }

    private void AcceptPerson()
    {
        bool isImposter = GameData.Instance.IsImposter(_currentPerson);

        if(isImposter)
        {
            Debug.Log("<color=red>ERROR</color>");
            _errorPersons.Add(_currentPerson);
        }
        else
        {
            Debug.Log("<color=green>RIGHT</color>");
        }

        StartNextPersonCoroutine();
    }

    private void RejectPerson()
    {
        bool isImposter = GameData.Instance.IsImposter(_currentPerson);

        if (!isImposter)
        {
            Debug.Log("<color=red>ERROR</color>");
            _errorPersons.Add(_currentPerson);
        }
        else
        {
            Debug.Log("<color=green>RIGHT</color>");
        }

        StartNextPersonCoroutine();
    }

    private void StartNextPersonCoroutine()
    {
        if(_nextPersonCoroutine != null)
        {
            StopCoroutine(_nextPersonCoroutine);

            _nextPersonCoroutine = null;
        }

        _nextPersonCoroutine = CallNextPerson();

        StartCoroutine(_nextPersonCoroutine);
    }

    private IEnumerator CallNextPerson()
    {
        var previousPerson = _currentPerson;
        _currentPerson = GameData.Instance.GetNextPersonData();

        if (_currentPerson == null)
        {
            StartCoroutine(EndGame());
            yield return null;
        }

        if (previousPerson != null)
        {
            _personView.MoveCenterToRight();

            yield return new WaitForSeconds(1.2f);

            _personView.SetPersonSprite(GetCurrentPersonSprite());

            _personView.MoveLeftToCenter();
        }
        else
        {
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

    private IEnumerator EndGame()
    {
        _endScreenUI.Initialize(_errorPersons);

        yield return new WaitForSeconds(15f);

        SceneManager.LoadScene("MainMenu");
    }
}
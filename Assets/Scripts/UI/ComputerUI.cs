using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComputerUI : MonoBehaviour
{
    [SerializeField] private Transform _conteiner;
    [SerializeField] private TextMeshProUGUI _deteilsText;
    [SerializeField] private GameObject _prefab;

    private List<PersonItemUI> _itemsUI = new List<PersonItemUI>();

    private void OnEnable()
    {
        PersonItemUI.OnClicked += PersonItemUI_OnClicked;
    }

    private void OnDisable()
    {
        PersonItemUI.OnClicked -= PersonItemUI_OnClicked;
    }

    public void Initialize()
    {
        foreach (var person in GameData.Instance.PersonsData)
        {
            var instantiatedPrefab = Instantiate(_prefab, _conteiner);
            var itemUI = instantiatedPrefab.GetComponent<PersonItemUI>();
            itemUI.Initialize(person);
            _itemsUI.Add(itemUI);
        }
    }

    private void PersonItemUI_OnClicked(PersonData person, string text)
    {
        _deteilsText.text = text;
    }
}

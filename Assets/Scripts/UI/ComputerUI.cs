using System.Collections.Generic;
using UnityEngine;

public class ComputerUI : MonoBehaviour
{
    [SerializeField] private Transform _conteiner;
    [SerializeField] private GameObject _prefab;

    private List<PersonItemUI> _itemsUI = new List<PersonItemUI>();

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
}

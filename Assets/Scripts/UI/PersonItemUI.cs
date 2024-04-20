using TMPro;
using UnityEngine;

public class PersonItemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _idText;

    private PersonData _person;

    public void Initialize(PersonData person)
    {
        _person = person;

        _idText.text = person.number.ToString();
    }
}

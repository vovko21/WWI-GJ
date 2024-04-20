using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PersonItemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _idText;
    [SerializeField] private Button _button;

    private PersonData _person;

    public void Initialize(PersonData person)
    {
        _person = person;

        _idText.text = person.number.ToString();
    }
}

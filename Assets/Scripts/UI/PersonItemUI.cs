using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PersonItemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _idText;
    [SerializeField] private Button _button;

    private PersonData _person;

    public static event Action<PersonData, string> OnClicked;

    //private void OnEnable()
    //{
    //    _button.onClick.AddListener(OnButtonClick);
    //}

    //private void OnDisable()
    //{
    //    _button.onClick.RemoveListener(OnButtonClick);
    //}

    public void Initialize(PersonData person)
    {
        _person = person;

        _idText.text = person.number.ToString();
    }

    public void OnButtonClick()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append("ID: ");
        builder.Append(_person.number);
        builder.Append("\n");

        builder.Append("Ім'я: ");
        builder.Append(_person.fullname);
        builder.Append("\n");

        builder.Append("Дата народження: ");
        builder.Append(_person.birthDate);
        builder.Append("\n");

        builder.Append("Термін ув’язнення: ");
        builder.Append(_person.termOfImprisonment);
        builder.Append("\n");

        builder.Append("Причина ув’язнення: ");
        builder.Append(_person.reasonForImprisonment);
        builder.Append("\n");

        builder.Append("Опис: ");
        builder.Append(_person.description);
        builder.Append("\n");

        builder.Append("Причина звільнення: ");
        builder.Append(_person.reasonForDismissal);
        builder.Append("\n");

        Debug.Log("CLICKED");

        OnClicked?.Invoke(_person, builder.ToString());
    }
}
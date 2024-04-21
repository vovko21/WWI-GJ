using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class EndScreenUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void Initialize(List<PersonData> _errorPersons)
    {
        Cursor.lockState = CursorLockMode.Confined;
        CameraController.Instance.SetCardCamera();

        this.gameObject.SetActive(true);

        StringBuilder stringBuilder = new StringBuilder();

        int index = 1;
        foreach (var person in _errorPersons)
        {
            stringBuilder.AppendLine($"<color=red>œŒÃ»À ¿ {index}</color>\n");

            stringBuilder.AppendLine($"{person.ToString()}\n\n");

            index++;
        }

        _text.text = stringBuilder.ToString();
    }
}

using TMPro;
using UnityEngine;

public class CardUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _deteilsInfoText;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void Initialize(PersonData person)
    {
        _deteilsInfoText.text = person.ToString();
        this.gameObject.SetActive(true);
    }
}
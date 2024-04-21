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
        CameraController.Instance.SetCardCamera();
        _deteilsInfoText.text = person.ToString();
        this.gameObject.SetActive(true);

        Cursor.lockState = CursorLockMode.Confined;
    }

    public void OnButtonClickClose()
    {
        CameraController.Instance.SetMainCamera();
        this.gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
    }
}
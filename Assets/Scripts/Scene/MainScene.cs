using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    [SerializeField] private GameObject _credits;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;

        HideCredits();
    }

    public void Play()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OpenCredits()
    {
        _credits.SetActive(true);
    }

    public void HideCredits()
    {
        _credits.SetActive(false);
    }
}

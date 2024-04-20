using UnityEngine;
using UnityEngine.UI;

public class CursorView : MonoBehaviour, IEventListener<HoverEvent>
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _defaultCursor;

    private void OnEnable()
    {
        this.StartListeningEvent();
    }

    private void OnDisable()
    {
        this.StopListeningEvent();
    }

    private void Start()
    {
        _image.sprite = _defaultCursor;
    }

    public void OnEvent(HoverEvent eventParams)
    {
        if (eventParams.isHover == true)
        {
            SetCursor(eventParams.cursor);
        }
        else
        {
            SetCursor(_defaultCursor);
        }
    }

    private void SetCursor(Sprite cursor)
    {
        _image.sprite = cursor;
        _image.SetNativeSize();
    }
}
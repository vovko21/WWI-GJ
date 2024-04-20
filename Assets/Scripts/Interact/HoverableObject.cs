using UnityEngine;

public struct HoverEvent
{
    public bool isHover;
    public Sprite cursor;
}

public class HoverableObject : MonoBehaviour
{
    protected Camera _mainCamera;

    [SerializeField] protected Sprite _hoverCursor;

    protected bool _isHover = false;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void OnMouseEnter()
    {
        if (DistanceToPlayer() - 0.82f < Player.Instance.MaxHoverDistance)
        {
            if (_isHover == true) return;

            _isHover = true;
            SetHoverEffect(_isHover);
        }
    }

    private void OnMouseOver()
    {
        if (DistanceToPlayer() - 0.82f < Player.Instance.MaxHoverDistance)
        {
            if (_isHover == true) return;

            _isHover = true;
            SetHoverEffect(_isHover);
        }
        else if (_isHover == true)
        {
            _isHover = false;
            SetHoverEffect(_isHover);
        }
    }

    private void OnMouseExit()
    {
        if (_isHover == true)
        {
            _isHover = false;
            SetHoverEffect(_isHover);
        }
    }

    protected virtual void SetHoverEffect(bool hover)
    {
        if (hover)
        {
            EventManager.TriggerEvent(new HoverEvent() { isHover = true, cursor = _hoverCursor });
        }
        else
        {
            EventManager.TriggerEvent(new HoverEvent() { isHover = false, cursor = _hoverCursor });
        }
    }

    protected float DistanceToPlayer()
    {
        return Vector3.Distance(_mainCamera.transform.position, transform.position);
    }

    private void OnDestroy()
    {
        EventManager.TriggerEvent(new HoverEvent() { isHover = false });
    }
}
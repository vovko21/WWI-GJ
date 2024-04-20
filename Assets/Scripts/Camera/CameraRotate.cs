using UnityEngine;

public class CameraRotate : MonoBehaviour
{

    private Vector2 _turn;
    public float minXRotation = -90f;
    public float maxXRotation = 90f;
    public float minYRotation = -30f;
    public float maxYRotation = 30f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        _turn.x += Input.GetAxis("Mouse X");
        _turn.y += Input.GetAxis("Mouse Y");

        _turn.x = Mathf.Clamp(_turn.x, minXRotation, maxXRotation);

        _turn.y = Mathf.Clamp(_turn.y, minYRotation, maxYRotation);

        transform.localRotation = Quaternion.Euler(-_turn.y, _turn.x, 0);
    }
}
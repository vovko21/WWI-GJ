using Cinemachine;
using UnityEngine;

public class CameraController : SingletonMonobehaviour<CameraController>
{
    [SerializeField] private CinemachineVirtualCamera _mainCamera;
    [SerializeField] private CinemachineVirtualCamera _computernCamera;
    [SerializeField] private CinemachineVirtualCamera _cardCamera;

    private int _nonPrioraty = 0;
    private int _activePrioraty = 10;
    private bool _isMainActive;

    public bool IsMainActive => _isMainActive;

    private void Start()
    {
        SetMainCamera();
    }

    public void SetComputerCamera()
    {
        _cardCamera.Priority = _nonPrioraty;
        _computernCamera.Priority = _activePrioraty;
        _mainCamera.Priority = _nonPrioraty;
        _isMainActive = false;
    }

    public void SetMainCamera()
    {
        _cardCamera.Priority = _nonPrioraty;
        _computernCamera.Priority = _nonPrioraty;
        _mainCamera.Priority = _activePrioraty;
        _isMainActive = true;
    }

    public void SetCardCamera()
    {
        _computernCamera.Priority = _nonPrioraty;
        _mainCamera.Priority = _nonPrioraty;
        _cardCamera.Priority = _activePrioraty;
        _isMainActive = false;
    }
}

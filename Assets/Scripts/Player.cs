using System;
using UnityEngine;

public class Player : SingletonMonobehaviour<Player>
{
    [SerializeField] private float _maxHoverDistance = 5f;

    private Camera _camera;

    public float MaxHoverDistance => _maxHoverDistance;
    protected override void Awake()
    {
        base.Awake();
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Interact();
        }
    } 

    private void Interact()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _maxHoverDistance))
        {
            var interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                interactable.Interact(hit);
            }
        }
    }
}
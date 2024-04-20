using UnityEngine;

public class OutlinedHoverableObject : HoverableObject
{
    [SerializeField] protected MeshRenderer _meshRenderer;
    [SerializeField] protected Material _hoverMaterial;

    protected override void SetHoverEffect(bool hover)
    {
        if (hover)
        {
            SetAdditionalMaterial(_hoverMaterial);

            EventManager.TriggerEvent(new HoverEvent() { isHover = true, cursor = _hoverCursor });
        }
        else
        {
            ClearAdditionalMaterial();

            EventManager.TriggerEvent(new HoverEvent() { isHover = false, cursor = _hoverCursor });
        }
    }

    private void SetAdditionalMaterial(Material newMaterial)
    {
        Material[] materialsArray = new Material[(_meshRenderer.materials.Length + 1)];
        _meshRenderer.materials.CopyTo(materialsArray, 0);
        materialsArray[materialsArray.Length - 1] = newMaterial;
        _meshRenderer.materials = materialsArray;
    }

    private void ClearAdditionalMaterial()
    {
        Material[] materialsArray = new Material[(_meshRenderer.materials.Length - 1)];

        for (int i = 0; i < _meshRenderer.materials.Length - 1; i++)
        {
            materialsArray[i] = _meshRenderer.materials[i];
        }

        _meshRenderer.materials = materialsArray;
    }

    private void OnDestroy()
    {
        EventManager.TriggerEvent(new HoverEvent() { isHover = false });
    }
}
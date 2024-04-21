using UnityEngine;

[CreateAssetMenu(menuName = "ScripatableObjects/ImageId")]
public class ImageSO : ScriptableObject
{
    [field: SerializeField] public int PassportId { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }
}

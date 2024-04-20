using UnityEngine;

public class SceneEntryPoint : MonoBehaviour
{
    [SerializeField] private GameData _gameData;

    private void Start()
    {
        JsonReader jsonReader = new JsonReader();

        _gameData.Initialize(jsonReader.LoadDatabase());
    }
}

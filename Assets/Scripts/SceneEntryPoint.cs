using UnityEngine;

public class SceneEntryPoint : MonoBehaviour
{
    [SerializeField] private GameData _gameData;
    [SerializeField] private int _personsCount = 10;

    private void Start()
    {
        JsonReader jsonReader = new JsonReader();

        var database = jsonReader.LoadDatabase();
        var personsDeteils = jsonReader.LoadPersonsDeteils();

        DataGenerator dataGenerator = new DataGenerator();

        dataGenerator.Initialize(database, personsDeteils);
        var generatedPersons = dataGenerator.GeneratePersons(_personsCount);

        _gameData.Initialize(generatedPersons);
    }
}

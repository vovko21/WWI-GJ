using UnityEngine;

public class SceneEntryPoint : MonoBehaviour
{
    [SerializeField] private GameplayController _gameplayController;
    [SerializeField] private ComputerUI _computerUI;
    [SerializeField] private int _personsCount = 10;

    private void Start()
    {
        JsonReader jsonReader = new JsonReader();

        var database = jsonReader.LoadDatabase();
        var personsDeteils = jsonReader.LoadPersonsDeteils();
        var imposterDatabase = jsonReader.LoadImpostersDatabase();
        var imposterPersonsDeteils = jsonReader.LoadImpostersPersonsDeteils();

        DataGenerator dataGenerator = new DataGenerator();

        dataGenerator.Initialize(database, personsDeteils, imposterDatabase, imposterPersonsDeteils);
        var generatedPersons = dataGenerator.GeneratePersons(_personsCount);
        var impostersGeneratedPersons = dataGenerator.GenerateImposterPersons(generatedPersons);

        GameData.Instance.Initialize(generatedPersons, impostersGeneratedPersons);

        _computerUI.Initialize();
        _gameplayController.Initialize();
    }
}
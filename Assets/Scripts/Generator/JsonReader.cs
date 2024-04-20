using UnityEngine;

public class JsonReader
{
    private const string DATABASE_FILENAME = "database";
    private const string PERSON_DETEILS_FILENAME = "persons_deteils";

    private const string IMPOSTERS_DATABASE_FILENAME = "imposters_database";
    private const string IMPOSTERS_PERSON_DETEILS_FILENAME = "imposters_persons_deteils";

    public DatabaseModel LoadDatabase()
    {
        var jsonText = Resources.Load<TextAsset>(DATABASE_FILENAME);
        return JsonUtility.FromJson<DatabaseModel>(jsonText.text);
    }

    public PersonsDeteilsModel LoadPersonsDeteils()
    {
        var jsonText = Resources.Load<TextAsset>(PERSON_DETEILS_FILENAME);
        return JsonUtility.FromJson<PersonsDeteilsModel>(jsonText.text);
    }

    public DatabaseModel LoadImpostersDatabase()
    {
        var jsonText = Resources.Load<TextAsset>(IMPOSTERS_DATABASE_FILENAME);
        return JsonUtility.FromJson<DatabaseModel>(jsonText.text);
    }

    public PersonsDeteilsModel LoadImpostersPersonsDeteils()
    {
        var jsonText = Resources.Load<TextAsset>(IMPOSTERS_PERSON_DETEILS_FILENAME);
        return JsonUtility.FromJson<PersonsDeteilsModel>(jsonText.text);
    }
}
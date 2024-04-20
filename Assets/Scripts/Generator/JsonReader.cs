using UnityEngine;

public class JsonReader
{
    private const string DATABASE_FILENAME = "test.json";

    public DatabaseModel LoadDatabase()
    {
        var databaseJsonText = Resources.Load<TextAsset>(DATABASE_FILENAME);
        var a = JsonUtility.FromJson<DatabaseModel>(databaseJsonText.text);
        return a;
    }
}
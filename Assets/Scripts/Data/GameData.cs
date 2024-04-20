using UnityEngine;

public class GameData : MonoBehaviour
{
    private DatabaseModel _database;

    public DatabaseModel Database => _database;

    public void Initialize(DatabaseModel database)
    {
        _database = database;

        Debug.Log(_database.prisoners[0].number);
    }
}

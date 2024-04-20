using System.Collections.Generic;

public class GameData : SingletonMonobehaviour<GameData>
{
    private List<PersonData> _personsData;

    public List<PersonData> PersonsData => _personsData;

    public void Initialize(List<PersonData> personsData)
    {
        _personsData = personsData;
    }
}

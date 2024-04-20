using System.Collections.Generic;
using System.Linq;

public class GameData : SingletonMonobehaviour<GameData>
{
    private List<PersonData> _personsData;
    private List<PersonData> _impostersData;

    public List<PersonData> PersonsData => _personsData;
    public List<PersonData> ImpostersData => _impostersData;

    public void Initialize(List<PersonData> personsData, List<PersonData> impostersData)
    {
        _personsData = personsData;
        _impostersData = impostersData;
    }

    public bool IsImposter(PersonData person)
    {
        var imposter = ImpostersData.FirstOrDefault(x => x.number == person.number);

        if(imposter != null)
        {
            return false;
        }

        return true;
    }
}
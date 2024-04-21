using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameData : SingletonMonobehaviour<GameData>
{
    private List<PersonData> _personsData;
    private List<PersonData> _impostersData;
    private Dictionary<PersonData, bool> _attendetPersons;
    private Dictionary<PersonData, PersonData> _completePersons;

    public List<PersonData> PersonsData => _personsData;
    public List<PersonData> ImpostersData => _impostersData;

    public void Initialize(List<PersonData> personsData, List<PersonData> impostersData)
    {
        _personsData = personsData;
        _impostersData = impostersData;

        _attendetPersons = new Dictionary<PersonData, bool>();
        foreach (var person in _personsData)
        {
            _attendetPersons.Add(person, false);
        }

        _completePersons = new Dictionary<PersonData, PersonData>();
        for (int i = 0; i < _personsData.Count; i++)
        {
            _completePersons.Add(_personsData[i], _impostersData[i]);
        }
    }

    public bool IsImposter(PersonData person)
    {
        var imposter = ImpostersData.FirstOrDefault(x => x == person);

        if(imposter != null)
        {
            return false;
        }

        return true;
    }

    public PersonData GetNextPersonData()
    {
        if(_attendetPersons.All(x => x.Value == true))
        {
            return null;
        }

        var nonVisitedPersons = _attendetPersons.Where(x => x.Value == false).Select(x => x.Key).ToList();

        PersonData person = null;

        var pick = Random.Range(0, 2);
        if (pick == 0)
        {
            //good person
            person = nonVisitedPersons[Random.Range(0, nonVisitedPersons.Count)];
        }
        else
        {
            //imposter
            for (int i = 0; i < _completePersons.Count; i++)
            {
                if (i == pick)
                {
                    person = _completePersons[nonVisitedPersons[i]];
                }
            }
        }

        _attendetPersons[person] = true;

        if (_attendetPersons.All(x => x.Value == true))
        {
            var A = "";
        }

        return person;
    }
}
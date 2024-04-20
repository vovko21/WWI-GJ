using System.Collections.Generic;
using UnityEngine;

public class DataGenerator
{
    private DatabaseModel _database;
    private PersonsDeteilsModel _personsDeteils;

    private DatabaseModel _imposterDatabase;
    private PersonsDeteilsModel _imposterPersonsDeteils;

    public void Initialize(DatabaseModel database, PersonsDeteilsModel personsDeteils, DatabaseModel imposterDatabase, PersonsDeteilsModel imposterPersonsDeteils)
    {
        _database = database;
        _personsDeteils = personsDeteils;
        _imposterDatabase = imposterDatabase;
        _imposterPersonsDeteils = imposterPersonsDeteils;
    }

    public List<PersonData> GeneratePersons(int count)
    {
        var persons = new List<PersonData>(count);
        for (int i = 0; i < count; i++)
        {
            var passport = _database.passports[Random.Range(0, _database.passports.Count)];
            var termOfImprisonment = _personsDeteils.termsOfImprisonment[Random.Range(0, _personsDeteils.termsOfImprisonment.Length)];
            var reasonForImprisonment = _personsDeteils.reasonsForImprisonment[Random.Range(0, _personsDeteils.reasonsForImprisonment.Length)];
            var description = _personsDeteils.descriptions[Random.Range(0, _personsDeteils.descriptions.Length)];
            var reasonForDismissal = _personsDeteils.reasonsForDismissal[Random.Range(0, _personsDeteils.reasonsForDismissal.Length)];

            var person = GeneratePerson(passport, termOfImprisonment, reasonForImprisonment, description, reasonForDismissal);

            persons.Add(person);
        }
        return persons;
    }

    public List<PersonData> GenerateImposterPersons(List<PersonData> personDatas)
    {
        var imposterPersonsData = new List<PersonData>(personDatas.Count);

        foreach (var person in personDatas)
        {
            var imposterPerson = new PersonData(person.number, person.fullname, person.birthDate, person.termOfImprisonment, person.reasonForImprisonment, person.description, person.reasonForDismissal);

            var fieldIndex = Random.Range(0, 8);
            switch (fieldIndex)
            {
                case 0:
                    imposterPerson.number = GetImposterPassport().number;
                    break;
                case 1:
                    imposterPerson.fullname = GetImposterPassport().fullname;
                    break;
                case 2:
                    imposterPerson.birthDate = GetImposterPassport().birthDate;
                    break;
                case 3:
                    imposterPerson.termOfImprisonment = GetImposterTermOfImprisonment();
                    break;
                case 4:
                    imposterPerson.reasonForImprisonment = GetImposterReasonForImprisonment();
                    break;
                case 5:
                    imposterPerson.description = GetImposterDescription();
                    break;
                case 6:
                    imposterPerson.reasonForDismissal = GetImposterReasonForDismissals();
                    break;
                default:
                    break;
            }

            imposterPersonsData.Add(imposterPerson);
        }

        return imposterPersonsData;
    }

    private PersonData GeneratePerson(PassportModel passport, string termOfImprisonment, string reasonForImprisonment, string description, string reasonForDismissal)
    {
        var person = new PersonData();

        person.number = passport.number;
        person.fullname = passport.fullname;
        person.birthDate = passport.birthDate;
        person.termOfImprisonment = termOfImprisonment;
        person.reasonForImprisonment = reasonForImprisonment;
        person.description = description;
        person.reasonForDismissal = reasonForDismissal;

        return person;
    }

    public static PersonData GetPersonData(List<PersonData> personsData, List<PersonData> impostersData)
    {
        PersonData person = null;

        var pick = Random.Range(0, 2);
        if (pick == 0)
        {
            person = personsData[Random.Range(0, personsData.Count)];
        }
        else
        {
            person = impostersData[Random.Range(0, impostersData.Count)];
        }

        return person;
    }

    private PassportModel GetImposterPassport()
    {
        return _imposterDatabase.passports[Random.Range(0, _imposterDatabase.passports.Count)];
    }

    private string GetImposterTermOfImprisonment()
    {
        return _imposterPersonsDeteils.termsOfImprisonment[Random.Range(0, _imposterPersonsDeteils.termsOfImprisonment.Length)];
    }

    private string GetImposterReasonForImprisonment()
    {
        return _imposterPersonsDeteils.reasonsForImprisonment[Random.Range(0, _imposterPersonsDeteils.reasonsForImprisonment.Length)];
    }

    private string GetImposterDescription()
    {
        return _imposterPersonsDeteils.descriptions[Random.Range(0, _imposterPersonsDeteils.descriptions.Length)];
    }
    private string GetImposterReasonForDismissals()
    {
        return _imposterPersonsDeteils.reasonsForDismissal[Random.Range(0, _imposterPersonsDeteils.reasonsForDismissal.Length)];
    }
}
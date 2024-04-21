using System.Collections.Generic;
using System.Linq;
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
            PersonData person = new PersonData();
            do
            {
                var passport = _database.passports[Random.Range(0, _database.passports.Count)];
                var termOfImprisonment = _personsDeteils.termsOfImprisonment[Random.Range(0, _personsDeteils.termsOfImprisonment.Length)];
                var reasonForImprisonment = _personsDeteils.reasonsForImprisonment[Random.Range(0, _personsDeteils.reasonsForImprisonment.Length)];
                var description = _personsDeteils.descriptions[Random.Range(0, _personsDeteils.descriptions.Length)];
                var reasonForDismissal = _personsDeteils.reasonsForDismissal[Random.Range(0, _personsDeteils.reasonsForDismissal.Length)];

                person = GeneratePerson(passport, termOfImprisonment, reasonForImprisonment, description, reasonForDismissal);
            } 
            while (!IsUnique(persons, person));

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

            var fieldIndex = Random.Range(0, 6);
            switch (fieldIndex)
            {
                case 0:
                    imposterPerson.number = GetImposterPassport(new PassportModel() { fullname = imposterPerson.fullname, number = imposterPerson.number }).number;
                    break;
                case 1:
                    imposterPerson.fullname = GetImposterPassport(new PassportModel() { fullname = imposterPerson.fullname, number = imposterPerson.number }).fullname;
                    break;
                //case 2:
                //    imposterPerson.birthDate = GetImposterPassport().birthDate;
                //    break;
                case 2:
                    imposterPerson.termOfImprisonment = GetImposterTermOfImprisonment(imposterPerson.termOfImprisonment);
                    break;
                case 3:
                    imposterPerson.reasonForImprisonment = GetImposterReasonForImprisonment(imposterPerson.reasonForImprisonment);
                    break;
                case 4:
                    imposterPerson.description = GetImposterDescription(imposterPerson.description);
                    break;
                case 5:
                    imposterPerson.reasonForDismissal = GetImposterReasonForDismissals(imposterPerson.reasonForDismissal);
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

    private bool IsUnique(List<PersonData> generatedPerson, PersonData person)
    {
        var matched = generatedPerson.FirstOrDefault(x => x.number == person.number);

        if (matched != null)
        {
            return false;
        }

        return true;
    }

    private PassportModel GetImposterPassport(PassportModel previous)
    {
        PassportModel newData = null;
        do
        {
            newData = _imposterDatabase.passports[Random.Range(0, _imposterDatabase.passports.Count)];
        } 
        while (previous.number == newData.number && previous.fullname == newData.fullname);
        return newData;
    }

    private string GetImposterTermOfImprisonment(string previous)
    {
        string newData = "";
        do
        {
            newData = _imposterPersonsDeteils.termsOfImprisonment[Random.Range(0, _imposterPersonsDeteils.termsOfImprisonment.Length)];
        }
        while (newData == previous);
        return newData;
    }

    private string GetImposterReasonForImprisonment(string previous)
    {
        string newData = "";
        do
        {
            newData = _imposterPersonsDeteils.reasonsForImprisonment[Random.Range(0, _imposterPersonsDeteils.reasonsForImprisonment.Length)];
        }
        while (newData == previous);
        return newData;
    }

    private string GetImposterDescription(string previous)
    {
        string newData = "";
        do
        {
            newData = _imposterPersonsDeteils.descriptions[Random.Range(0, _imposterPersonsDeteils.descriptions.Length)];
        }
        while (newData == previous);
        return newData;
    }
    private string GetImposterReasonForDismissals(string previous)
    {
        string newData = "";
        do
        {
            newData = _imposterPersonsDeteils.reasonsForDismissal[Random.Range(0, _imposterPersonsDeteils.reasonsForDismissal.Length)];
        }
        while (newData == previous);
        return newData;
    }
}
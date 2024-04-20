using System.Collections.Generic;
using UnityEngine;

public class DataGenerator
{
    private DatabaseModel _database;
    private PersonsDeteilsModel _personsDeteils;

    public void Initialize(DatabaseModel database, PersonsDeteilsModel personsDeteils)
    {
        _database = database;
        _personsDeteils = personsDeteils;
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
}
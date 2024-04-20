using System;

public class PersonData
{
    public int number;
    public string fullname;
    public DateTime birthDate;

    public string termOfImprisonment;
    public string reasonForImprisonment;
    public string description;
    public string reasonForDismissal;

    public PersonData()
    {
        
    }

    public PersonData(int number, string fullname, DateTime birthDate, string termOfImprisonment, string reasonForImprisonment, string description, string reasonForDismissal)
    {
        this.number = number;
        this.fullname = fullname;
        this.birthDate = birthDate;
        this.termOfImprisonment = termOfImprisonment;
        this.reasonForImprisonment = reasonForImprisonment;
        this.description = description;
        this.reasonForDismissal = reasonForDismissal;
    }
}

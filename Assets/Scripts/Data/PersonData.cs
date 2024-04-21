using System;
using System.Text;

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

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append("ID: ");
        builder.Append(this.number);
        builder.Append("\n");

        builder.Append("Ім'я: ");
        builder.Append(this.fullname);
        builder.Append("\n");

        //builder.Append("Дата народження: ");
        //builder.Append(this.birthDate);
        //builder.Append("\n");

        builder.Append("Термін ув’язнення: ");
        builder.Append(this.termOfImprisonment);
        builder.Append("\n");

        builder.Append("Причина ув’язнення: ");
        builder.Append(this.reasonForImprisonment);
        builder.Append("\n");

        builder.Append("Опис: ");
        builder.Append(this.description);
        builder.Append("\n");

        builder.Append("Причина звільнення: ");
        builder.Append(this.reasonForDismissal);
        builder.Append("\n");

        return builder.ToString();
    }

    public override bool Equals(object obj)
    {
        if (!(obj is PersonData))
            return false;

        PersonData other = (PersonData)obj;
        return number == other.number && fullname == other.fullname && birthDate == other.birthDate;
    }

    public override int GetHashCode()
    {
        return number.GetHashCode() ^ fullname.GetHashCode() ^ birthDate.GetHashCode() ^ termOfImprisonment.GetHashCode() ^ reasonForImprisonment.GetHashCode() ^ description.GetHashCode() ^ reasonForDismissal.GetHashCode();
    }
}

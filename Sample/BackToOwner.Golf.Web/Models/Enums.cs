using System;

namespace BackToOwner.Golf.Web.Models
{
    public enum Language
    {
        en,
        fr,
        nl
    }


    public enum Gender
    {
        Male,
        Female
    }

    public enum Command
    {
        Save, Cancel, Next, Previous
    }


    public class LanguageEnumStringType : NHibernate.Type.EnumStringType
    {
        public LanguageEnumStringType():base(typeof(Language),2)
        {}

        public override object GetValue(object enm)
        {
            if (null == enm)
                return String.Empty;

            switch ((Language)enm)
            {
                case Language.fr: return "fr";
                case Language.nl: return "nl";
                case Language.en: return "en";
                default: throw new ArgumentException("Invalid Language");
            }  
        }

        public override object GetInstance(object code)
        {
            code = ((string)code).ToUpper();

            if ("FR".Equals(code))
                return Language.fr;
            else if ("NL".Equals(code))
                return Language.nl;
            else if ("EN".Equals(code))
                return Language.en;

            throw new ArgumentException(
                "Cannot convert code '" + code + "' to Language.");
        }  


    }

    public class GenderEnumStringType : NHibernate.Type.EnumStringType
    {
        public GenderEnumStringType()
            : base(typeof(Gender), 6)
        { }

        public override object GetValue(object enm)
        {
            if (null == enm)
                return String.Empty;

            switch ((Gender)enm)
            {
                case Gender.Male: return "Male";
                case Gender.Female: return "Female";
                default: throw new ArgumentException("Invalid Gender");
            }
        }

        public override object GetInstance(object code)
        {
            code = ((string)code).ToUpper();

            if ("MALE".Equals(code))
                return Gender.Male;
            if ("FEMALE".Equals(code))
                return Gender.Female;

            throw new ArgumentException(
                "Cannot convert code '" + code + "' to Gender.");
        }


    }
}
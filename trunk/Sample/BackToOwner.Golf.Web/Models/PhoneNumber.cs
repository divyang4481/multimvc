using BA.MultiMvc.Framework.NHibernate;

namespace BackToOwner.Golf.Web.Models
{
    public class PhoneNumber:Entity
    {
        private int _countryCode=32;
        private int _number = 0;

        public PhoneNumber()
        {}

        public PhoneNumber(string value)
        {
            _value = value;
        }

        public virtual int CountryCode
        {
            get { return _countryCode; }
            set
            {
                _countryCode = value;
                _value = "+" + CountryCode.ToString() + Number.ToString();
            }
        }


        public virtual int Number
        {
            get { return _number; }
            set
            {
                _number = value;
                _value = "+" + CountryCode.ToString() + Number.ToString();
            }
        }

        private string _value;
        public virtual string Value
        {
            get { return _value; }
            private set { _value = value; }
        }
    }

    public class EmailAddress:Entity
    {       
        private string _value;
        public virtual string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public virtual Owner Owner { get; set; }

    }
}
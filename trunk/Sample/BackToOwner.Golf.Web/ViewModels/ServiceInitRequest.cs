using System.Runtime.Serialization;

namespace BackToOwner.Golf.Web.ViewModels
{
    [DataContract(Namespace = "http://vnd.backtoowner.com/Service/Default",Name ="ServiceInitRequest")]
    public class ServiceInit
    {
        [DataMember]
        public string BadgeNbr { get; set; }
        [DataMember(IsRequired = false)]
        public string Status { get; set; }
        [DataMember(IsRequired=false)]
        public Link[] Links { get; set; }
    }

    [DataContract(Namespace = "http://vnd.backtoowner.com/Service/Default",Name="Link")]
    public class Link
    {
        [DataMember]
        public string Href { get; set; }
    }

    

}
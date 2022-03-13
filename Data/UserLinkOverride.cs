using System;
using cSharpAuth;

namespace Lib
{
        public partial class UserLinkOverride : UserLink
    {

    
        [Newtonsoft.Json.JsonProperty("FriendlyHref", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_]*)?$",ErrorMessage ="Please provide a valid URL, e.g. https://amazon.com")]
        public string FriendlyHref 
        { 
            get{
                return this.Href;
            } 
            set{
                this.Href = value;
            }
        }
    
    }
}

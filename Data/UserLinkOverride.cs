using System;
using cSharpAuth;

namespace Lib
{
        public partial class UserLinkOverride : UserLink
    {

    
        [Newtonsoft.Json.JsonProperty("WebsiteLink", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$",ErrorMessage ="Please provide a valid URL, e.g. https://amazon.com")]
        public string WebsiteLink 
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

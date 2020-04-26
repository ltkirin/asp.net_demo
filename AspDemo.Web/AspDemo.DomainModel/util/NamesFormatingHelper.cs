using AspDemo.DomainModel.founder.entity;
using System.Text;

namespace AspDemo.DomainModel.util
{
    public static class NamesFormatingHelper
    {
        public static string GetDisplayName(Founder founder)
        {
            StringBuilder builder = new StringBuilder(founder.LastName);
            builder[0] = char.ToUpper(builder[0]);
            builder.Append($" {char.ToUpper(founder.FirstName[0])}.");
            if(!string.IsNullOrEmpty(founder.MiddleName))
            {
                builder.Append($"{char.ToUpper(founder.MiddleName[0])}.");
            }

            return builder.ToString();
        }
    }
}

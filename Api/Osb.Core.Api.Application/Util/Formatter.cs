using System.Text.RegularExpressions;
using Osb.Core.Platform.Business.Common;

namespace Osb.Core.Api.Application.Util
{
    public class Formatter
    {
        public static string RemoveMaskFromTaxId(string taxIdWithMask)
        {
            if(taxIdWithMask == null)
                throw new OsbBusinessException("TaxId não pode ser nulo."); //FavoredExcMsg.EXC0003
            
            return Regex.Replace(taxIdWithMask, @"[^\d]+", "");
        }
    }
}
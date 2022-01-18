using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Mando.App.Track
{
    public class IssueTitleDulplicatedException : BusinessException
    {
        public IssueTitleDulplicatedException(string title) : base("IssueTitleDulplicated")
        {
            WithData("title", title);
        }
    }
}

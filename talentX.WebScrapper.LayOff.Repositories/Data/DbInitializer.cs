using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talentX.WebScrapper.LayOff.Entities;

namespace talentX.WebScrapper.LayOff.Repositories.Data
{
    public class DbInitializer
    {
        public static void Initialize(DataContext context)
        {

            context.SaveChanges();
        }
    }
}

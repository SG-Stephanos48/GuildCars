using GuildCars.Data.ADO;
using GuildCars.Data.EF;
using GuildCars.Data.Interfaces;
using GuildCars.Data.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Factories
{
    public class GuildCarsRepositoryFactory
    {

        public static IGuildCarsRepository GetRepository()
        {
            switch (Settings.GetMode())
            {
                case "QA":
                    return new GuildCarsRepositoryMock();
                case "PROD":
                    return new GuildCarsRepositoryEF();
                case "ADO":
                    return new GuildCarsRepositoryADO();
                default:
                    throw new Exception("Could not find valid repository configuration value");
            }
        }

    }
}

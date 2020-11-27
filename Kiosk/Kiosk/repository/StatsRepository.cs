using Kiosk.model.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.repository
{
    interface StatsRepository
    {
        List<MenuProfitsData> GetMenuProfitsData(int startTableIdx, int endTableIdx);

        List<MenuProfitsData> GetCategoryProfitsData(int startTableIdx, int endTableIdx);

        DayProfitsData GetDayProfitsData(DateTime checkDay);

        List<UserProfitsData> GetUserProfitsData();

        AllProfitsData GetAllProfitsData();

        DateTime GetKioskRunTimeData();
    }
}

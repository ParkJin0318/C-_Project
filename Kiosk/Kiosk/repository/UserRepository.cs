using Kiosk.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.repository
{
    interface UserRepository
    {
        List<User> GetAllUser(); // 유저 목록 조회 메서드

        Market GetMarket(int idx); // 매장 조회 메서드

        void SetMarketRunTime(int time, int marketIdx); // 매장 구동시간 저장 메서드

        void SetMessage(User user, string message, bool isGroup); //  tcp 통신: 메세지 전송 메서드
    }
}

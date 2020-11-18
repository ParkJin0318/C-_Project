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

        void SetMessage(string message, bool isGroup); //  tcp 통신: 메세지 전송 메서드
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.repository
{
    interface AuthRepository
    {
        void SetLogin(); // 로그인 메서드

        void SetAutoLogin(); // 자동 로그인 설정 메서드

        bool IsAutoLogin(); // 자동 로그인 확인 메서드
    }
}

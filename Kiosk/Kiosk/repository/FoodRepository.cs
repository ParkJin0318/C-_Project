using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.repository
{
    interface FoodRepository
    {
        List<Food> GetAllFood(); // 음식 목록 조회 메서드

        void SetFoodSale(Food food, int sale); // 음식 가격 할인 메서드
    }
}
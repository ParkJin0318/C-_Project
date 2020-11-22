using Kiosk.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.repository
{
    interface OrderRepository
    {
        int GetMaxIdx(); // 최근 주문 정보 idx 조회 메서드

        int GetMaxOrderIdx(); // 최근 공통 주문 정보 idx 조회 메서드

        List<TableData> GetAllTableInfo(); // 테이블에 해당하는 주문 시간 조회 메서드

        void SetOrderList(ObservableCollection<Food> foodList, int userIdx, int marketIdx, int tableIdx, int payType); // 주문 정보 저장 메서드

        void SendOrderInfo(ObservableCollection<Food> foodList, int orderIdx); // tcp 통신: 주문정보 전송 메서드
    }
}
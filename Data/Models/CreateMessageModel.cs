namespace TempTitle.Data.ViewModel.CreateMessageModel
{
    public class CreateMessageModel
    {
        // 거래소
        public string Exchange { get; set; }
        // 계정
        public string Account { get; set; }
        // 거래종목
        public string Symbol { get; set ; }
        // 주문유형
        // 지정가 : limit, 시장가 : market
        public string Type { get; set; }
        // 주문방법
        // 매수 : buy, 매도 : sell
        public string Side { get; set; }
        // 주문수량
        public int Amount { get; set; }
        // 주문타입
        // 1INCH, KRW
        public string Amount_type { get; set; }
        // 주문가격
        // LAST, BID, ASK, string(소수점포함 실수로 작성가능 / 숫자가 아니면 작성x하고 오류메시지 출력)
        public string Price { get; set; }
        // 주문가격대비 퍼센트(%)
        // 선택사항 : 왼쪽 대비 싸게 매수할 경우 -n(%)을 입력(마이너스값)
        public int Price_pct { get; set; }


    }
}
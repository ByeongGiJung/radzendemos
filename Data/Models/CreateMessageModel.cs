namespace TempTitle.Data.ViewModel.CreateMessageModel
{
    public class CreateMessageModel
    {
        // 거래소
        public string exchange { get; set; }
        // 계정
        public string account { get; set; }
        // 거래종목
        public string symbol { get; set ; }
        // 거래마켓
        public string market { get; set; }
        // 주문유형
        // 지정가 : limit, 시장가 : market
        public string type { get; set; }
        // 주문방법
        // 매수 : buy, 매도 : sell
        public string side { get; set; }
        // 주문가격
        // LAST, BID, ASK, string(소수점포함 실수로 작성가능 / 숫자가 아니면 작성x하고 오류메시지 출력)
        public string price { get; set; }
        // 주문가격대비 퍼센트(%)
        // 선택사항 : 왼쪽 대비 싸게 매수할 경우 -n(%)을 입력(마이너스값)
        public int price_pct { get; set; }

        //===== 주문 수량 선택 =====
        // 주문수량
        public int? amount { get; set; }
        // 주문타입
        // 1INCH, KRW
        public string? amount_type { get; set; }

        // 기준자산
        // 잔액대비 : 없음, 총자산대비 : "equity" : "y"
        public string? equity { get; set; }
        // 기준자산 - 주문수량
        public int? bal_pct { get; set; }

        //===== 선택 사항 =====
        // 미체결 주문 취소
        // 전부취소 : cancel, 매수주문만 : cancel-buy, 매도주문만 : cancel-sell
        public string? open_order { get; set; }
        // 동일주문 연속실행 방지
        // n분이내 유효 : "skip-{n}m", n시간이내 유효 : "skip-{n}h"
        public string? same_order { get; set; }
        // 주문 시간대 설정
        // hh:mm-hh:mm : 00:30-02:00
        // public string? Trading_time { get; set; }
        public string? trading_startTime { get; set; }
        public string? trading_endTime { get; set; }

        // 지연시간
        // 실제 표시는 초단위, 소수점 한자리까지만 입력가능
        public Decimal? delay { get; set; }
        // 메모
        // 사용자 검색용 메모
        public string? memo { get; set; }
    }

    public class CreateMessageModelTypeList
    {
        public static List<string> Exchanges => new List<string> { "비트겟" };
        public static List<string> Accounts => new List<string> { "기본계정" };
        // TODO : 확인 후 추가필요
        public static List<string> Symbols => new List<string> { "1INCH/KRW", "AAVE/KRW" };
        public static List<string> Markets => new List<string> { "KRW" };
        public static List<string> Types => new List<string> { "limit", "market" };
        public static List<string> Sides => new List<string> { "buy", "sell" };
        // TODO : 거래소별로 화폐종류가 다름
        public static List<string> Amount_Types => new List<string> { "Current", "KRW" };
        public static List<string> Equity_Types => new List<string> { "잔액대비", "총자산대비" };
        public static List<string> Prices => new List<string> { "LAST", "BID", "ASK", "SELF" };
        public static List<string> Open_Orders => new List<string> { "cancel", "cancel-buy", "cancel-sell", "cancel-close" };
    }
}
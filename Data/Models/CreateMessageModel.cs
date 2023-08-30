using System.Text.Json.Serialization;

namespace TempTitle.Data.ViewModel.CreateMessageModel
{
    public class CreateMessageModel
    {
        // 거래소
        // Bitget 현물 : bitget-spot, 선물 : bitget
        public string _exchange;
        [JsonIgnore]
        public string RawExchange
        {
            get => _exchange;
            set => _exchange = value;
        }
        public string Exchange => _exchange switch
        {
            "Bitget 현물" => "bitget-spot",
            "Bitget 선물" => "bitget-spot",
            _ => throw new NotImplementedException()
        };

        // 계정
        // TODO : 계정 APIKEY 관련해서 정해지면 수정
        public string Account { get; set; }
        // 거래종목
        // TODO : 확인 후 추가
        public string Symbol { get; set ; }
        // 거래마켓
        // TODO : 확인 후 추가
        public string Market { get; set; }

        // 주문유형
        // 지정가 : limit, 시장가 : market
        public string _type;
        [JsonIgnore]
        public string RawType
        {
            get => _type;
            set => _type = value;
        }
        public string Type => _type switch
        {
            "지정가" => "limit",
            "시장가" => "market",
            _ => throw new NotImplementedException()
        };

        // 주문방법
        // 매수 : buy, 매도 : sell
        public string _side;
        [JsonIgnore]
        public string RawSide
        {
            get => _side;
            set => _side = value;
        }
        public string Side  => _side switch
        {
            "매수" => "buy",
            "매도" => "sell",
            _ => throw new NotImplementedException()
        };

        // 주문가격
        // LAST, BID, ASK, string(소수점포함 실수로 작성가능 / 숫자가 아니면 작성x하고 오류메시지 출력)
        public string _price;
        [JsonIgnore]
        public string RawPrice
        {
            get => _price;
            set => _price = value;
        }
        public string Price => _price switch
        {
            "LAST(마지막 체결가격)" => "last",
            "BID(매수호가에서 최고가격)" => "bid",
            "ASK(매도호가에서 최저가격)" => "ask",
            "직접입력" => "self",
            _ => throw new NotImplementedException()
        };

        // 주문가격대비 퍼센트(%)
        // 선택사항 : 왼쪽 대비 싸게 매수할 경우 -n(%)을 입력(마이너스값)
        // 소수점 2번째 자리까지 가능
        public decimal Price_Pct { get; set; }

        //===== 주문 수량 선택 =====
        // 주문수량(개수)
        // 소수점 4번째 자리까지 가능
        public decimal? Amount { get; set; }
        // 주문타입
        // 1INCH, KRW
        public string? Amount_type { get; set; }

        // 기준자산
        // 잔액대비 : 없음, 총자산대비 : "equity" : "y"
        public string? _equity;
        [JsonIgnore]
        public string? RawEquity
        {
            get => _equity;
            set => _equity = value;
        }
        public string? Equity
        {
            get => _equity == "총자산대비" ? "y" : null;
        }

        // 주문수량(%)
        // 소수 2번째 자리까지 가능
        public decimal? Bal_Pct { get; set; }

        //===== 선택 사항 =====
        // 미체결 주문 취소
        // 전부취소 : cancel, 매수주문만 : cancel-buy, 매도주문만 : cancel-sell
        public string? Open_Order { get; set; }
        // 동일주문 연속실행 방지
        // n분이내 유효 : "skip-{n}m", n시간이내 유효 : "skip-{n}h"
        public string? Same_Order { get; set; }
        // 주문 시간대 설정
        // hh:mm-hh:mm : 00:30-02:00
        public string? Trading_Time { get; set; }

        // 지연시간
        // 소수점 1번째 자리까지 입력가능
        public decimal? delay { get; set; }
        // 메모
        // 사용자 검색용 메모
        [JsonIgnore]
        public string? memo { get; set; }
        // 주문ID
        public string? orderID { get; set; }
    }

    public class CreateMessageModelTypeList
    {
        public static List<string> Exchanges => new List<string> { "Bitget 현물", "Bitget 선물" };
        public static List<string> Accounts => new List<string> { "기본계정" };
        // TODO : 확인 후 추가필요
        public static List<string> Symbols => new List<string> { "1INCH/KRW", "AAVE/KRW" };
        public static List<string> Markets => new List<string> { "KRW" };
        public static List<string> Types => new List<string> { "지정가", "시장가" };
        public static List<string> Sides => new List<string> { "매수", "매도" };
        // TODO : 거래소별로 화폐종류가 다름
        public static List<string> Amount_Types => new List<string> { "Current", "KRW" };
        public static List<string> Equity_Types => new List<string> { "잔액대비", "총자산대비" };
        public static List<string> Prices => new List<string> { "LAST(마지막 체결가격)", "BID(매수호가에서 최고가격)", "ASK(매도호가에서 최저가격)", "직접입력" };
        public static List<string> Open_Orders => new List<string> { "cancel", "cancel-buy", "cancel-sell", "cancel-close" };
    }
}
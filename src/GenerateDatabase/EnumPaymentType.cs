using System.ComponentModel;

namespace GenerateDatabase
{
    public enum EnumPaymentType
    {
        [Description("Bill")]
        Bill = 0,

        [Description("Cash")]
        Cash = 1,

        [Description("Credit Card")]
        CreditCard = 2
    }
}
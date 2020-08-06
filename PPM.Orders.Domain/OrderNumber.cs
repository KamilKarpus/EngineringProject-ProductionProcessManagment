using System;

namespace PPM.Orders.Domain
{
    public class OrderNumber
    {
        public int Number { get; private set; }
        public int Year { get; private set; }

        public OrderNumber(int number, int year)
        {
            Number = number;
            Year = year;
        }
        public static OrderNumber First
            => new OrderNumber(1, DateTime.Now.Year);

        public static OrderNumber From(int number)
        {
            return new OrderNumber(number, DateTime.Now.Year);
        }

        public OrderNumber Next()
        {
            return new OrderNumber(Number + 1, Year);
        }
    }
}
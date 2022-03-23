using CodingChallenge.Domain;
using CodingChallenge.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Service
{
    public class DiscountByNameCalculator : IDiscountCalculator
    {
        public decimal GetDiscountRate(Person person)
        {
            if (person?.Name?.ToLower().StartsWith("a") ?? false)
                return Constants.Constants.TEN_PERCENT_DISCOUNT_RATE; // 10 percent discount rate
            else
                return Constants.Constants.ZERO_PERCENT_DISCOUNT_RATE; // no discount
        }
    }
}

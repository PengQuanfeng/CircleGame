using CircleGameModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICircleGameServiceCore
{
    public interface ICopartnerService
    {
        public List<Copartner> GetCopartners();

        public Task<CopartnerPriceOutput> GetCopartnerPriceAsync(CopartnerPriceInput copartnerPriceInput);
    }
}

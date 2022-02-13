using CircleGameModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICircleGameServiceCore
{
    public interface IMyInviteDetailService
    {
        public Task<List<MyInviteDetail>> GetMyInviteDetailsAsync(String copartnerId);
    }
}

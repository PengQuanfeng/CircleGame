using AutoMapper;
using CircleGameDTOCore;
using CircleGameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CircleGameControlCore
{
    public class CopartnerProfile : Profile
    {
        public CopartnerProfile()
        {
            CreateMap<Copartner, CopartnerOutput>();
            CreateMap<MyInviteDetail, MyInviteDetailOutput>();
        }
    }
}

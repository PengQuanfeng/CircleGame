using AutoMapper;
using CircleGameConfig;
using CircleGameDTOCore;
using CircleGameModel;
using CircleGameService;
using ICircleGameServiceCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CircleGameControlCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CopartnerController : ControllerBase
    {
        private readonly ICopartnerService copartnerService;
        private readonly IMapper map;

        public CopartnerController(ICopartnerService copartnerService, IMapper map)
        {
            this.copartnerService = copartnerService;
            this.map = map;
        }

        /// <summary>
        /// 获取到所有合伙人列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCopartners")]
        public async Task<List<CopartnerOutput>> GetCopartners()
        {
            List<Copartner> copartners = new List<Copartner>();
            copartners = await Task.Run<List<Copartner>>(() =>
            {
                return copartnerService.GetCopartners();
            });
            List<CopartnerOutput> copartnerOutputs = map.Map<List<CopartnerOutput>>(copartners);
            var unitPrice = Config.GetUnitPrice();
            var doublePrice = Config.GetDoubleUnitPrice();
            copartnerOutputs.ForEach(c => { c.UnitPrice = unitPrice; c.DoubleUnitPrice = doublePrice; });
            return copartnerOutputs;
        }

        /// <summary>
        /// 获取到合伙人下对应被邀请人收费详情
        /// </summary>
        /// <param name="copartnerID"></param>
        /// <param name="unitPrice"></param>
        /// <param name="doubleUnitPrice"></param>
        /// <returns></returns>
        [HttpPost("GetCopartnerPrice")]
        public async Task<CopartnerPriceOutput> GetCopartnerPrice([FromBody] CopartnerPriceInput copartnerPriceInput)
        {
            CopartnerPriceOutput copartnerPriceOutput = await copartnerService.GetCopartnerPriceAsync(copartnerPriceInput);
            return copartnerPriceOutput;
        }

        /// <summary>
        /// 更新被选择的时间
        /// </summary>
        /// <param name="selectedDateTime"></param>
        /// <returns></returns>
        [HttpPost("UpdateDateTime")]
        public void UpdateDateTime(DateTime selectedDateTime)
        {
            Config.SetSelectedDateTime(selectedDateTime.ToString("yyyy-MM-dd"));
        }

        
    }
}

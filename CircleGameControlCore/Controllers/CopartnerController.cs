using AutoMapper;
using CircleGameCommonServiceCore;
using CircleGameConfig;
using CircleGameDTOCore;
using CircleGameModel;
using CircleGameService;
using ICircleGameServiceCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CircleGameControlCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CopartnerController : ControllerBase
    {
        private readonly ICopartnerService copartnerService;
        private readonly IMapper map;
        private readonly IExcelService excelService;
        private string excelPath = AppDomain.CurrentDomain.BaseDirectory;

        public CopartnerController(ICopartnerService copartnerService, IMapper map, IExcelService excelService)
        {
            this.copartnerService = copartnerService;
            this.map = map;
            this.excelService = excelService;
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

        /// <summary>
        /// 下载合伙人费用详情excel
        /// </summary>
        /// <param name="selectedDateTime"></param>
        /// <returns></returns>
        [HttpPost("DownloadCopartnerPriceDetial")]
        public async Task<IActionResult> DownloadCopartnerPriceDetial([FromBody] CopartnerPriceInput copartnerPriceInput)
        {
            try
            {
                CopartnerPriceOutput copartnerPriceOutput = await copartnerService.GetCopartnerPriceAsync(copartnerPriceInput);

                if (copartnerPriceOutput != null &&
                    copartnerPriceOutput.MyInviteDetailOutputs != null &&
                    copartnerPriceOutput.MyInviteDetailOutputs.Count > 0)
                {
                    DataTable dataTable = new DataTable();
                    PropertyInfo[] memberInfos = typeof(MyInviteDetailOutput).GetProperties();
                    for (int memberIndex = 0; memberIndex < memberInfos.Length; memberIndex++)
                    {
                        MemberInfo memberInfo = memberInfos[memberIndex];
                        Attribute attribute = memberInfo.GetCustomAttribute(typeof(DisplayNameAttribute));
                        if (attribute != null && attribute is DisplayNameAttribute)
                        {
                            DisplayNameAttribute displayAttribute = attribute as DisplayNameAttribute;
                            dataTable.Columns.Add(displayAttribute.DisplayName);
                        }
                    }

                    for (int rowIndex = 0; rowIndex < copartnerPriceOutput.MyInviteDetailOutputs.Count; rowIndex++)
                    {
                        MyInviteDetailOutput myInviteDetailOutput = copartnerPriceOutput.MyInviteDetailOutputs[rowIndex];
                        DataRow newRow = dataTable.Rows.Add();
                        PropertyInfo[] myInviteDetailFieldInfos = myInviteDetailOutput.GetType().GetProperties();
                        List<PropertyInfo> selectedFieldInfoList = myInviteDetailFieldInfos.Where(m => m.GetCustomAttributes(typeof(DisplayNameAttribute)).Count() > 0).ToList();
                        for (int cellIndex = 0; cellIndex < selectedFieldInfoList.Count; cellIndex++)
                        {
                            PropertyInfo fieldInfo = selectedFieldInfoList[cellIndex];
                            DisplayNameAttribute currentFieldAttr = fieldInfo.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute;

                            if (currentFieldAttr != null && currentFieldAttr.DisplayName.Equals(dataTable.Columns[cellIndex].ColumnName))
                            {
                                newRow[cellIndex] = selectedFieldInfoList[cellIndex].GetValue(myInviteDetailOutput);
                            }
                        }
                    }
                    string worksheetName = copartnerPriceOutput.CopartnerName + "费用详情统计";
                    string downloadFileName = Config.GetSelectedDateTime() + "_" + worksheetName;
                    string fileName = excelPath + downloadFileName + ".xlsx";
                    excelService.ExportExcel(fileName, worksheetName, dataTable);
                    var readStream = System.IO.File.ReadAllBytes(fileName);
                    var file = File(readStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", downloadFileName);
                    file.FileDownloadName = downloadFileName;
                    return file;
                }
            }
            catch (Exception ex)
            {
                Log4Helper.Error(this.GetType(), ex.Message + "   导出文件出错");
            }

            return NoContent();
        }
    }
}

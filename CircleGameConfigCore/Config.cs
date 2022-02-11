using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace CircleGameConfig
{
    public static class Config
    {
        //获取Configuration对象
        private static Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        /// <summary>
        /// 获取到配置信息
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static String GetConfig(String key)
        {
            try
            {
                String value = config.AppSettings.Settings[key].Value;
                return value;
            }
            catch (Exception ex)
            {
                Log4Helper.Error(typeof(Config), String.Format("【读取{0}配置信息出错,错误详情{1}】", key, ex.Message));
            }
            throw new Exception("读取配置信息出错");
        }

        /// <summary>
        /// 设置配置信息
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String SetConfig(String key, String value)
        {
            try
            {
                config.AppSettings.Settings[key].Value = value;
                return value;
            }
            catch (Exception ex)
            {
                Log4Helper.Error(typeof(Config), String.Format("【读取{0}配置信息出错,错误详情{1}】", key, ex.Message));
            }
            throw new Exception("读取配置信息出错");
        }

        public static String GetBaseUrl()
        {
            return GetConfig("baseUrl");
        }

        public static String GetLoginUrl()
        {
            return GetConfig("loginUrl");
        }

        public static String GetCircleId()
        {
            return GetConfig("circleId");
        }

        public static String GetMobile()
        {
            return GetConfig("mobile");
        }

        public static String GetPassword()
        {
            return GetConfig("password");
        }

        public static String GetTypeInfo()
        {
            return GetConfig("type");
        }

        public static String GetLimit()
        {
            return GetConfig("limit");
        }

        public static String GetWinCount()
        {
            return GetConfig("winCount");
        }

        public static String GetSortOrder()
        {
            return GetConfig("sortOrder");
        }

        public static String GetAllMemberListUrl()
        {
            return GetConfig("allMemberListUrl");
        }

        public static String GetMemberRankUrl()
        {
            return GetConfig("memberRankUrl");
        }

        public static String GetInviteRankUrl()
        {
            return GetConfig("inviteRankUrl");
        }

        public static String GetUnitPrice()
        {
            return GetConfig("unitPrice");
        }

        public static String GetDoubleUnitPrice()
        {
            return GetConfig("doubleUnitPrice");
        }

        public static String GetMyInviteDetail()
        {
            return GetConfig("myInviteDetail");
        }

        public static String GetWinnerRecord()
        {
            return GetConfig("winnerRecord");
        }

        public static String GetSelectedDateTime()
        {
            DateTime dateTime = DateTime.Parse(GetConfig("dateTime"));
            return dateTime.ToString("yyyy-MM-dd");
        }

        public static void SetSelectedDateTime(String value)
        {
            SetConfig("dateTime", value);
        }
    }
}

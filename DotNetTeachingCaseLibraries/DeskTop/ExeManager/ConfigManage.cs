using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ExeManager
{
    public static class ConfigManage
    {
        /// <summary>
        /// 添加单个节点
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void AddSetting(string name, string value)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[name] == null)
            {
                config.AppSettings.Settings.Add(name, value);
            }
            else
            {
                config.AppSettings.Settings[name].Value = value;
            }

            config.Save(ConfigurationSaveMode.Modified);
            //重新加载新的配置文件  
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// 批量保存配置文件，Dictionary的key作为节点名，value作为节点值
        /// </summary>
        /// <param name="settings"></param>
        public static void AddSetings(Dictionary<string, string> settings)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            foreach (var name in settings.Keys)
            {
                var value = settings[name];
                if (config.AppSettings.Settings[name] == null)
                {
                    config.AppSettings.Settings.Add(name, value);
                }
                else
                {
                    config.AppSettings.Settings[name].Value = value;
                }
            }

            config.Save(ConfigurationSaveMode.Modified);
            //重新加载新的配置文件  
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// 获取配置文件值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetSettingValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
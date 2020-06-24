using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attributes
{
    /// <summary>
    /// Newtonsoft中的特性
    /// </summary>
    public class NewtonsoftApp
    {
        /// <summary>
        /// 全局配置
        /// </summary>
        public static void DefaultSetting()
        {
            JsonConvert.DefaultSettings = () => {
                var settings = new JsonSerializerSettings { Formatting = Formatting.Indented};
                return settings;
            };
        }
        /// <summary>
        /// 获取序列化json
        /// </summary>
        /// <param name="dynamic"></param>
        /// <returns></returns>
        public static string GetJsonString(dynamic dynamic)
        {
            var json = JsonConvert.SerializeObject(dynamic);
            return json;
        }
        /// <summary>
        /// 获取格式化的json字符串
        /// </summary>
        /// <param name="dynamic"></param>
        /// <returns></returns>
        public static string GetIndentedJsonString(dynamic dynamic)
        {
            var json = JsonConvert.SerializeObject(dynamic, Formatting.Indented);
            return json;
        }
        /// <summary>
        /// 将枚举类型变为string
        /// </summary>
        /// <param name="dynamic"></param>
        /// <returns></returns>
        public static string GetStringEnumJsonString(dynamic dynamic)
        {
            var json = JsonConvert.SerializeObject(dynamic, Formatting.Indented,new StringEnumConverter());
            return json;
        }
        /// <summary>
        /// 格式化时间
        /// </summary>
        /// <param name="dynamic"></param>
        /// <returns></returns>
        public static string GetTimeJsonString(dynamic dynamic)
        {
            var json = JsonConvert.SerializeObject(dynamic, Formatting.Indented, new JsonSerializerSettings { DateFormatString = "yyyy年/MM月/dd日"});
            return json;
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T GetModel<T>(string json)
        {
            T t = JsonConvert.DeserializeObject<T>(json);
            return t;
        }
        /// <summary>
        /// 剔除未被赋值的字段
        /// </summary>
        /// <param name="dynamic"></param>
        /// <returns></returns>
        public static string GetNotNullOrEmptyJsonString(dynamic dynamic)
        {
            var json = JsonConvert.SerializeObject(dynamic, Formatting.Indented, new JsonSerializerSettings() { DefaultValueHandling = DefaultValueHandling.Ignore});
            return json;
        }
        /// <summary>
        /// 获取驼峰命名法则的json字符串
        /// </summary>
        /// <param name="dynamic"></param>
        /// <returns></returns>
        public static string GetCamelJsonString(dynamic dynamic)
        {
            //两种方式都可以
            var json = JsonConvert.SerializeObject(dynamic, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver()});
            //var json = JsonConvert.SerializeObject(dynamic, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy()} });
            return json;
        }
        /// <summary>
        /// 获取蛇形命名法则的json字符串
        /// </summary>
        /// <param name="dynamic"></param>
        /// <returns></returns>
        public static string GetSnakeJsonString(dynamic dynamic)
        {
            var json = JsonConvert.SerializeObject(dynamic, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy()} });
            return json;
        }
        /// <summary>
        /// 合并json文件
        /// </summary>
        /// <param name="json"></param>
        /// <param name="dynamic"></param>
        public static void CombineJson(string json,dynamic dynamic)
        {
            JsonConvert.PopulateObject(json, dynamic);
        }
        /// <summary>
        /// 动态解析json
        /// </summary>
        /// <param name="json"></param>
        public static void DynamicDeserializeObject(string json)
        {
            //var model = JsonConvert.DeserializeObject<Dictionary<object,object>>(json);
            //var model = JsonConvert.DeserializeObject<JObject>(json);
            var model = JsonConvert.DeserializeObject<dynamic>(json);

            foreach (var item in model)
            {
                Console.WriteLine($"{item.ToString()}  {item.Value.ToString()}");
            }
        }
        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="dynamic"></param>
        /// <returns></returns>
        public static string Log(dynamic dynamic)
        {
            MemoryTraceWriter traceWriter = new MemoryTraceWriter();
            JsonConvert.SerializeObject(dynamic, Formatting.Indented, new JsonSerializerSettings { TraceWriter = traceWriter });
            return traceWriter.ToString();
        }
    }
}

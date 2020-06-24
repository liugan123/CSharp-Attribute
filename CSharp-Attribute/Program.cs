using Attributes;
using Model;
using System;

namespace CSharp_Attribute
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 格式化输出Json
            //var model = new JsonModel { ProductName = "小仙女", TotalCustomerCount = 123, TotalPayment = 20.22M, TotalProductCount = 456 };
            //var json = NewtonsoftApp.GetIndentedJsonString(model);
            //Console.WriteLine(json);
            #endregion

            #region 剔除未赋值的字段
            //var model = new JsonModel { ProductName = "小仙女", TotalCustomerCount = 123 };
            //var json = NewtonsoftApp.GetIndentedJsonString(model);
            //Console.WriteLine("原始json：{0}", json);
            //json = NewtonsoftApp.GetNotNullOrEmptyJsonString(model);
            //Console.WriteLine("剔除后的json：{0}", json);
            #endregion

            #region 兼容命名法则
            //var model = new JsonModel { ProductName = "小仙女", TotalCustomerCount = 123, TotalPayment = 20.22M, TotalProductCount = 456 };
            //var json = NewtonsoftApp.GetCamelJsonString(model);
            //Console.WriteLine("驼峰：{0}", json);
            //json = NewtonsoftApp.GetSnakeJsonString(model);
            //Console.WriteLine("蛇形：{0}", json);
            #endregion

            #region 自定义属性的名字
            /*
             * 类字段添加特性[JsonProperty("新字段名")]
             */

            //var json = "{'title':'法式小众设计感长裙气质显瘦纯白色仙女连衣裙','customercount':1000,'totalpayment':100.0,'productcount':10000}";
            //var reportModel = NewtonsoftApp.GetModel<JsonModel>(json);
            //Console.WriteLine(reportModel);
            #endregion

            #region 对字段的正反向剔除
            //正向剔除
            //添加类特性[JsonObject(MemberSerialization.OptOut)] 添加字段特性[JsonIgnore]

            //反向剔除
            //添加类特性[JsonObject(MemberSerialization.OptIn)] 添加字段特性[JsonProperty]
            #endregion

            #region 合并json
            //var json1= @"{'title':'法式小众设计感长裙气质显瘦纯白色仙女连衣裙','customercount':1000}";
            //var json2 = @"{'totalpayment':100.0,'productcount':10000}";
            //JsonModel model = new JsonModel();
            //NewtonsoftApp.CombineJson(json1, model);
            //NewtonsoftApp.CombineJson(json2, model);
            //Console.WriteLine(model);
            #endregion

            #region 动态解析json
            //var json = @"{'DisplayName': '新一代算法模型',
            //               'CustomerType': 1,
            //               'Report': 123,
            //               'CustomerIDHash': 5}";
            //NewtonsoftApp.DynamicDeserializeObject(json);
            #endregion

            #region 将枚举变为string
            ////添加字段特性[JsonConverter(typeof(StringEnumConverter))]
            //var model = new JsonModel { ProductName = "小仙女", TotalCustomerCount = 123, TotalPayment = 20.22M, TotalProductCount = 456,MyEnum = MyEnum.SUMMER };
            //var json = NewtonsoftApp.GetIndentedJsonString(model);
            //Console.WriteLine("原始序列化：{0}",json);


            //json = NewtonsoftApp.GetStringEnumJsonString(model);
            //Console.WriteLine("易读枚举：{0}",json);
            #endregion

            #region 格式化时间格式
            //var model = new JsonModel { ProductName = "小仙女", TotalCustomerCount = 123, TotalPayment = 20.22M, TotalProductCount = 456,CreateTime = DateTime.Now };
            //var json = NewtonsoftApp.GetTimeJsonString(model);
            //Console.WriteLine(json);
            #endregion

            #region 全局配置
            //var model = new JsonModel { ProductName = "小仙女", TotalCustomerCount = 123, TotalPayment = 20.22M, TotalProductCount = 456 };
            //var json = NewtonsoftApp.GetJsonString(model);
            //Console.WriteLine("设置全局之前：{0}",json);
            //NewtonsoftApp.DefaultSetting();
            //json = NewtonsoftApp.GetJsonString(model);
            //Console.WriteLine("设置全局之后：{0}", json);
            #endregion

            #region 保证json的严谨性，提取未知字段
            //var json = "{'title':'法式小众设计感长裙气质显瘦纯白色仙女连衣裙','customercount':1000,'totalpayment':100.0,'productcount':10000,'Property1':123,'Property2':456,'Property3':789}";
            //var model = NewtonsoftApp.GetModel<JsonModel>(json);
            //Console.WriteLine(model);
            #endregion

            #region 开启日志
            var model = new JsonModel { ProductName = "小仙女", TotalCustomerCount = 123, TotalPayment = 20.22M, TotalProductCount = 456 };
            var log = NewtonsoftApp.Log(model);
            Console.WriteLine(log);
            #endregion
            Console.ReadKey();
        }
    }
}

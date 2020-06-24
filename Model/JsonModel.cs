using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Model
{
    //[JsonObject(MemberSerialization.In)]//反向剔除
    //[JsonObject(MemberSerialization.OptOut)]//正向剔除
    public partial class JsonModel
    {
        [JsonProperty("title")]
        public string ProductName { get; set; }
        [JsonProperty("customercount")]

        public int TotalCustomerCount { get; set; }
        [JsonProperty("totalpayment")]

        public decimal TotalPayment { get; set; }
        [JsonProperty("productcount")]
        //[JsonIgnore]
        //[JsonProperty]
        public int TotalProductCount { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public MyEnum MyEnum { get; set; }


        public DateTime CreateTime { get; set; }
        public override string ToString()
        {
            foreach (var item in _additionalData)
            {
                Console.WriteLine(item+"   ",item.Value);
            }
            return $"ProductName={ProductName},TotalCustomerCount={TotalCustomerCount},TotalPayment={TotalPayment},TotalProductCount={TotalProductCount}";
        }
    }
    public partial class JsonModel
    {
        [JsonExtensionData]
        private IDictionary<string, JToken> _additionalData;

        public JsonModel()
        {
            _additionalData = new Dictionary<string, JToken>();
        }
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            var dict = _additionalData;
        }
    }

    public enum MyEnum
    {
        SPRING = 0,
        SUMMER = 1,
        AUTUMN = 2,
        WINTER = 4
    }
}

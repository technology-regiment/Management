namespace Management.Data.Model
{
    public class Book:Entity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 种类
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Prince { get; set; }
    }
}

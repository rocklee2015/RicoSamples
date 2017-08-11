using System;

namespace Rico.S07.AutoMapperV3.Dto
{
    class ArticleDto
    {
        /// <summary>
        /// 文章唯一编码
        /// </summary>
        public string ArticleID { get; set; }
        /// <summary>
        /// 文章标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 文章摘要
        /// </summary>
        public string Summary { get; set; }
        /// <summary>
        /// 文章内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 文章作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 文章发表日期
        /// </summary>
        public DateTime PostTime { get; set; }
        /// <summary>
        /// 文章发表年份
        /// </summary>
        public int PostYear { get; set; }
        /// <summary>
        /// 文章备注
        /// </summary>
        public string Remark { get; set; }
    }
}

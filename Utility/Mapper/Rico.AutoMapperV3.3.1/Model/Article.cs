using System;

namespace Rico.AutoMapperV3._3._1.Model
{
    public class Article
    {
        public Article()
        {
            this.Id = Guid.NewGuid();
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime PostTime { get; set; }
        public string Remark { get; set; }
        #region IEntity Members
        /// <summary>       
        /// 读取或设置文章的编号    
        /// </summary>       
        public Guid Id { get; set; }
        #endregion
    }
}

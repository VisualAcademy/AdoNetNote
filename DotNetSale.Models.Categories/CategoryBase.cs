namespace DotNetSale.Models.Categories
{
    /// <summary>
    /// 카테고리 모델 클래스
    /// </summary>
    public class CategoryBase
    {
        /// <summary>
        /// 카테고리 고유 일련번호
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 카테고리 이름
        /// </summary>
        public string CategoryName { get; set; }
    }
}

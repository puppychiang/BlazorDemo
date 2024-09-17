using System.ComponentModel.DataAnnotations;

namespace BlazorServer.Models.DBModel
{
    public class OrderInfo
    {
        /// <summary>
        /// 訂單流水號
        /// </summary>
        [Key]
        public int OrderId { get; set; }
        /// <summary>
        /// 成立時間
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 金額
        /// </summary>
        [Required]
        public int Price { get; set; }
        /// <summary>
        /// 訂購人ID
        /// </summary>
        [Required]
        public int CustomerId { get; set; }
        /// <summary>
        /// 是否刪除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}

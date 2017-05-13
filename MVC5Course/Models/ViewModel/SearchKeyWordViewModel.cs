using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.ViewModel
{
    /// <summary>
    /// 這是搜尋專用keywordViewModel
    /// </summary>
    public class SearchKeyWordViewModel : IValidatableObject
    {
        public SearchKeyWordViewModel()
        {
            this.Stock_b = 0;
            this.Stock_e = 99999;
        }

        public string ProductName { get; set; }

        public Nullable<decimal> Stock_b { get; set; }
        public Nullable<decimal> Stock_e { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Stock_e < this.Stock_b)
            {
                yield return new ValidationResult("庫存資料篩選條件錯誤", new string[] { "Stock_b", "Stock_e" });
            }
        }
    }
}
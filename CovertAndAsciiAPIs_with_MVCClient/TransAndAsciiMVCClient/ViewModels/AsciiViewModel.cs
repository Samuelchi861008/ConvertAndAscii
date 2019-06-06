using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TransAndAsciiMVCClient.ViewModel
{
    public class AsciiViewModel
    {
        // 輸入框
        [DisplayName("轉換值：")]
        [Required(ErrorMessage = "請輸入您要轉換的值!")]
        public string Sets { get; set; }

        // 結果框
        [DisplayName("結果：")]
        public string Result { get; set; }
    }
}
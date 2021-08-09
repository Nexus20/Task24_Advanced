using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_24.BLL.DTO {
    public class AnswerDTO : BaseDTO {
        public string UserName { get; set; }
        public string Comment { get; set; }
        public string SiteDesign { get; set; }
        public string EaseOfUse { get; set; }
    }
}

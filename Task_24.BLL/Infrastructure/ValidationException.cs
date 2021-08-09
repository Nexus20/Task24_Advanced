using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_24.BLL.Infrastructure {
    /// <summary>
    /// 
    /// </summary>
    public class ValidationException : Exception {
        public string Property { get; protected set; }
        public ValidationException(string message, string prop) : base(message) {
            Property = prop;
        }
    }
}

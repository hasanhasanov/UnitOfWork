using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF.Web.Models
{
    public class ModalFooter
    {
        public ModalFooter()
        {
            CancelButtonId = "btnCancel";
            SubmitButtonId = "btnSubmit";
            CancelButtonText = "Cancel";
            SubmitButtonText = "Submit";
        }
        public string CancelButtonId { get; set; }
        public string SubmitButtonId { get; set; }
        public string CancelButtonText { get; set; }
        public string SubmitButtonText { get; set; }
    }
}
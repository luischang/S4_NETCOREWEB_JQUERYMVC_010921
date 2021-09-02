using System;

namespace S4_NETCOREWEB_JQUERYMVC.DatabaseFirst.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

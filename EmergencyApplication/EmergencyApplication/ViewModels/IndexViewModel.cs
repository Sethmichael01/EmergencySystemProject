using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyApplication.ViewModels
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            PageContents = GetPageContents();
        }
        public List<PageContent> PageContents { get; set; }
        private List<PageContent> GetPageContents()
        {
            return new List<PageContent>
            {
                new PageContent { Heading = "HEALTH EMERGENCY", Caption = "For Health emergency click the HEALTH ALARM button." },
                new PageContent { Heading = "SECURITY EMERGENCY", Caption = "For Security emergency click the SECURITY ALARM button." }
            };

        }
    }
}
public class PageContent
{
    public string Heading { get; set; }
    public string Caption { get; set; }
}

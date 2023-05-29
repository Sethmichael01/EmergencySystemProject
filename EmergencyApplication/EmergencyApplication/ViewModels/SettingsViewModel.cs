using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyApplication.ViewModels
{
    public class SettingsViewModel
    {
        public SettingsViewModel()
        {
            PageContent = GetSettingPageContent();
        }
        public SettingsPageContent PageContent { get; set; }
        private SettingsPageContent GetSettingPageContent()
        {
            return new SettingsPageContent
            {
                Title = "ABOUT US",
                Content = "Emergency medical service (EMS) is a service which is responsible for leading the department in providing proper planned and organized emergency management resources which is capable of responding to public emergencies whenever it is need"
            };
        }
    }
    public class SettingsPageContent
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}

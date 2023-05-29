using EmergencyApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;


namespace EmergencyApplication.ViewModels
{
    public class EmergencyRequestListViewModel 
    {
        public List<EmergencyRequest> EmergencyRequests { get; set; }
       
    }
}

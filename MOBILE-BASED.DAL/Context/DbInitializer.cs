using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MOBILE_BASED.Models;
using MOBILE_BASED.Models.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOBILE_BASED.DAL.Context
{
    public class DbInitializer
    {
       
        public static void Initialize(IApplicationBuilder app)
        {
            //context.Database.EnsureCreated();
            using var serviceScope = app.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<EmergencySystemDbContext>();


            if (!context.States.Any())
            {
                context.States.Add(new State()
                {
                    StateCode = "FCT",
                    StateName = "Abuja",
                });
                context.States.Add(new State()
                {
                    StateCode = "AB",
                    StateName = "Abia",
                });
                context.States.Add(new State()
                {
                    StateCode = "AD",
                    StateName = "Adamawa",
                });
                context.States.Add(new State()
                {
                   
                    StateCode = "AK",
                    StateName = "Akwa Ibom",
                });
                context.States.Add(new State()
                {
                    StateCode = "AN",
                    StateName = "Anambra",
                });
                context.States.Add(new State()
                {
                   
                    StateCode = "BA",
                    StateName = "Bauchi",
                });
                context.States.Add(new State()
                {
                   
                    StateCode = "BY",
                    StateName = "Bayelsa",
                });
                context.States.Add(new State()
                {
                   
                    StateCode = "BN",
                    StateName = "Benue",
                });
                context.States.Add(new State()
                {
                   
                    StateCode = "BO",
                    StateName = "Borno",
                });
                context.States.Add(new State()
                {
                   
                    StateCode = "CR",
                    StateName = "Cross River",
                });
                context.States.Add(new State()
                {
                   
                    StateCode = "DT",
                    StateName = "Delta",
                });
                context.States.Add(new State()
                {
                   
                    StateCode = "EB",
                    StateName = "Ebonyi",
                });
                context.States.Add(new State()
                {
                   
                    StateCode = "EN",
                    StateName = "Enugu",
                });
                context.States.Add(new State()
                {
                   
                    StateCode = "ED",
                    StateName = "Edo",
                });
                context.States.Add(new State()
                {
                   
                    StateCode = "EK",
                    StateName = "Ekiti",
                });
                context.States.Add(new State()
                {
                   
                    StateCode = "GM",
                    StateName = "Gombe",
                });
                context.States.Add(new State()
                {
                   
                    StateCode = "IM",
                    StateName = "Imo",
                });
                context.States.Add(new State()
                {
                    
                    StateCode = "JG",
                    StateName = "Jigawa",
                });
                context.States.Add(new State()
                {
                    
                    StateCode = "KD",
                    StateName = "Kaduna",
                });
                context.States.Add(new State()
                {
                    
                    StateCode = "KN",
                    StateName = "Kano",
                });
                context.States.Add(new State()
                {
                    
                    StateCode = "KT",
                    StateName = "Katsina",
                });
                context.States.Add(new State()
                {
                   
                    StateCode = "KB",
                    StateName = "Kebbi",
                });
                context.States.Add(new State()
                {
                  
                    StateCode = "KG",
                    StateName = "Kogi",
                });
                context.States.Add(new State()
                {
                   
                    StateCode = "KW",
                    StateName = "Kwara",
                });
                context.States.Add(new State()
                {
                    
                    StateCode = "LA",
                    StateName = "Lagos",
                });
                context.States.Add(new State()
                {
                   
                    StateCode = "NS",
                    StateName = "Nasarawa",
                });
                context.States.Add(new State()
                {
                  
                    StateCode = "NG",
                    StateName = "Niger",
                });
                context.States.Add(new State()
                {
                  
                    StateCode = "OG",
                    StateName = "Ogun",
                });
                context.States.Add(new State()
                {
                   
                    StateCode = "ON",
                    StateName = "Ondo",
                });
                context.States.Add(new State()
                {
                   
                    StateCode = "OS",
                    StateName = "Osun",
                });
                context.States.Add(new State()
                {
                   
                    StateCode = "OY",
                    StateName = "Oyo",
                });
                context.States.Add(new State()
                {
                   
                    StateCode = "PL",
                    StateName = "Plateau",
                });
                context.States.Add(new State()
                {
                    
                    StateCode = "RV",
                    StateName = "Rivers",
                });
                context.States.Add(new State()
                {
                    
                    StateCode = "SK",
                    StateName = "Sokoto",
                });
                context.States.Add(new State()
                {
                    
                    StateCode = "TB",
                    StateName = "Taraba",
                });
                context.States.Add(new State()
                {
                   
                    StateCode = "YB",
                    StateName = "Yobe",
                });
                context.States.Add(new State()
                {
                   
                    StateCode = "ZM",
                    StateName = "Zamfara",
                });

                var task = Task.Run(() => context.SaveChangesAsync());
                task.Wait();
            }

            if (!context.LocalGovernments.Any())
            {
                var getLgaList = LgaList.PopulateLga();

                var states = context.States.ToList();

                foreach (var state in states)
                {
                    var lgas = getLgaList[state.StateName.ToUpper()];
                    foreach (var lga in lgas)
                    {
                        context.LocalGovernments.Add(new LocalGovernment()
                        {
                           
                            StateId = state.StateId,
                            LgaName = lga
                        });
                    }
                }
                var task = Task.Run(() => context.SaveChangesAsync());
                task.Wait();
            }
        }

    }
}

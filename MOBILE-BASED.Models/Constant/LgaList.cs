﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOBILE_BASED.Models.Constant
{
    public class LgaList
    {
        public static Dictionary<string, List<string>> PopulateLga()
        {
            var lgaList = new Dictionary<string, List<string>>
            {
                {
                    "ABUJA",
                    new List<string>(){"Gwagwalada", "Kuje", "Abaji","Abuja Municipal","Bwari","Kwali", "Others"}
                },

                {
                    "ABIA",
                    new List<string>(){"Aba North","Aba South","Arochukwu","Bende",
                        "Ikwuano","Isiala Ngwa North","Isiala Ngwa South","Isuikwuato",
                        "Obi Ngwa","Ohafia","Ugwunagbo","Ukwa East","Ukwa West","Umuahia North",
                        "Umuahia South","Umu Nneochi"}
                },
                {
                    "ADAMAWA",
                    new List<string>(){"Demsa","Fufore","Ganye","Gayuk","Gombi","Hong","Jada","Lamurde",
                        "Madagali","Mayo Belwa","Michika","Mubi North","Mubi South","Numan","Shelleng",
                        "Song","Toungo","Yola North","Yola South"}
                },
                {
                    "AKWA IBOM",
                    new List<string>(){"Abak","Eastern Obolo","Eket","Esit Eket","Essien Udim","Etim Ekpo",
                        "Etinan","Ibeno","Ibesikpo Asutan","Ibiono-Ibom","Ika","Ikono","Ikot Abasi",
                        "Ikot Ekpene","Ini","Itu","Mbo","Mkpat-Enin","Nsit-Atai","Nsit-Ibom","Nsit-Ubium",
                        "Obot Akara","Okobo","Onna","Oron","Oruk Anam","Udung-Uko","Ukanafun","Uruan",
                        "Urue-Offong Oruko","Uyo" }
                },
                {
                    "ANAMBRA",
                    new List<string>(){ "Aguata","Anambra East","Anambra West","Anaocha","Awka North",
                        "Awka South","Ayamelum","Dunukofia","Ekwusigo","Idemili North","Idemili South",
                        "Ihiala","Njikoka","Nnewi North","Nnewi South","Ogbaru","Onitsha North",
                        "Onitsha South","Orumba North","Orumba South","Oyi"}
                },
                {
                    "BAUCHI",
                    new List<string>(){ "Alkaleri","Bauchi","Bogoro","Damban","Darazo","Dass","Gamawa",
                        "Ganjuwa","Giade","Itas Gadau","Jama'are","Katagum","Kirfi","Misau","Ningi","Shira",
                        "Tafawa Balewa","Toro","Warji","Zaki"}
                },
                {
                    "BAYELSA",
                    new List<string>(){"Brass","Ekeremor","Kolokuma Opokuma","Nembe","Ogbia","Sagbama",
                        "Southern Ijaw","Yenagoa"}
                },
                {
                    "BENUE",
                    new List<string>() {"Apa","Ado","Agatu","Buruku","Gboko","Guma","Gwer East","Gwer West",
                        "Katsina-Ala","Konshisha","Kwande","Logo","Makurdi","Obi","Ogbadibo","Ohimini","Oju",
                        "Okpokwu","Oturkpo","Tarka","Ukum","Ushongo","Vandeikya"}
                },
                {
                    "BORNO",
                    new List<string>(){"Abadam","Askira/Uba","Bama","Bayo","Biu","Chibok","Damboa","Dikwa","Gubio",
                        "Guzamala","Gwoza","Hawul","Jere","Kaga","Kala/Balge","Konduga","Kukawa","Kwaya Kusar",
                        "Mafa","Magumeri","Maiduguri","Marte","Mobbar","Monguno","Ngala","Nganzai","Shani"}
                },
                {
                    "CROSS RIVER",
                    new List<string>(){"Akamkpa","Akpabuyo","Bakassi","Bekwarra","Biase","Boki","Calabar Municipal",
                        "Calabar South","Etung","Ikom","Obanliku","Obubra","Obudu","Odukpani","Ogoja","Yakuur",
                        "Yala"}
                },
                {
                    "DELTA",
                    new List<string>(){"Aniocha South","Bomadi","Burutu","Ethiope East","Ethiope West",
                        "Ika North East","Ika South","Isoko North","Isoko South","Ndokwa East","Ndokwa West",
                        "Okpe","Oshimili North","Oshimili South","Patani","Sapele","Udu","Ughelli North",
                        "Ughelli South","Ukwuani","Uvwie","Warri North","Warri South","Warri South West"}
                },
                {
                    "EBONYI",
                    new List<string>(){"Afikpo North","Afikpo South","Ebonyi","Ezza North","Ezza South","Ikwo",
                        "Ishielu","Ivo","Izzi","Ohaozara","Ohaukwu","Onicha"}
                },
                {
                    "EDO",
                    new List<string>(){"Egor","Esan Central","Esan North-East","Esan South-East","Esan West",
                        "Etsako Central","Etsako East","Etsako West","Igueben","Ikpoba Okha","Orhionmwon","Oredo",
                        "Ovia North-East","Ovia South-West","Owan East","Owan West","Uhunmwonde"}
                },
                {
                    "EKITI",
                    new List<string>(){"Ado","Efon","Ekiti East","Ekiti South-West","Ekiti West","Emure","Gbonyin",
                        "Ido/Osi","Ijero","Ikere","Ikole","Ilejemeje","Irepodun/Ifelodun","Ise Orun","Moba","Oye"}
                },
                {
                    "ENUGU",
                    new List<string>(){"Awgu","Enugu East","Enugu North","Enugu South","Ezeagu","Igbo Etiti",
                        "Igbo Eze North","Igbo Eze South","Isi Uzo","Nkanu East","Nkanu West","Nsukka",
                        "Oji River","Udenu","Udi","Uzo Uwani" }
                },
                {
                    "GOMBE",
                    new List<string>(){"Akko","Balanga","Billiri","Dukku","Funakaye","Gombe","Kaltungo",
                        "Kwami","Nafada","Shongom","Yamaltu/Deba"}
                },
                {
                    "IMO",
                    new List<string>(){"Aboh-Mbaise","Ahiazu Mbaise","Ehime Mbano","Ezinihitte",
                        "Ideato North","Ideato South","Ihitte/Uboma","Ikeduru","Isiala Mbano","Isu",
                        "Mbaitoli","Ngor Okpala","Njaba","Nkwerre","Nwangele","Obowo","Oguta",
                        "Ohaji Egbema","Okigwe","Orlu","Orsu","Oru East","Oru West","Owerri Municipal",
                        "Owerri North","Owerri West","Unuimo"}
                },
                {
                    "JIGAWA",
                    new List<string>(){"Auyo","Babura","Biriniwa","Birnin Kudu","Buji","Dutse","Gagarawa",
                        "Garki","Gumel","Guri","Gwaram","Gwiwa","Hadejia","Jahun","Kafin Hausa","Kazaure",
                        "Kiri Kasama","Kiyawa","Kaugama","Maigatari","Malam Madori","Miga","Ringim","Roni",
                        "Sule Tankarkar","Taura","Yankwashi"}
                },
                {
                    "KADUNA",
                    new List<string>(){"Birni-Gwari","Chikun","Giwa","Igabi","Ikara","Jaba","Jemaa","Kachia",
                        "Kaduna North","Kaduna South","Kagarko","Kajuru","Kaura","Kauru","Kubau","Kudan",
                        "Lere","Makarfi","Sabon Gari","Sanga","Soba","Zangon Kataf","Zaria"}
                },
                {
                    "KANO",
                    new List<string>(){"Ajingi","Albasu","Bagwai","Bebeji","Bichi","Bunkure","Dala",
                        "Dambatta","Dawakin Kudu","Dawakin Tofa","Doguwa","Fagge","Gabasawa","Garko",
                        "Garun Mallam","Gaya","Gezawa","Gwale","Gwarzo","Kabo","Kano Municipal","Karaye",
                        "Kibiya","Kiru","Kumbotso","Kunchi","Kura","Madobi","Makoda","Minjibir","Nasarawa",
                        "Rano","Rimin Gado","Rogo","Shanono","Sumaila","Takai","Tarauni","Tofa","Tsanyawa",
                        "Tudun Wada","Ungogo","Warawa","Wudil"}
                },
                {
                    "KATSINA",
                    new List<string>(){"Bakori","Batagarawa","Batsari","Baure","Bindawa","Charanchi",
                        "Dandume","Danja","Dan Musa","Daura","Dutsi","Dutsin Ma","Faskari","Funtua","Ingawa",
                        "Jibia","Kafur","Kaita","Kankara","Kankia","Katsina","Kurfi","Kusada","Mai'Adua",
                        "Malumfashi","Mani","Mashi","Matazu","Musawa","Rimi","Sabuwa","Safana","Sandamu",
                        "Zango"}
                },
                {
                    "KEBBI",
                    new List<string>(){"Aleiro","Arewa Dandi","Argungu","Augie","Bagudo","Birnin Kebbi",
                        "Bunza","Dandi","Fakai","Gwandu","Jega","Kalgo","Koko Besse","Maiyama","Ngaski",
                        "Sakaba","Shanga","Suru","Wasagu Danko","Yauri","Zuru"}
                },
                {
                    "KOGI",
                    new List<string>(){"Adavi","Ajaokuta","Ankpa","Bassa","Dekina","Ibaji","Idah",
                        "Igalamela Odolu","Ijumu","Kabba/Bunu","Kogi","Lokoja","Mopa Muro","Ofu",
                        "Ogori Magongo","Okehi","Okene","Olamaboro","Omala","Yagba East","Yagba West"}
                },
                {
                    "KWARA",
                    new List<string>(){"Asa","Baruten","Edu","Ekiti","Ifelodun","Ilorin East","Ilorin South",
                        "Ilorin West","Irepodun","Isin","Kaiama","Moro","Offa","Oke Ero","Oyun","Pategi"}
                },
                {
                    "LAGOS",
                    new List<string>(){"Agege","Ajeromi-Ifelodun","Alimosho","Amuwo-Odofin","Apapa","Badagry",
                        "Epe","Eti Osa","Ibeju-Lekki","Ifako-Ijaiye","Ikeja","Ikorodu","Kosofe","Lagos Island",
                        "Lagos Mainland","Mushin","Ojo","Oshodi-Isolo","Shomolu","Surulere" }
                },
                {
                    "NASARAWA",
                    new List<string>(){"Akwanga","Awe","Doma","Karu","Keana","Keffi","Kokona","Lafia","Nasarawa",
                        "Nasarawa Egon","Obi","Toto","Wamba"}
                },
                {
                    "NIGER",
                    new List<string>(){"Agaje","Agwara","Bida","Borgu","Bosso","Chanchaga","Edati","Gbako",
                        "Gurara","Katcha","Kontagora","Lapai","Lavun","Magama","Mariga","Mashegu","Mokwa","Moya",
                        "Paikoro","Rafi","Rijau","Shiroro","Suleja","Tafa","Wushishi"}
                },
                {
                    "OGUN",
                    new List<string>(){"Abeokuta North","Abeokuta South","Ado-Odo Ota","Egbado North",
                        "Egbado South","Ewekoro","Ifo","Ijebu East","Ijebu North","Ijebu North East","Ijebu Ode",
                        "Ikenne","Imeko Afon","Ipokia","Obafemi Owode","Odeda","Odogbolu","Ogun Waterside",
                        "Remo North","Shagamu"}
                },
                {
                    "ONDO",
                    new List<string>(){"Akoko North-East","Akoko North-West","Akoko South-West","Akoko South-East",
                        "Akure North","Akure South","Ese Odo","Idanre","Ifedore","Ilaje","Ile Oluji Okeigbo",
                        "Irele","Odigbo","Okitipupa","Ondo East","Ondo West","Ose","Owo"}
                },
                {
                    "OSUN",
                    new List<string>(){"Aiyedade","Aiyedire","Atakumosa East","Atakumosa West","Boluwaduro",
                        "Boripe","Ede North","Ede South","Egbedore","Ejigbo","Ife Central","Ife East","Ife North",
                        "Ife South","Ifedayo","Ifelodun","Ila","Ilesha East", "Ilesha West", "Irepodun","Irewole",
                        "Isokan","Iwo","Obokun","Odo-Otin","Ola-Oluwa","Olarunda","Oriade","Orolu","Osogbo"}
                },
                {
                    "OYO",
                    new List<string>(){"Afijio","Akinyele","Atiba","Atisbo","Egbeda","Ibadan North",
                        "Ibadan North-East","Ibadan North-West","Ibadan South-East","Ibadan South-West",
                        "Ibarapa Central","Ibarapa East","Ibarapa North","Ido","Irepo","Iseyin","Itesiwaju",
                        "Iwajowa","Kajola","Lagelu","Ogbomosho North","Ogbomosho South","Ogo Oluwa","Olorunsogo",
                        "Oluyole","Ona Ara","Orelope","Ori Ire","Oyo","Oyo East","Saki East","Saki West",
                        "Surulere"}
                },
                {
                    "PLATEAU",
                    new List<string>(){"Barkin Ladi","Bassa","Bokkos","Jos East","Jos North","Jos South","Kanam",
                        "Kanke","Langtang South","Langtang North","Mangu","Mikang","Pankshin","Qua'an Pan","Riyom",
                        "Shendam","Wase"}
                },
                {
                    "RIVERS",
                    new List<string>(){"Abua/Odual","Ahoada East","Ahoada West","Akuku-Toru","Andoni","Asari-Toru",
                        "Bonny","Degema","Eleme","Emuoha","Etche","Gokana","Ikwerre","Khana","Obio Akpor",
                        "Ogba Egbema Ndoni","Ogu Bolo","Okrika","Omuma","Opobo Nkoro","Oyigbo","Port Harcourt",
                        "Tai"}
                },
                {
                    "SOKOTO",
                    new List<string>(){"Binji","Bodinga","Dange Shuni","Gada","Goronyo","Gudu","Gwadabawa","Illela",
                        "Isa","Kebbe","Kware","Rabah","Sabon Birni","Shagari","Silame","Sokoto North",
                        "Sokoto South","Tambuwal","Tangaza","Tureta","Wamako","Wurno","Yabo"}
                },
                {
                    "TARABA",
                    new List<string>(){"Ardo-kola","Bali","Donga","Gashaka","Gassol","Ibi","Jalingo","Karim Lamido",
                        "Kumi","Lau","Sardauna","Takum","Ussa","Wukari","Yorro","Zing"}
                },
                {
                    "YOBE",
                    new List<string>(){"Bade","Bursari","Damaturu","Fika","Fune","Geidam","Gujba","Gulani",
                        "Jakusko","Karasuwa","Machina","Nangere","Nguru","Potiskum","Tarmuwa","Yunusari",
                        "Yusufari"}
                },
                {
                    "ZAMFARA",
                    new List<string>(){"Bakura","Birnin Magaji Kiyaw","Bukkuyum","Bungudu","Gummi","Gusau",
                        "Kaura Namoda","Maradun","Maru","Shinkafi","Talata Mafara","Tsafe","Zurmi"}
                }
            };

            return lgaList;
        }

    }
}

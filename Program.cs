// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System.Net;
        
            var url = $"https://age-of-empires-2-api.herokuapp.com/api/v1/civilizations";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            Lista_civilizaciones ListCivilizaciones = JsonSerializer.Deserialize<Lista_civilizaciones>(responseBody);
                            foreach (Civilization civi in ListCivilizaciones.Civilizations)
                            {
                                Console.WriteLine("id: " + civi.Id + " Nombre: " + civi.Name);
                            }
                            Random r = new Random();
                            int civi_al_azar= r.Next(1,33);
                            Console.WriteLine("Estos son los datos de una civilizacion tomada al azar:");
                            Console.WriteLine("id: " + ListCivilizaciones.Civilizations[civi_al_azar].Id);
                            Console.WriteLine("Nombre: " + ListCivilizaciones.Civilizations[civi_al_azar].Name);
                            Console.WriteLine("Tipo de ejercito: " + ListCivilizaciones.Civilizations[civi_al_azar].ArmyType); 
                            Console.WriteLine("Bonus de civilizacion :" + ListCivilizaciones.Civilizations[civi_al_azar].CivilizationBonus);
                            Console.WriteLine("Expansion :" + ListCivilizaciones.Civilizations[civi_al_azar].Expansion);
                            Console.WriteLine("Bonus de equipo:" + ListCivilizaciones.Civilizations[civi_al_azar].TeamBonus);
                            Console.WriteLine("Tecnologia unica: " + ListCivilizaciones.Civilizations[civi_al_azar].UniqueTech);
                            Console.WriteLine("Unidad unica: " + ListCivilizaciones.Civilizations[civi_al_azar].UniqueUnit);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("Problemas de acceso a la API");
            }


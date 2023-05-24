using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Hl7.Fhir.Model;  
using Hl7.Fhir.Rest;

namespace fhir_dot_net_examples
{
  class EX_C08_SearchContinue : fhir_dot_net_examplese
    {
 
        public void Execute()
        {
            string FHIR_EndPoint = "http://fhirserver.hl7fundamentals.org/fhir";
            var client = new Hl7.Fhir.Rest.FhirClient(FHIR_EndPoint);

            var xbu3 = client.SearchAsync<Practitioner>(new string[] { "address-city=New York" });
            Bundle bu3 = xbu3.GetAwaiter().GetResult();
            
            string listPra = "";
            while (bu3 != null)
            {
                foreach (Bundle.EntryComponent ent in bu3.Entry)
                {
                    Practitioner pr = (Practitioner)ent.Resource;
                    listPra = listPra + pr.Identifier[0].Value + "-" + pr.Name[0].Family + "," + pr.Name[0].Given.First().ToString();


                }
                var tbu3 =client.ContinueAsync(bu3, PageDirection.Next);
                bu3 = tbu3.GetAwaiter().GetResult();
            }
            Console.WriteLine(listPra);
        }
        
    }
}

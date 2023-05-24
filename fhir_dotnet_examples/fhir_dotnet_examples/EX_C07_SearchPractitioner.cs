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
  class EX_C07_SearchPractitioner : fhir_dot_net_examplese
    {
 
        public void Execute()
        {
              string FHIR_EndPoint = "http://fhirserver.hl7fundamentals.org/fhir";
            var client = new Hl7.Fhir.Rest.FhirClient(FHIR_EndPoint);
            try
            {
                //Search By Specialty using simple criteria
                var tbu3 = client.SearchAsync<PractitionerRole>(new string[] { "specialty=http://snomed.info/sct|408443003" });

                Bundle bu3 = tbu3.GetAwaiter().GetResult();
                Hl7.Fhir.Serialization.FhirJsonSerializer s = new Hl7.Fhir.Serialization.FhirJsonSerializer();
                s.Settings.Pretty = false;

                String results = s.SerializeToString(instance: bu3, summary: SummaryType.True);
                Console.WriteLine(results);
                //A.2 Search using complex Query
                var q = new SearchParams()
                    .Where("specialty=http://snomed.info/sct|408443003")
                    .Include("practitioner:practitioner")
                    .Include("organization:organization")
                    .LimitTo(50)
                    .OrderBy("family", Hl7.Fhir.Rest.SortOrder.Ascending);

                q.Add("City", "New York");
            }
            catch (FhirOperationException Exc)
            {
                Console.WriteLine(Exc.Outcome.ToString());
            }

        }
    }
}

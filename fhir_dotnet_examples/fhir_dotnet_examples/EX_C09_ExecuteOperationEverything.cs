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
  class EX_C09_ExecuteOperationEverything : fhir_dot_net_examplese
    {
 
        public void Execute()
        {
           //Step 1: Load the Patient from the Server
            string FHIR_EndPoint = "http://fhirserver.hl7fundamentals.org/fhir";
            var client = new Hl7.Fhir.Rest.FhirClient(FHIR_EndPoint);
            try
            {
                UriBuilder UriBuilderx = new UriBuilder(FHIR_EndPoint);
                UriBuilderx.Path = "Patient/73412";
                Parameters par = new Parameters();
                par.Add("start", new FhirDateTime(2019, 11, 1));
                par.Add("end", new FhirDateTime(2020, 02, 2));
                var TReturnedResource = client.InstanceOperationAsync(UriBuilderx.Uri, "everything", par);
                Hl7.Fhir.Model.Resource ReturnedResource = TReturnedResource.GetAwaiter().GetResult();
                if (ReturnedResource is Hl7.Fhir.Model.Bundle)
                {
                    Hl7.Fhir.Model.Bundle ReturnedBundle = ReturnedResource as Hl7.Fhir.Model.Bundle;
                    Hl7.Fhir.Serialization.FhirJsonSerializer s = new Hl7.Fhir.Serialization.FhirJsonSerializer();
                    string json=s.SerializeToString(ReturnedBundle);
                    Console.WriteLine(json);
                }
            }
            catch (FhirOperationException Exc)
            {
                Console.WriteLine(Exc.Outcome.ToString());
            }

        }
    }
}

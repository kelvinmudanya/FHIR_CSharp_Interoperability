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
  class EX_C01_ServerCapabilityStatement : fhir_dot_net_examplese
    {
 
        public void Execute()
        {
            string FHIR_EndPoint = "http://fhirserver.hl7fundamentals.org/fhir";
            var client = new Hl7.Fhir.Rest.FhirClient(FHIR_EndPoint);
            var tresource = client.CapabilityStatementAsync();
            var resource = tresource.GetAwaiter().GetResult();
            Hl7.Fhir.Serialization.FhirJsonSerializer s = new Hl7.Fhir.Serialization.FhirJsonSerializer();
            string json = s.SerializeToString(resource);
            Console.WriteLine(json);


        }
    }
}

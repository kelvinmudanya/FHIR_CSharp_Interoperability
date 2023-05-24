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
  class EX_C21_ProfileValidation : fhir_dot_net_examplese
    {
 
        public void Execute()
        {
             string FHIR_EndPoint = "http://fhirserver.hl7fundamentals.org/fhir";
            var client = new Hl7.Fhir.Rest.FhirClient(FHIR_EndPoint);
            string fileName = AppContext.BaseDirectory + "MyFHIRPatient.fhir.json";
            string json = System.IO.File.ReadAllText(fileName);
            var parser = new Hl7.Fhir.Serialization.FhirJsonParser();
            try
            {
                Patient pa = parser.Parse<Patient>(json);
                Parameters inParams = new Parameters();
                inParams.Add("resource", pa);
                var tval = client.ValidateResourceAsync(pa);
                OperationOutcome val = tval.GetAwaiter().GetResult();
                Hl7.Fhir.Serialization.FhirJsonSerializer s = new Hl7.Fhir.Serialization.FhirJsonSerializer();
                String results = s.SerializeToString(instance:val);
                
                Console.WriteLine(results);
    }
            catch (FhirOperationException Exc)
            {
                Console.WriteLine(Exc.Outcome.ToString());
            }


        }
    }
}

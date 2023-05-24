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
  class EX_C00_Skeleton : fhir_dot_net_examplese
    {
 
        public void Execute()
        {
            string FHIR_EndPoint = "http://fhirserver.hl7fundamentals.org/fhir";  
            var client = new Hl7.Fhir.Rest.FhirClient(FHIR_EndPoint);
            Console.WriteLine("I am just a skeleton so I do nothing");

        }
    }
}

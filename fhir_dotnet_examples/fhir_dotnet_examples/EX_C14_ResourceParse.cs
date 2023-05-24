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
  class EX_C14_ResourceValidate : fhir_dot_net_examplese
    {
 
        public void Execute()
        {
            //Remember to copy the MyPatientResource.fhir.json  to the bin/debug/netcoreapp3.1 folder
            //or whichever your BaseDirectory is

            string fileName = AppContext.BaseDirectory + "MyPatientResource.fhir.json";
            string json = System.IO.File.ReadAllText(fileName); 

            
            var parser = new Hl7.Fhir.Serialization.FhirJsonParser();
                
            try
            {
                Resource parsedResource = parser.Parse<Resource>(json);
                    
                    
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Error Parsing Resource " + fe.Message.ToString());
                    
            }
         
        }
    }
}

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
  class EX_C10_PatientConditionalCreation : fhir_dot_net_examplese
    {
 
        public void Execute()
        {
              //Step 1: Create The Instance
            var MyPatient = new Patient();
            //Step 2: Populate The Instance
            MyPatient.Name.Add(new HumanName().WithGiven("Alanis").AndFamily("Smithia"));
            MyPatient.Identifier.Add(new Identifier("http://central.patient.id/ident", "123456"));
            MyPatient.Gender = AdministrativeGender.Male;
            //Step 3: Invoke in the Server
            string FHIR_EndPoint = "http://fhirserver.hl7fundamentals.org/fhir";
            var client = new Hl7.Fhir.Rest.FhirClient(FHIR_EndPoint);
            SearchParams conditions = new SearchParams();
            conditions.Add("identifier", "http://central.patient.id/ident|123456" );
            try
            {
                var tCreatedPatient = client.CreateAsync<Patient>(MyPatient,conditions);
                Patient CreatedPatient = tCreatedPatient.GetAwaiter().GetResult();
                
                Console.WriteLine(CreatedPatient.Id);

            }
            catch (FhirOperationException Exc)
            {
                Console.WriteLine(Exc.Outcome.ToString());
            }

        }
    }
}

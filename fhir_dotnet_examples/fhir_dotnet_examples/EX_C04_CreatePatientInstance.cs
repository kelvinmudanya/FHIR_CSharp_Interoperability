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
  class EX_C04_CreatePatientInstance : fhir_dot_net_examplese
    {
 
        public void Execute()
        {
                /*
            Patient Data:
             Smith, Alan, born 06 May 1965, male, mrn: http://testpatient.id/mrn / 99999999    */
            //Step 1: Create The Instance
            var MyPatient = new Patient();
            //Step 2: Populate The Instance
            
            MyPatient.Name.Add(new HumanName().WithGiven("Alan").AndFamily("Smith"));
            MyPatient.Identifier.Add(new Identifier("http://testpatient.id/mrn", "99999999"));
            MyPatient.Gender = AdministrativeGender.Male;
            //Step 3: Invoke in the Server
            string FHIR_EndPoint = "http://fhirserver.hl7fundamentals.org/fhir";
            var client = new Hl7.Fhir.Rest.FhirClient(FHIR_EndPoint);
            try
            {
                var TCreatedPatient = client.CreateAsync<Patient>(MyPatient);
                Patient CreatedPatient = TCreatedPatient.GetAwaiter().GetResult();
                Console.WriteLine(CreatedPatient.Id);

            }
            catch (FhirOperationException Exc)
            {
                Console.WriteLine(Exc.Outcome.ToString());
            }
        
        }
    }
}

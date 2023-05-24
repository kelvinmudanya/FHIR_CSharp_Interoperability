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
  class EX_C22_CreatePractitionerInstance : fhir_dot_net_examplese
    {
 
        public void Execute()
        {
                /*
            Patient Data:
             Smith, Alan, born 06 May 1965, male, mrn: http://testpatient.id/mrn / 99999999    */
            //Step 1: Create The Instance
            var MyPractictioner = new Practitioner();
            //Step 2: Populate The Instance
            
            MyPractictioner.Name.Add(new HumanName().WithGiven("Nabongo").AndFamily("Mumia"));
            MyPractictioner.Identifier.Add(new Identifier("http://testpractitioner.id/mrn", "99999999"));
            MyPractictioner.Gender = AdministrativeGender.Male;
            MyPractictioner.Telecom.Add(new ContactPoint(){
                System = ContactPoint.ContactPointSystem.Email,
                Value = "nabongomumia@gmail.com"
            });
            MyPractictioner.BirthDate = "2022-01-01";
            MyPractictioner.Active = true;
            
            //     ContactPoint.

            // }).ToList();
           
            //Step 3: Invoke in the Server
            string FHIR_EndPoint = "http://fhirserver.hl7fundamentals.org/fhir";
            var practitioner = new Hl7.Fhir.Rest.FhirClient(FHIR_EndPoint);
            try
            {
                var TCreatedPractitioner = practitioner.CreateAsync<Practitioner>(MyPractictioner);
                Practitioner CreatedPractitioner = TCreatedPractitioner.GetAwaiter().GetResult();
                Console.WriteLine(CreatedPractitioner.Id);

            }
            catch (FhirOperationException Exc)
            {
                Console.WriteLine(Exc.Outcome.ToString());
            }
        
        }
    }
}

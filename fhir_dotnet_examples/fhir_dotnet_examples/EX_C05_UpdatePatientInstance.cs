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
  class EX_C05_UpdatePatientInstance : fhir_dot_net_examplese
    {
 
        public void Execute()
        {
           //Step 1: Load the Patient from the Server
            string FHIR_EndPoint = "http://fhirserver.hl7fundamentals.org/fhir";
            var client = new Hl7.Fhir.Rest.FhirClient(FHIR_EndPoint);
            try
            {
                String PatientLogicalId = "Patient/109";
                var  tMyPatient = client.ReadAsync<Patient>(PatientLogicalId);
                Patient MyPatient = tMyPatient.GetAwaiter().GetResult();
                //Step 2: Modify the elements you need
                Address ad = new Address
                {
                    City="Montreal",
                    Country = "Canada",
                    PostalCode = "H2K 4J5",
                    State = "Montreal",
                    Line = new string[] { "3300 Washtenaw Avenue, Suite 227" }
                };
                MyPatient.Address.Add(ad);
                ContactPoint co = new ContactPoint
                {
                    System = ContactPoint.ContactPointSystem.Phone,
                    Value = "613-555-5555"
                };
                MyPatient.Telecom.Add(co);
                var TUpdatedPatient = client.UpdateAsync<Patient>(MyPatient);
                Patient UpdatedPatient = TUpdatedPatient.GetAwaiter().GetResult();
                Console.WriteLine(UpdatedPatient.VersionId);

            }
            catch (FhirOperationException Exc)
            {
                Console.WriteLine(Exc.Outcome.ToString());
            }

        

        }
    }
}

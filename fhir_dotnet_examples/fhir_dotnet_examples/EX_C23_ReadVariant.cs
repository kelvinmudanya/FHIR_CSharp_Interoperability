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
  class EX_C23A_Direct_Read_S  : fhir_dot_net_examplese
    {
 
        public void Execute()
        {
            string FHIR_EndPoint = "http://fhirserver.hl7fundamentals.org/fhir";
            var client = new Hl7.Fhir.Rest.FhirClient(FHIR_EndPoint);
            string PatientLogicalId = "Patient/159";
            var tMyPatient = client.ReadAsync<Patient>(PatientLogicalId);

            var MyPatient = tMyPatient.GetAwaiter().GetResult();

            Hl7.Fhir.Serialization.FhirJsonSerializer s = new Hl7.Fhir.Serialization.FhirJsonSerializer();
            string json=s.SerializeToString(MyPatient);
            Console.WriteLine( json);
    
        }

    }
    class EX_C03B_Version_Read_S :fhir_dot_net_examplese
    {
 
        public void Execute()
        {
            string FHIR_EndPoint = "http://fhirserver.hl7fundamentals.org/fhir";
            var client = new Hl7.Fhir.Rest.FhirClient(FHIR_EndPoint);
            string PatientLogicalId = "Patient/159";
            var tMyPatient = client.ReadAsync<Patient>(PatientLogicalId);
            var MyPatient = tMyPatient.GetAwaiter().GetResult();
            Hl7.Fhir.Serialization.FhirJsonSerializer s = new Hl7.Fhir.Serialization.FhirJsonSerializer();
            string json=s.SerializeToString(MyPatient);
            Console.WriteLine( json);
    
        }

    }
    class EX_C03C_URL_Read_S  :fhir_dot_net_examplese
    {
        public void Execute()
        {
            string FHIR_EndPoint = "http://fhirserver.hl7fundamentals.org/fhir";
            var client = new Hl7.Fhir.Rest.FhirClient(FHIR_EndPoint);
            var tMyPatient=client.ReadAsync<Patient>(ResourceIdentity.Build("Practitioner", "16011"));
            var MyPatient=tMyPatient.GetAwaiter().GetResult();
            Hl7.Fhir.Serialization.FhirJsonSerializer s = new Hl7.Fhir.Serialization.FhirJsonSerializer();
            string json = s.SerializeToString(MyPatient);
            Console.WriteLine( json);

        }

    }
}
   

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
    class EX_C02A_BasicAuth : fhir_dot_net_examplese
    {

        public void Execute()
        {

            var fcs = new FhirClientSettings();
            //Some Settings
            fcs.UseFhirVersionInAcceptHeader = true;
            fcs.ExplicitFhirVersion = "4.0.1";
            fcs.PreferredFormat = ResourceFormat.Json;
            string FHIR_EndPoint = "http://fhirserver.hl7fundamentals.org/fhir";
            var client = new Hl7.Fhir.Rest.FhirClient(FHIR_EndPoint, fcs);

            /*
            Please see https://docs.fire.ly/projects/Firely-NET-SDK/client/request-response.html
            
             public class AuthorizationMessageHandler : HttpClientHandler
             {
         public System.Net.Http.Headers.AuthenticationHeaderValue Authorization { get; set; }
         protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
         {
                 if (Authorization != null)
                         request.Headers.Authorization = Authorization;
                 return await base.SendAsync(request, cancellationToken);
         }
 }
 and add that to the FhirClient:

 var handler = new AuthorizationMessageHandler();
 var bearerToken = "AbCdEf123456" //example-token;
 handler.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
 var client = new FhirClient(handler);
 client.Read<Patient>("example");
             */

        }
    }
    class EX_C02B_BearerTokenAuth : fhir_dot_net_examplese
    {

        public void Execute()
        {
            string FHIR_EndPoint = "http://fhirserver.hl7fundamentals.org/fhir";
            var client = new Hl7.Fhir.Rest.FhirClient(FHIR_EndPoint);
            /*
            client.OnBeforeRequest += (object msender, BeforeRequestEventArgs mer) =>
            {
                mer.RawRequest.Headers.Add("Authorization", "Bearer ya29.QQIBibTwvKkE39hY8mdkT_mXZoRh7Ub9cK9hNsqrxem4QJ6sQa36VHfyuBe");
            };
            */
        }
    }

}

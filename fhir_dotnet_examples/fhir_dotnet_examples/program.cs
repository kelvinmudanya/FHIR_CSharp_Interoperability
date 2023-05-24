using System;
using System.Reflection;
namespace fhir_dot_net_examples
{
    class Program
    {

        //Just change this constant to run the desired MA solution
        private const string V = "EX_C23";

        static void Main(string[] args)
        {
            
            string prefix= V;
            if (prefix!="")
            {
            AssemblySupport a=new AssemblySupport();
            Type f=a.FindClass(prefix);
            if (f!=null)
            {
                fhir_dot_net_examplese modi=Activator.CreateInstance(f) as fhir_dot_net_examplese;  
                modi.Execute();
            }
            else
            {
                Console.WriteLine("Module Not Found");
            }
            }
        }
        
    }
    public interface fhir_dot_net_examplese
        {
            public void Execute();
        }
    class AssemblySupport
    {

        public Type FindClass(string prefix)
    {
        Type found=null;
        foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
        {  
            if (prefix.Length<=type.Name.Length) 
            {
            if (type.Name.Substring(0,prefix.Length )==prefix)
                {
                    found=type;
                }
            }
        }      
        return found;
    } 
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.Serialization.Json;
using System.IO;

namespace ConsoleApp2
{
	class Program
	{
		static void Main(string[] args)
		{
			using (WebClient wc = new WebClient())
			{
				//Console.WriteLine("Enter your Name: ");
				byte[] imageArray = System.IO.File.ReadAllBytes(@"C:\Users\Public\Pictures\Sample Pictures\Chrysanthemum.jpg");
				string base64ImageRepresentationVal = Convert.ToBase64String(imageArray);
				//var base64ImageRepresentation = new { val = base64ImageRepresentationVal };
				

				var jsonObj = new Data()
				{
					base64 = base64ImageRepresentationVal,
					name = "Chrysanthemum"
				};
				string json = "";
				try
				{
					DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Data));
					MemoryStream memObj = new MemoryStream();
					js.WriteObject(memObj, jsonObj);
					memObj.Position = 0;
					StreamReader sr = new StreamReader(memObj);
					json = sr.ReadToEnd();
					sr.Close();
					memObj.Close();
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
				Console.WriteLine(json);
				//Console.WriteLine(new { name = base64ImageRepresentation }.ToString());
				wc.UploadString(@"http://localhost:63010/Home/SayHello", json);
				//Console.WriteLine();
			}
		}
	}
}

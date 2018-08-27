using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using ToDoListDLL;
using System.Linq;
using Newtonsoft.Json;
using System.Text;

namespace AndroidApp
{
    class TaskDownloader
    {
        static public IEnumerable<Tasks> GetAllTasks()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://todolistwebapi20180823030718.azurewebsites.net/");
            //client.DefaultRequestHeaders.Add("appkey", "myapp_key");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response =  client.GetAsync("api/TaskApi/All").Result;

            

            if (response.IsSuccessStatusCode)
            {
               // var tasks = response.Content.ReadAsAsync<IEnumerable<Tasks>>().Result.ToList() ;

                var result = JsonConvert.DeserializeObject<IEnumerable<Tasks>>(response.Content.ReadAsStringAsync().Result);




                return result;
                //grdEmployee.ItemsSource = employees;

            }
            else
            {
                string s = response.StatusCode + response.ReasonPhrase;
            }

            return new List<Tasks>();
        }



        static public async void AddTasksAsync(Tasks t)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://todolistwebapi20180823030718.azurewebsites.net/");
            //client.DefaultRequestHeaders.Add("appkey", "myapp_key");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new StringContent(JsonConvert.SerializeObject(t), Encoding.UTF8, "application/json");

            //var response = client.PostAsync("api/TaskApi/ADD", content);

            var json = JsonConvert.SerializeObject(t);
            var contentj = new StringContent(json, Encoding.UTF8, "application/json");

            
           

            HttpResponseMessage response = await client.PostAsync("api/TaskApi/ADD/%7Btask%7D", contentj);
          //  HttpResponseMessage response = await client.DeleteAsync();

            //  var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                // var tasks = response.Content.ReadAsAsync<IEnumerable<Tasks>>().Result.ToList() ;

               // return true;
                //grdEmployee.ItemsSource = employees;

            }
            else
            {
             //   return false;
            }

           

  
  
          

          
        }





        static public async void DeleteTasksAsync(string id)
        {
            HttpClient client = new HttpClient();
           client.BaseAddress = new Uri("https://todolistwebapi20180823030718.azurewebsites.net/");
            //client.DefaultRequestHeaders.Add("appkey", "myapp_key");
            // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //var content = new StringContent(JsonConvert.SerializeObject(), Encoding.UTF8, "application/json");

            string url = "api/TaskApi/DEL/" + id;

            var response = await client.DeleteAsync(url);



            int fdfdgdfg = 4654;
            //HttpRequestMessage request = new HttpRequestMessage
            //{
            //    Content  = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json"),
            //    Method = HttpMethod.Delete,
            //    RequestUri = new Uri("https://todolistwebapi20180823030718.azurewebsites.net/api/TaskApi/DEL/"+id)
            //};
            //HttpResponseMessage response = await client.SendAsync(request);


            if (response.IsSuccessStatusCode)
            {
                // var tasks = response.Content.ReadAsAsync<IEnumerable<Tasks>>().Result.ToList() ;

                // return true;
                //grdEmployee.ItemsSource = employees;

            }
            else
            {
                //   return false;
            }







        }
    }
}
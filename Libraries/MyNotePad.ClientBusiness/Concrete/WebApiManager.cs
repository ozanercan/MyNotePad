using MyNotePad.ClientBusiness.Abstract;
using MyNotePad.Core.Business.Results.Abstract;
using MyNotePad.Core.Business.Results.Concrete;
using MyNotePad.Entities.DataTransferObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyNotePad.ClientBusiness.Concrete
{
    public class WebApiManager : IWebApiService
    {
        string url = "https://localhost:44325/";
        string route = "api/notes/";
        HttpClient httpClient = new HttpClient();
        public async Task<IBusinessResult> CreateAsync(NoteCreateDto noteCreateDto)
        {
            StringContent httpContent = new StringContent(JsonConvert.SerializeObject(noteCreateDto), Encoding.UTF8, "application/json");
            string lastUrl = url + route + "create";
            IBusinessResult result;
            using (HttpResponseMessage response = await httpClient.PostAsync(lastUrl, httpContent))
            {
                //response.EnsureSuccessStatusCode();
                var apiResult = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<BusinessResult>(apiResult);
            }
            return result;

        }

        public async Task<IBusinessDataResult<List<NoteDto>>> GetNoteDtosAsync()
        {
            string lastUrl = url + route + "list";
            IBusinessDataResult<List<NoteDto>> dataResult;
            using (HttpResponseMessage response = await httpClient.GetAsync(lastUrl))
            {
                var apiResult = await response.Content.ReadAsStringAsync();
                dataResult = JsonConvert.DeserializeObject<BusinessDataResult<List<NoteDto>>>(apiResult);
            }
            return dataResult;
        }
    }
}

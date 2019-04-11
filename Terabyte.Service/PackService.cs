using SERVICE.PATTERN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terabyte.Domain.Entities;
using Terabyte.Data.Infrastructure;
using Terabyte.Data;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace Terabyte.Service
{
    public class PackService : Service<Pack>, IPackService
    {

        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);
        public PackService() : base(utk)
        {
        }

        MyContext dataContext = new MyContext();
       
        
        public void Commit()
        {
            utk.Commit();
        }

        public void CreatePack(Pack p)
        {
           // utk.getRepository<Pack>().Add(p);
        }

        public void Dispose()
        {
            utk.Dispose();
        }



        //public async Task<Pack> getPackById(int id)
        //{
        //    var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:63238/PM_Dashboard/api/Claims/get/" + id.ToString());
        //    var client = new HttpClient();
        //    var response = await client.SendAsync(request);
        //    var byteArray = response.Content.ReadAsByteArrayAsync().Result;
        //    var result = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
        //    var jsonObjects = JsonConvert.DeserializeObject<JObject>(result);
        //    var list = jsonObjects.Value<JObject>().ToObject<Pack>();
        //    // regler le problem d'object 
        //    return list;

        //}

        //public async Task<bool> Update(Pack p)
        //{
        //    var request = new HttpRequestMessage(HttpMethod.Put, "http://localhost:63238/PM_Dashboard/api/Claims/update");
        //    var client = new HttpClient();
        //    var json = JsonConvert.SerializeObject(p);
        //    request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        //    var response = await client.SendAsync(request);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return await System.Threading.Tasks.Task.FromResult(true);
        //    }

        //    // regler le problem d'object 
        //    return await System.Threading.Tasks.Task.FromResult(false);
        //}
        public List<Pack> getMandates()
        {
            IEnumerable<Pack> m = (from Packs in utk.GetRepositoryBase<Pack>().GetAll()
                                        select Packs);
            List<Pack> list = m.ToList<Pack>();
            return list;
        }
    }
}

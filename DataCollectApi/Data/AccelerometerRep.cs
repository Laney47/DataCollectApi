using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DataCollectApi.Data
{
    public class AccelerometerRep : DocumentDb
    {
        //each repo can specify it's own database and document collection
        public AccelerometerRep() : base("SportsDb", "Accelerometer") { }

        public Task<List<AccelerometerData>> GetAccDataAsync()
        {
            return Task<List<AccelerometerData>>.Run(() =>
                Client.CreateDocumentQuery<AccelerometerData>(Collection.DocumentsLink)
                .ToList());
        }

        public Task<AccelerometerData> GetAccDataByIdAsync(string id)
        {
            return Task<AccelerometerData>.Run(() =>
                Client.CreateDocumentQuery<AccelerometerData>(Collection.DocumentsLink)
                .Where(p => p.ID == id)
                .AsEnumerable()
                .FirstOrDefault());
        }

        public Task<ResourceResponse<Document>> CreateAccData(AccelerometerData accdata)
        {
            return Client.CreateDocumentAsync(Collection.DocumentsLink, accdata);
        }

        public Task<ResourceResponse<Document>> UpdateAccDataAsync(AccelerometerData accdata)
        {
            var doc = Client.CreateDocumentQuery<Document>(Collection.DocumentsLink)
                .Where(d => d.Id == accdata.ID)
                .AsEnumerable() // why the heck do we need to do this??
                .FirstOrDefault();

            return Client.ReplaceDocumentAsync(doc.SelfLink, accdata);
        }

        public Task<ResourceResponse<Document>> DeleteAccDataAsync(string id)
        {
            var doc = Client.CreateDocumentQuery<Document>(Collection.DocumentsLink)
                .Where(d => d.Id == id)
                .AsEnumerable()
                .FirstOrDefault();

            return Client.DeleteDocumentAsync(doc.SelfLink);
        }

        
    }
}

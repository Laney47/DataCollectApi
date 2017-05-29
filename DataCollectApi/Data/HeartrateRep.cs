using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DataCollectApi.Data
{
    public class HeartrateRep : DocumentDb
    {
        //each repo can specify it's own database and document collection
        public HeartrateRep() : base("SportsDb", "Heartrate") { }

        public Task<List<HeartrateData>> GetHeartrateAsync()
        {
            return Task<List<HeartrateData>>.Run(() =>
                Client.CreateDocumentQuery<HeartrateData>(Collection.DocumentsLink)
                .ToList());
        }

        public Task<List<HeartrateData>> GetHeartrateByOwnerAsync(string owner)
        {
            return Task<LocationData>.Run(() =>
                Client.CreateDocumentQuery<HeartrateData>(Collection.DocumentsLink)
                .Where(p => p.Owner == owner)
                .AsEnumerable().ToList());
        }

        public Task<HeartrateData> GetHeartrateByIdAsync(string id)
        {
            return Task<HeartrateData>.Run(() =>
                Client.CreateDocumentQuery<HeartrateData>(Collection.DocumentsLink)
                .Where(p => p.ID == id)
                .AsEnumerable()
                .FirstOrDefault());
        }

        public Task<ResourceResponse<Document>> CreateHeartrate(HeartrateData heartrate)
        {
            return Client.CreateDocumentAsync(Collection.DocumentsLink, heartrate);
        }

        public Task<ResourceResponse<Document>> UpdateHeartrateAsync(HeartrateData heartrate)
        {
            var doc = Client.CreateDocumentQuery<Document>(Collection.DocumentsLink)
                .Where(d => d.Id == heartrate.ID)
                .AsEnumerable() // why the heck do we need to do this??
                .FirstOrDefault();

            return Client.ReplaceDocumentAsync(doc.SelfLink, heartrate);
        }

        public Task<ResourceResponse<Document>> DeleteHeartrateAsync(string id)
        {
            var doc = Client.CreateDocumentQuery<Document>(Collection.DocumentsLink)
                .Where(d => d.Id == id)
                .AsEnumerable()
                .FirstOrDefault();

            return Client.DeleteDocumentAsync(doc.SelfLink);
        }


    }
}

using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DataCollectApi.Data
{
    public class LocationRep : DocumentDb
    {
        //each repo can specify it's own database and document collection
        public LocationRep() : base("SportsDb", "Location") { }

        public Task<List<LocationData>> GetLocationAsync()
        {
            return Task<List<LocationData>>.Run(() =>
                Client.CreateDocumentQuery<LocationData>(Collection.DocumentsLink)
                .ToList());
        }

        public Task<LocationData> GetLocationByOwnerAsync(string owner)
        {
            return Task<LocationData>.Run(() =>
                Client.CreateDocumentQuery<LocationData>(Collection.DocumentsLink)
                .Where(p => p.Owner == owner)
                .AsEnumerable()
                .FirstOrDefault());
        }

        public Task<LocationData> GetLocationByIdAsync(string id)
        {
            return Task<LocationData>.Run(() =>
                Client.CreateDocumentQuery<LocationData>(Collection.DocumentsLink)
                .Where(p => p.ID == id)
                .AsEnumerable()
                .FirstOrDefault());
        }

        public Task<ResourceResponse<Document>> CreateLocation(LocationData location)
        {
            return Client.CreateDocumentAsync(Collection.DocumentsLink, location);
        }

        public Task<ResourceResponse<Document>> UpdateLocationAsync(LocationData location)
        {
            var doc = Client.CreateDocumentQuery<Document>(Collection.DocumentsLink)
                .Where(d => d.Id == location.ID)
                .AsEnumerable() // why the heck do we need to do this??
                .FirstOrDefault();

            return Client.ReplaceDocumentAsync(doc.SelfLink, location);
        }

        public Task<ResourceResponse<Document>> DeleteLocationAsync(string id)
        {
            var doc = Client.CreateDocumentQuery<Document>(Collection.DocumentsLink)
                .Where(d => d.Id == id)
                .AsEnumerable()
                .FirstOrDefault();

            return Client.DeleteDocumentAsync(doc.SelfLink);
        }

        
    }
}
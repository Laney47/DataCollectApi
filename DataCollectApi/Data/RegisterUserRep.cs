using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DataCollectApi.Data
{
    public class RegisterUserRep : DocumentDb
    {
        //each repo can specify it's own database and document collection
        public RegisterUserRep() : base("SportsDb", "User") { }

        public Task<List<RegisterUserData>> GetUsersAsync()
        {
            return Task<List<RegisterUserData>>.Run(() =>
                Client.CreateDocumentQuery<RegisterUserData>(Collection.DocumentsLink)
                .ToList());
        }

        public Task<RegisterUserData> GetUserByMailAsync(string mail, string password)
        {
            return Task<RegisterUserData>.Run(() =>
                Client.CreateDocumentQuery<RegisterUserData>(Collection.DocumentsLink)
                .Where(p => p.email == mail && p.password == password)
                .AsEnumerable().FirstOrDefault());
        }

        public Task<RegisterUserData> CheckIfUserExistAsync(string mail)
        {
            return Task<RegisterUserData>.Run(() =>
                Client.CreateDocumentQuery<RegisterUserData>(Collection.DocumentsLink)
                .Where(p => p.email == mail)
                .AsEnumerable().FirstOrDefault());
        }

        public Task<RegisterUserData> GetUserByIdAsync(string id)
        {
            return Task<RegisterUserData>.Run(() =>
                Client.CreateDocumentQuery<RegisterUserData>(Collection.DocumentsLink)
                .Where(p => p.ID == id)
                .AsEnumerable()
                .FirstOrDefault());
        }

        public Task<ResourceResponse<Document>> ReigsterUser(RegisterUserData user)
        {
            return Client.CreateDocumentAsync(Collection.DocumentsLink, user);
        }

        public Task<ResourceResponse<Document>> UpdateUserAsync(RegisterUserData user)
        {
            var doc = Client.CreateDocumentQuery<Document>(Collection.DocumentsLink)
                .Where(d => d.Id == user.ID)
                .AsEnumerable() // why the heck do we need to do this??
                .FirstOrDefault();

            return Client.ReplaceDocumentAsync(doc.SelfLink, user);
        }

        public Task<ResourceResponse<Document>> DeleteUserAsync(string id)
        {
            var doc = Client.CreateDocumentQuery<Document>(Collection.DocumentsLink)
                .Where(d => d.Id == id)
                .AsEnumerable()
                .FirstOrDefault();

            return Client.DeleteDocumentAsync(doc.SelfLink);
        }


    }
}

using API.Repository.Models;

namespace API.Interfaces.RepositoryInterfaces
{
    public interface IAttachmentRepository
    {
        
            Task<List<Attachment>> GetAllAttachmentsAsync();
            Task<Attachment> GetAttachmentByIdAsync(int id);
            Task<int> AddAttachmentAsync(Attachment attachment);
            Task<bool> UpdateAttachmentAsync(Attachment attachment);
            Task<bool> DeleteAttachmentAsync(int id);
        

    }
}

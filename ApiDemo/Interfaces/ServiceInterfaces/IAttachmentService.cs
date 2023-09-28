using API.Repository.Models;

namespace API.Interfaces.ServiceInterfaces
{
    public interface IAttachmentService
    {
        Task<List<Attachment>> GetAllAttachmentsAsync();
        Task<Attachment> GetAttachmentByIdAsync(int id);
        Task<int> AddAttachmentAsync(Attachment attachment);
        Task<bool> UpdateAttachmentAsync(Attachment attachment);
        Task<bool> DeleteAttachmentAsync(int id);
    }
}

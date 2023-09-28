using API.Interfaces.RepositoryInterfaces;
using API.Interfaces.ServiceInterfaces;
using API.Repository.Models;

namespace API.Services
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IAttachmentRepository _repository;

        public AttachmentService(IAttachmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Attachment>> GetAllAttachmentsAsync()
        {
            return await _repository.GetAllAttachmentsAsync();
        }

        public async Task<Attachment> GetAttachmentByIdAsync(int id)
        {
            return await _repository.GetAttachmentByIdAsync(id);
        }

        public async Task<int> AddAttachmentAsync(Attachment attachment)
        {
            return await _repository.AddAttachmentAsync(attachment);
        }

        public async Task<bool> UpdateAttachmentAsync(Attachment attachment)
        {
            return await _repository.UpdateAttachmentAsync(attachment);
        }

        public async Task<bool> DeleteAttachmentAsync(int id)
        {
            return await _repository.DeleteAttachmentAsync(id);
        }
    }

}

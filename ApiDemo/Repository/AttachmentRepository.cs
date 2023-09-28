using API.Interfaces.RepositoryInterfaces;
using API.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class AttachmentRepository : IAttachmentRepository
    {
        private readonly KCP_DbContext _context;

        public AttachmentRepository(KCP_DbContext context)
        {
            _context = context;
        }

        public async Task<List<Attachment>> GetAllAttachmentsAsync()
        {
            return await _context.Attachments.ToListAsync();
        }

        public async Task<Attachment> GetAttachmentByIdAsync(int id)
        {
            return await _context.Attachments.FindAsync(id);
        }

        public async Task<int> AddAttachmentAsync(Attachment attachment)
        {
            _context.Attachments.Add(attachment);
            await _context.SaveChangesAsync();
            return attachment.AttachmentId;
        }

        public async Task<bool> UpdateAttachmentAsync(Attachment attachment)
        {
            _context.Entry(attachment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAttachmentAsync(int id)
        {
            var attachment = await _context.Attachments.FindAsync(id);
            if (attachment == null) return false;
            _context.Attachments.Remove(attachment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

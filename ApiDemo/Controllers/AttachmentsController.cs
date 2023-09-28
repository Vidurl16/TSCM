using API.Interfaces.ServiceInterfaces;
using API.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentsController : ControllerBase
    {
        private readonly IAttachmentService _attachmentService;

        public AttachmentsController(IAttachmentService attachmentService)
        {
            _attachmentService = attachmentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Attachment>>> GetAllAttachments()
        {
            try
            {
                var attachments = await _attachmentService.GetAllAttachmentsAsync();
                return Ok(attachments);
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or return an error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{AttachmentId}")]
        public async Task<ActionResult<Attachment>> GetAttachment(int attachmentId)
        {
            try
            {
                var attachment = await _attachmentService.GetAttachmentByIdAsync(attachmentId);

                if (attachment == null)
                {
                    return NotFound();
                }

                return Ok(attachment);
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or return an error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Attachment>> CreateAttachment(Attachment attachment)
        {
            try
            {
                var newAttachmentId = await _attachmentService.AddAttachmentAsync(attachment);

                // Generate the URL for the newly created resource
                var location = Url.Action("GetAttachment", new { AttachmentId = newAttachmentId });
                return Created(location, attachment);
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or return an error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{AttachmentId}")]
        public async Task<IActionResult> UpdateAttachment(int attachmentId, Attachment updatedAttachment)
        {
            try
            {
                var success = await _attachmentService.UpdateAttachmentAsync(updatedAttachment);

                if (!success)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or return an error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{AttachmentId}")]
        public async Task<IActionResult> DeleteAttachment(int attachmentId)
        {
            try
            {
                var success = await _attachmentService.DeleteAttachmentAsync(attachmentId);

                if (!success)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or return an error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

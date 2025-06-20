using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ZottaEmpNet.Controllers
{

[Route("api/[controller]")]
[ApiController]
public class PhotoUploadController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> UploadPhoto([FromBody] string imageDataUrl)
    {
        if (string.IsNullOrEmpty(imageDataUrl))
        {
            return BadRequest("Image data is empty.");
        }

        try
        {
            // Remove the data URL prefix (e.g., "data:image/png;base64,")
            string base64Image = imageDataUrl.Split(',')[1];

            // Convert Base64 to byte array
            byte[] imageBytes = Convert.FromBase64String(base64Image);

            // Define the path to save the photos (ensure this directory exists)
            string photosFolder = Path.Combine("wwwroot", "photos");
            if (!Directory.Exists(photosFolder))
            {
                Directory.CreateDirectory(photosFolder);
            }

            // Generate a unique filename
            string fileName = $"{Guid.NewGuid()}.png";
            string filePath = Path.Combine(photosFolder, fileName);

            // Save the file asynchronously
            await System.IO.File.WriteAllBytesAsync(filePath, imageBytes);

            // Return the relative path
            string relativePath = $"/photos/{fileName}";
            return Ok(new { photoPath = relativePath });
        }
        catch (FormatException)
        {
            return BadRequest("Invalid Base64 string.");
        }
        catch (Exception ex)
        {
            // Log the error (you might want a more robust logging mechanism)
            Console.WriteLine($"Error uploading photo: {ex.Message}");
            return StatusCode(500, "Error uploading photo.");
        }
    }
}
}
using Microsoft.Maui.Media;

namespace ToDoApp.Mobile.Services;
using Microsoft.Maui.Media;

public class CameraService
{
	public async Task<string?> TakePhotoAsync()
	{
		try
		{
			if (MediaPicker.Default.IsCaptureSupported)
			{
				var photo = await MediaPicker.CapturePhotoAsync();
				if (photo != null)
				{
					using var stream = await photo.OpenReadAsync();
					using var memoryStream = new MemoryStream();
					await stream.CopyToAsync(memoryStream);
					var imageBytes = memoryStream.ToArray();
					var base64Image = Convert.ToBase64String(imageBytes);
                    
					return $"data:image/jpeg;base64,{base64Image}"; // ✅ Base64 format for Blazor
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine($"❌ Error: {ex.Message}");
		}
		return null;
	}
}
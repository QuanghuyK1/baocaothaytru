using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WEB_TTTN.InputBody;
using WEB_TTTN.Models;
using WEB_TTTN.Repositories;

namespace WEB_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineRepository _medicineRepository;

        public MedicineController(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        [HttpGet("GetList")]
        [Authorize]
        public async Task<IActionResult> ListMedicine()
        {
            try
            {
                var medicines = await _medicineRepository.ListMedicine();
                return Ok(medicines);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving medicines.");
            }
        }
        [HttpGet("GetListStatus")]
        [Authorize]
        public async Task<IActionResult> ListMedicineStatus()
        {
            try
            {

                var medicines = await _medicineRepository.ListMedicineStartus();
                return Ok(medicines);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving medicines.");
            }
        }
        [HttpGet("Get/{id}")]
        [Authorize]
        public async Task<IActionResult> GetMedicineById([FromRoute] int id)
        {
            try
            {
                var medicine = await _medicineRepository.GetMedicineById(id);
                if (medicine == null)
                {
                    return NotFound();
                }
                return Ok(medicine);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving medicine.");
            }
        }

        [HttpPost("Ins")]
        [Authorize]
        public async Task<IActionResult> InsertMedicine([FromForm] InputMedicine input, [FromForm] IFormFile image)
        {
            try
            {
                if (image == null || image.Length == 0)
                {
                    return BadRequest("No image uploaded");
                }

                // Lưu ảnh vào thư mục trên server
                var imagePath = "D:\\TTTN\\WEB_TTTN\\WEB_TTTN\\ImagePath\\"; // Thay đổi đường dẫn tới thư mục lưu ảnh
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                var fullPath = Path.Combine(imagePath, uniqueFileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                var medicine = new MedicineModels
                {
                    Name = input.MedName,
                    Usedate = input.Usedate,
                    HandlePrice = input.HandlePrice,
                    Price = input.Price,
                    Img = fullPath,
                    Description = input.Description,
                    Startus = input.Startus,
                    Count = input.Count,
                    Getdate = input.Getdate,
                    nationname = input.nationname,
                };
                await _medicineRepository.InsertMedicine(medicine);
                return Ok("Medicine inserted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while inserting medicine.");
            }
        }

        [HttpPost("Up/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateMedicine([FromRoute] int id, [FromForm] InputMedicine input, [FromForm] IFormFile image)
        {
            try
            {
                if (image == null || image.Length == 0)
                {
                    return BadRequest("No image uploaded");
                }

                // Lưu ảnh vào thư mục trên server
                var imagePath = "D:\\TTTN\\WEB_TTTN\\WEB_TTTN\\ImagePath\\"; // Thay đổi đường dẫn tới thư mục lưu ảnh
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                var fullPath = Path.Combine(imagePath, uniqueFileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                var medicine = new MedicineModels
                {
                    Name = input.MedName,
                    Usedate = input.Usedate,
                    HandlePrice = input.HandlePrice,
                    Price = input.Price,
                    Img = fullPath,
                    Description = input.Description,
                    Startus = input.Startus,
                    Count = input.Count,
                    Getdate = input.Getdate,
                    nationname = input.nationname,
                };
                await _medicineRepository.UpdateMedicine(medicine, id);
                return Ok("Medicine updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating medicine.");
            }
        }

        [HttpDelete("Del/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteMedicine([FromRoute] int id)
        {
            try
            {
                
                await _medicineRepository.DeleteMedicine(id);
                return Ok("Medicine deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting medicine.");
            }
        }
    }
}

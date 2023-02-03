using BE_CRUDPhonebook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_CRUDPhonebook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonebookController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PhonebookController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            try
            {
                List<Phonebook> Phonelist = await _context.Phonebook.ToListAsync();
                return Ok(Phonelist);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var phonenumber = await _context.Phonebook.FindAsync(id);

                if (phonenumber == null)
                {
                    return NotFound();
                }

                

                return Ok(phonenumber);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);  
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var phonenumber = await _context.Phonebook.FindAsync (id);

                if (phonenumber == null)
                {
                    return NotFound();
                }

                _context.Phonebook.Remove(phonenumber);
                await _context.SaveChangesAsync();

               // await _mascotaRepository.DeleteMascota(phonenumber);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Phonebook phonebook)
        {
            try
            {
                // var phonenumber = await _context.Phonebook.FindAsync(id); ;

                phonebook.Date = DateTime.Now;
                _context.Add(phonebook);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Get", new {id = phonebook.Id}, phonebook);

                // phonebook = await _mascotaRepository.AddMascota(mascota);

                // var mascotaItemDto = _mapper.Map<MascotaDTO>(mascota);

               // return CreatedAtAction("Get", new { id = phonebook.Id }, phonebook);

                // return CreatedAtAction("Get", new { id = mascotaItemDto.Id }, mascotaItemDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Phonebook phonebook)
        {
            try
            {
               // var phonenumber = _mapper.Map<Mascota>(mascotaDto);

                if (id != phonebook.Id)
                {
                    return BadRequest();
                }

                var phonenumberItem = await _context.Phonebook.FindAsync(id);
               // var phonenumberItem = await _phonenumberRepository.GetPhonenumber(id);

                if (phonenumberItem == null)
                {
                    return NotFound();
                }
                   phonenumberItem.FirstName = phonebook.FirstName;
                    phonenumberItem.LastName = phonebook.LastName;
                    phonebook.PhoneNumber = phonebook.PhoneNumber;
                    phonebook.TextComments = phonebook.TextComments;


                  _context.Update(phonenumberItem);
              //  await _mascotaRepository.UpdateMascota(mascota);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

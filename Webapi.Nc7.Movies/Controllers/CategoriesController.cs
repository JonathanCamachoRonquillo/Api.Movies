using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Webapi.Nc7.Movies.Models;
using Webapi.Nc7.Movies.Models.Dtos;
using Webapi.Nc7.Movies.Repository.IRepository;

namespace Webapi.Nc7.Movies.Controllers
{
    [ApiController]
    //[Route("api/[controller]")] Op1
    [Route("api/categorias")]
    public class CategoriesController : ControllerBase
    {
        private readonly IRepositoryCategory _repCat;
        private readonly IMapper _mapper;
        public CategoriesController(IRepositoryCategory repCat, IMapper mapper)
        {
            _repCat = repCat;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCategories()
        {
            var lstCategories = _repCat.GetCategories();
            var lstCategoriesDto = new List<CategoryDto>();

            foreach (var cat in lstCategories)
            {
                lstCategoriesDto.Add(_mapper.Map<CategoryDto>(cat));
            }

            return Ok(lstCategoriesDto);
        }

        [HttpGet("{categoriaId:int}", Name = "GetCategory")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCategory(int categoriaId)
        {
            var category = _repCat.GetCategoryById(categoriaId);

            if (category == null)
            {
                return NotFound();
            }

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return Ok(categoryDto);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CategoryDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateNewCategory([FromBody] NewCategoryDto newCategoryDto) {

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (newCategoryDto == null) {
                return BadRequest(ModelState);
            }

            if (_repCat.ExistCategory(newCategoryDto.Name))
            {
                ModelState.AddModelError("", $"La categoria {newCategoryDto.Name} ya existe");
                return StatusCode(404, ModelState);
            }

            var category = _mapper.Map<Category>(newCategoryDto);

            if (!_repCat.CreateCategory(category)) {
                ModelState.AddModelError("", $"Ocurrio un error al crear la categoria {newCategoryDto.Name}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetCategory", new { categoriaId = category.Id }, category);
        }

    }
}

using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using CleanArchMVC.Domain.Interfaces.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Service
{
    public class CategoryServiceV2 : ICategoryService
    {
        private readonly IRepositoryHandler<Category> _repository;
        private readonly IMapper _mapper;

        public CategoryServiceV2(IRepositoryHandler<Category> repository, IMapper mapper)
        {

            this._repository = repository;
            this._mapper = mapper;

        }

        public async Task<CategoryDTO> GetById(int? idCategory)
        {
            var categoryEntity = await _repository.GetById((int)idCategory);
            if (categoryEntity == null) return null; //Arrumar

            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesEntity = await _repository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }
        public async Task Add(CategoryDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _repository.Create(categoryEntity);
        }
        public async Task Remove(int? id )
        {
            var categoryEntity =  await _repository.GetById((int)id);
            await _repository.Remove(categoryEntity);
        }
        public async Task Update(CategoryDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _repository.Update(categoryEntity);
        }
    }
}

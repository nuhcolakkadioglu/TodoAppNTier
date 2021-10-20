using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.TodoAppNTier.Business.Interfaces;
using Udemy.TodoAppNTier.Business.ValidationRules;
using Udemy.TodoAppNTier.DataAccess.UnitOfWork;
using Udemy.TodoAppNTier.Dtos.Interfaces;
using Udemy.TodoAppNTier.Dtos.WorkDtos;
using Udemy.TodoAppNTier.Entities.Domains;

namespace Udemy.TodoAppNTier.Business.Services
{
    public class WorkService : IWorkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public WorkService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Create(WorkCreateDto model)
        {

            var valid = new WorkCreateDtoValidator();
            var validationResult = valid.Validate(model);
            if (validationResult.IsValid)
            {
                await _unitOfWork.GetRepository<Work>().CreateAsync(_mapper.Map<Work>(model));

                await _unitOfWork.SaveChangesAsync();
            }
        
        }

        public async Task<List<WorkListDto>> GetAll()
        {
            var list = await _unitOfWork.GetRepository<Work>().GetAllAsync();



            return _mapper.Map<List<WorkListDto>>(list);
        }

        public async Task<IDto> GetById<IDto>(int id)
        {
            var work = await _unitOfWork.GetRepository<Work>().GetByFilter(m => m.Id == id);
            return _mapper.Map<IDto>(work);
        }

        public async Task Remove(int id)
        {
            _unitOfWork.GetRepository<Work>().RemoveAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Update(WorkUpdateDto model)
        {
            _unitOfWork.GetRepository<Work>().UpdateAsync(_mapper.Map<Work>(model));
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

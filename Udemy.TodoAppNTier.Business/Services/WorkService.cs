using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.TodoAppNTier.Business.Interfaces;
using Udemy.TodoAppNTier.DataAccess.UnitOfWork;
using Udemy.TodoAppNTier.Dtos.WorkDtos;
using Udemy.TodoAppNTier.Entities.Domains;

namespace Udemy.TodoAppNTier.Business.Services
{
    public class WorkService : IWorkService
    {
        private readonly IUnitOfWork _unitOfWork;
        public WorkService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Create(WorkCreateDto model)
        {
            await _unitOfWork.GetRepository<Work>().CreateAsync(new Work
            {
                Definition = model.Definition,
                IsCompleted = model.IsCompleted
            });

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<WorkListDto>> GetAll()
        {
            var list = await _unitOfWork.GetRepository<Work>().GetAllAsync();
            var mapperList = new List<WorkListDto>();

            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    mapperList.Add(new()
                    {
                        Definition = item.Definition,
                        IsCompleted = item.IsCompleted,
                        Id = item.Id
                    });
                }
            }
            return mapperList;
        }

        public async Task<WorkListDto> GetById(int id)
        {
            var work = await _unitOfWork.GetRepository<Work>() .GetByFilter(m=>m.Id== id);
            return new WorkListDto
            {
                Definition = work.Definition,
                Id = work.Id,
                IsCompleted = work.IsCompleted
            };
        }

        public async Task Remove(object id)
        {
            var work = await _unitOfWork.GetRepository<Work>().GetByIdAsync(id);
            _unitOfWork.GetRepository<Work>().RemoveAsync(work);
        }

        public async Task Update(WorkUpdateDto model)
        {
             _unitOfWork.GetRepository<Work>().UpdateAsync(new()
            {
                Definition = model.Definition,
                Id = model.Id,
                IsCompleted = model.IsCompleted
            });

            await _unitOfWork.SaveChangesAsync();
        }
    }
}

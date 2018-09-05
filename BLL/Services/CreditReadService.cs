using BLL.Interfaces;
using Cross_Cutting.Mapping;
using DAL.Interfaces;
using Models.Business;
using Models.BusinessModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CreditReadService : IReadService<Credit>
    {
        private readonly CustomMapper<CreditEntity, Credit> _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreditReadService(IUnitOfWork uow)
        {
            _mapper = new CustomMapper<CreditEntity, Credit>();
            _unitOfWork = uow;
        }

        public async Task<IEnumerable<Credit>> GetAllCredits() => _mapper.MapCollection(await _unitOfWork.ReadCredits.GetAll());

        public async Task<Credit> GetCreditById(int id) => _mapper.Map(await _unitOfWork.ReadCredits.Get(id));
    }
}

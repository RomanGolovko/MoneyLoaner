using BLL.Interfaces;
using Cross_Cutting.Mapping;
using DAL.Interfaces;
using Models.Business;
using Models.BusinessModels;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CreditWriteService : IWriteService<Credit>
    {
        private readonly CustomMapper<Credit, CreditEntity> _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreditWriteService(IUnitOfWork uow)
        {
            _mapper = new CustomMapper<Credit, CreditEntity>();
            _unitOfWork = uow;
        }

        public async Task UpsertCredit(Credit credit)
        {
            if (credit.Id <= 0)
                await _unitOfWork.WriteCredits.Create(_mapper.Map(credit));
            else
                await _unitOfWork.WriteCredits.Update(_mapper.Map(credit));

            await _unitOfWork.Save();
        }

        public async Task RemoveCredit(int id)
        {
            if (id <= 0)
                return;

            await _unitOfWork.WriteCredits.Delete(id);
            await _unitOfWork.Save();
        }
    }
}

using ProjectAPI.ViewModel;

namespace ProjectAPI.Interfaces
{
    public interface IUserReg
    {
       Task<long> SaveUser(VMUserReg vMUserReg);
    }
}

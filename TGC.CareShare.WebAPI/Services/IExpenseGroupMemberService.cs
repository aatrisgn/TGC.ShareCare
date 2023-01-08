namespace TGC.CareShare.WebAPI.Services
{
    public interface IExpenseGroupMemberService
    {
        Task AddProfileToExpenseGroup(Guid profileId, Guid id);
    }
}

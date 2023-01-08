namespace TGC.CareShare.WebAPI.Models.DataModels
{
    public class ExpenseGroupMember : DTOBaseClass
    {
        public ExpenseGroupMember()
        {

        }

        public decimal Balance { get;set;}
        public decimal Paid { get;set;}
        public Guid ExpenseGroupId { get;set;}
        public ExpenseGroup ExpenseGroup { get; set; }
        public Guid ProfileId { get; set; }
        public Profile Profile { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}
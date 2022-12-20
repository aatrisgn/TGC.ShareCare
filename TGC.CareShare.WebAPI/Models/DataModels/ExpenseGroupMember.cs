namespace TGC.CareShare.WebAPI.Models.DataModels
{
    public class ExpenseGroupMember : DTOBaseClass
    {
        public decimal Balance { get;set;}
        public decimal Paid { get;set;}
        public ICollection<Expense> Expenses { get; set; }
    }
}

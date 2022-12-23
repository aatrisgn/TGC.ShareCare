namespace TGC.CareShare.WebAPI.Models.DataModels
{
    public class ExpenseGroup : DTOBaseClass
    {
        public string Name { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<ExpenseGroupMember> ExpenseGroupMembers { get; set; }

        internal void Deactivate()
        {
            this.Active = false;
        }
    }
}

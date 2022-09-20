using System;
using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPIWalletAPI.Models.Employee;

namespace EPIWalletAPI.Models
{
    public class ExpenseRequestRepository:IExpenseRequestRepository
    {

        private readonly AppDbContext _appDbContext;


        public ExpenseRequestRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public void Add<T>(T entity) where T : class
        {
            _appDbContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _appDbContext.Remove(entity);
        }



        public async Task<IEnumerable<ExpenseRequest>> Search(int id,int approvalstatus,int employee)
        {
            IQueryable<ExpenseRequest> query = _appDbContext.ExpenseRequests;

            if (id!=0) // if there is anything
            {
                query = query.Where((e => e.VendorID.Equals(id) && e.ApprovalID.Equals(approvalstatus) || e.totalEstimate.Equals(id) && e.ApprovalID.Equals(approvalstatus) || e.TypeID.Equals(id) && e.ApprovalID.Equals(approvalstatus) || e.EmployeeID.Equals(id)&&e.ApprovalID.Equals(approvalstatus) || e.ExpenseID.Equals(id) && e.ApprovalID.Equals(approvalstatus)));
                query = query.Where(e => e.EmployeeID.Equals(employee));
                
            }

            return await query.ToListAsync();
        }





        public async Task<IEnumerable<ExpenseRequest>> Search2(int id, int approvalstatus)
        {
            IQueryable<ExpenseRequest> query = _appDbContext.ExpenseRequests;

            if (id != 0) // if there is anything
            {
                query = query.Where((e => e.VendorID.Equals(id) && e.ApprovalID.Equals(approvalstatus) || e.totalEstimate.Equals(id) && e.ApprovalID.Equals(approvalstatus) || e.TypeID.Equals(id) && e.ApprovalID.Equals(approvalstatus) || e.EmployeeID.Equals(id) && e.ApprovalID.Equals(approvalstatus)));
            }

            return await query.ToListAsync();
        }


        //return 
        public async Task<ExpenseRequest[]> getUserPendingExpenseRequestsAsync(int id)
        {
            IQueryable<ExpenseRequest> query = _appDbContext.ExpenseRequests.Where(c=>c.ApprovalID==1);
            query = query.Where(c => c.EmployeeID == id);
            return await query.ToArrayAsync();
        }

        public async Task<ExpenseRequest[]> getUserRejectedExpenseRequestsAsync(int id)
        {
            IQueryable<ExpenseRequest> query = _appDbContext.ExpenseRequests.Where(c => c.ApprovalID == 4);
            query = query.Where(c => c.EmployeeID == id);
            return await query.ToArrayAsync();
        }



        //return expenses for all users to managers that are awaiting approval
        public async Task<ExpenseRequest[]> getPendingExpenseRequestsAsync()
        {
            IQueryable<ExpenseRequest> query = _appDbContext.ExpenseRequests.Where(c => c.ApprovalID == 1);
            return await query.ToArrayAsync();

        }

        public async Task<ExpenseRequest[]> getAllPaidExpenseRequestsAsync()
        {
            IQueryable<ExpenseRequest> query = _appDbContext.ExpenseRequests.Where(c => c.ApprovalID == 3);
            return await query.ToArrayAsync();

        }





        //return expenses for that user that are awaiting payment
        public async Task<ExpenseRequest[]> getUserApprovedExpenseRequestsAsync(int id)
        {
            IQueryable<ExpenseRequest> query = _appDbContext.ExpenseRequests.Where(c => c.ApprovalID == 2);
            query = query.Where(c => c.EmployeeID == id);
            return await query.ToArrayAsync();
        }




        //return all expenses awaiting payment to creditors 
        public async Task<ExpenseRequest[]> getApprovedExpenseRequestsAsync()
        {
            IQueryable<ExpenseRequest> query = _appDbContext.ExpenseRequests.Where(c => c.ApprovalID == 2);
            return await query.ToArrayAsync();
        }




        public async Task<ExpenseItem[]> GetExpenseItemsByID(int id)
        {
            IQueryable<ExpenseItem> query = _appDbContext.ExpenseItems.Where(c => c.ExpenseRequestID == id);
            return await query.ToArrayAsync();
        }





        //return all thhe paid expense requests for that user
        public async Task<ExpenseRequest[]> getUserPaidExpenseRequestsAsync(int id)
        {
            IQueryable<ExpenseRequest> query = _appDbContext.ExpenseRequests.Where(c => c.ApprovalID == 3);
            query = query.Where(c => c.EmployeeID == id);
            return await query.ToArrayAsync();
        }



        public async Task<ExpenseLine[]> getExpenseLineByTopUp(int id)
        {
            IQueryable<ExpenseLine> query = _appDbContext.expenseLines.Where(c =>c.ExpenseLineID  == id);
            return await query.ToArrayAsync();
        }







        public async Task<ExpenseRequest> getExpenseRequestAsync(int id)
        {
            IQueryable<ExpenseRequest> query = _appDbContext.ExpenseRequests.Where(c => c.ExpenseID == id);
            return await query.FirstOrDefaultAsync();
        }


        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public async Task<ExpenseRequest[]> getAllRequests()
        {
            IQueryable<ExpenseRequest> query = _appDbContext.ExpenseRequests;
            return await query.ToArrayAsync();
        }

        public async Task<ExpenseRequest[]> getExpenseRequestForEmployee(int EmployeeID)
        {
            IQueryable<ExpenseRequest> query = _appDbContext.ExpenseRequests.Where(c => c.EmployeeID == EmployeeID && c.ApprovalID == 2);
            return await query.ToArrayAsync();















        }




















    }
}

using ClientsProject.DAL.EF;
using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClientsProject.DAL.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IDbContextFactory<ClientAccountingContext> _databaseFactory;
        public ReviewService(IDbContextFactory<ClientAccountingContext> databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public async Task AddReview(Review review) 
        {
            using var factorty = await _databaseFactory.CreateDbContextAsync();
            factorty.Reviews.Add(review); factorty.SaveChanges();
        }

        public async Task<Review?> GetReview(int id_product, int id_user)
        {
            using var factorty = await _databaseFactory.CreateDbContextAsync();
            return await factorty.Reviews.Where(i => i.IdProduct == id_product && i.IdClient == id_user).FirstOrDefaultAsync();
        }
    }
}

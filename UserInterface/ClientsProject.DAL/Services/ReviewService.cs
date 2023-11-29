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
            var review_temp = factorty.Reviews.Add(review); factorty.SaveChanges();

            var product = await factorty.Products.Where(s => s.IdProduct == review_temp.Entity.IdProduct).FirstOrDefaultAsync();
            var countViewRatingClient = factorty.Reviews.Where(s => s.IdProduct == product!.IdProduct).Select(x => x.Rating).ToList();
            var rating = 0;
            foreach(var item in countViewRatingClient) { rating += item; }
            product!.Rating = (double)rating / countViewRatingClient.Count;
            factorty.Products.Update(product); factorty.SaveChanges();
        }

        public async Task<Review?> GetReview(int id_product, int id_user)
        {
            using var factorty = await _databaseFactory.CreateDbContextAsync();
            return await factorty.Reviews.Where(i => i.IdProduct == id_product && i.IdClient == id_user).FirstOrDefaultAsync();
        }
    }
}

using ClientsProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsProject.DAL.Interfaces
{
    public interface IReviewService
    {
        public Task AddReview(Review review);
        public Task<Review?> GetReview(int id_product, int id_user);
    }
}

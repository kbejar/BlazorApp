using BlazorApp.Server.Interfaces;
using BlazorApp.Server.Models;
using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Server.Services
{
    public class PositionManager : IPosition
    {
        readonly DatabaseContext _dbContext = new();

        public PositionManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Position> GetPositionDetails()
        {
            try
            {
                return _dbContext.Positions.ToList();
            }
            catch
            {
                throw;
            }
        }

        public void AddPosition(Position position)
        {
            try
            {
                _dbContext.Positions.Add(position);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdatePositionDetails(Position position)
        {
            try
            {
                _dbContext.Entry(position).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Position GetPositionData(int id)
        {
            try
            {
                Position? position = _dbContext.Positions.Find(id);

                if (position != null)
                {
                    return position;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular user    
        public void DeletePosition(int id)
        {
            try
            {
                Position? position = _dbContext.Positions.Find(id);

                if (position != null)
                {
                    _dbContext.Positions.Remove(position);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

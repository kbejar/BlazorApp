using BlazorApp.Shared.Models;

namespace BlazorApp.Server.Interfaces
{
    public interface IPosition
    {
        public List<Position> GetPositionDetails();

        public void AddPosition(Position position);

        public void UpdatePositionDetails(Position position);

        public Position GetPositionData(int id);

        public void DeletePosition(int id);
    }
}

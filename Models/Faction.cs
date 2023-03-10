namespace Task9.Models
{
    public class Faction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int GetMaxId()
        {
            using (var db = new DatabaseContext())
            {
                return db.Factions.Count();
            }
        }
    }
}

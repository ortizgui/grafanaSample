using System;

namespace footballClubs.Models
{
    public class Club
    {
        public Club() {
            Id = Guid.NewGuid();
        }
        private Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Founded { get; set; }
        public int FifaClubWorldCup { get; set; }
    }
}
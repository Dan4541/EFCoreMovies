using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreMovies.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        private string _Name;
        public string Name {
            get
            {
                return _Name;
            }
            set
            {
                _Name = string.Join(' ', value.Split(' ').Select(x => x[0].ToString().ToUpper() + x.Substring(1).ToLower()).ToArray());
            }
        }
        public string Biography { get; set; }

        //[Column(TypeName = "Date")]
        public DateTime? DateOfBirth { get; set; }
        public List<MovieActor> MoviesActors { get; set; }
    }
}

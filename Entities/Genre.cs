using System.ComponentModel.DataAnnotations;

namespace EFCoreMovies.Entities
{
    public class Genre
    {
        //Restricciones a traves de atributos
        //[Key]
        public int Id { get; set; }

        //[StringLength(50)]
        //[MaxLength(50)]
        //[Required]
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
        public bool IsDeleted { get; set; }

    }
}

﻿using System.ComponentModel.DataAnnotations.Schema;

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

        public string PhotoURL { get; set; }

        //Como la edad se calcula no es necesario que se guarde el dato en la bd, notmapped ignora a edad y no lo guarda
        [NotMapped]
        public int? Age
        {
            get
            {
                if (!DateOfBirth.HasValue)
                {
                    return null;
                }

                var dateOfBirth = DateOfBirth.Value;
                var age = DateTime.Today.Year - dateOfBirth.Year;

                if(new DateTime(DateTime.Today.Year, dateOfBirth.Month, dateOfBirth.Day) > DateTime.Today)
                {
                    age--;
                }
                return age;
            }
        }
    }
}

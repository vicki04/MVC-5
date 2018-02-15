﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        [Required]
        [Display(Name ="Number In Stock")]
        public int NumberInStock { get; set; }
        public Genre Genre { get; set; }
        [Display(Name ="Genre")]
        public byte GenreId { get; set; }
        //public List<Movie> movies { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class RandomMoviesViewModel
    {
        public Movie Movie { get; set; }
        public List<Customers> customer { get; set; }

        
    }
}
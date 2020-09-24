using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ObrasBibliograficasWeb.Models
{
    public class BibliographiesModel
    {
        [Range(0, 100, ErrorMessage = "Some another error message insert here!")]

        public int Number { get; set; }
    }
}

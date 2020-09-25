using ObrasBibliograficasWeb.Query;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ObrasBibliograficasWeb.Models
{
    public class BibliographiesModel
    {
        [Range(0, 100, ErrorMessage = "Some another error message insert here!")]

        public int Number { get; set; }             
    }
}

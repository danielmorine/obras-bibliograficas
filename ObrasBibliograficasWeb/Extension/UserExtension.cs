﻿using ObrasBibliograficasWeb.Schemas;
using System.Collections.Generic;

namespace ObrasBibliograficasWeb.Extension
{
    public static class UserExtension
    {
        public static List<User> List()
        {
           return new List<User>
            {
                new User
                {
                    ID = 1,
                    Name = "Paulo Coelho",
                },
                new User
                {
                    ID = 2,
                    Name = "Joao Silva Neto"
                },
                new User
                {
                    ID = 3,
                    Name = "Manoel Neto de Almeida"
                },
                new User
                {
                    ID = 4,
                    Name = "Daniel Haro"
                },
                new User
                {
                    ID = 5,
                    Name = "Manoel Neto de Almeida"
                },
                new User
                {
                    ID = 6,
                    Name = "Beatriz Lima"
                },
                new User
                {
                    ID = 7,
                    Name = "Fernanda Reis Ribeiro"
                },
                new User
                {
                    ID = 8,
                    Name = "maria de fatima ortiz"
                },
                new User
                {
                    ID = 9,
                    Name = "Beatriz Lima"
                },
                new User
                {
                    ID = 10,
                    Name = "Michael"
                },
                new User
                {
                    ID = 11,
                    Name = "silvio"
                },
                 new User
                {
                    ID = 12,
                    Name = "Daniela de Oliveira"
                },
                 new User
                {
                    ID = 13,
                    Name = "Marcelo Pavão"
                },
                  new User
                {
                    ID = 14,
                    Name = "Arlette Pinheiro da Silva Torres"
                },                         
               {
                   new User
                   {
                       ID = 15,
                       Name = "José Ivaldo Gomes de Andrade Filho"
                   }
               }
            };
        }
    }
}

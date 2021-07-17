using System;

namespace IT.Valor.Core.DataTransferObjects.Author
{
    public class AuthorDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Pseudonym { get; set; }
    }
}

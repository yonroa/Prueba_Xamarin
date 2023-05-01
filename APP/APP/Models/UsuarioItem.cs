using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace APP.Models
{
    public class UsuarioItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}

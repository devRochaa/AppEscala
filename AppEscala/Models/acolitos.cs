﻿using SQLite;

namespace AppEscala.Models
{
    public class Acolitos
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Nome { get; set; }
    }
   
}

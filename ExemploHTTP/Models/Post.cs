using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploHTTP.Models
{
    public class Photo
    {
        private int id;
        public int Id {  get => id; set=> id = value; }
        public string Title { get; set; }
        public string url { get; set; }
    }
}

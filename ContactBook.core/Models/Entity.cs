using ContactBookService.data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookService.data.Models
{
    public class Entity : IEntity
    {
        public int Id { get; set; }
    }
}

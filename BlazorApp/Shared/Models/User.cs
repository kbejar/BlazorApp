using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Models
{
    public class User
    {
        public int Userid { get; set; }
        public string Lastname { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string? Middlename { get; set; }
        public string Address { get; set; } = null!;
        public string Cellnumber { get; set; } = null!;
        public string Emailid { get; set; } = null!;
        public int PositionId { get; set; }
        public int DepartmentId { get; set; }
        public int CompanyId { get; set; }

    }
}
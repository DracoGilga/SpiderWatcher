using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.UserDTO
{
    public class UpdatePasswordUserDTO
    {
        public int IdUser { get; init; }
        public string Password { get; init; }
        public bool Restore { get; init; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Data.Models.HttpModels
{
    public class UserResponse
    {
        public List<UserDto> Data { get; set; } = new List<UserDto>();
    }
}

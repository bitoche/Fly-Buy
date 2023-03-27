using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly.Services
{
    public enum StatusCode
    {
        UserNotFound = 0,        

        OK = 200,

        InternalServerError = 500
    }
}

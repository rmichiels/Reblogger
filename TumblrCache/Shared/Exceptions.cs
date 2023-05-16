using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumblrCache.Shared
{
    public class NoAuthorizedUserException : Exception
    {
        public NoAuthorizedUserException(string? message) : base(message) { }

    }
    public class NoUrlForGivenIdentifierException : Exception
    {
        public NoUrlForGivenIdentifierException(string? message) : base(message) { }
    }
}

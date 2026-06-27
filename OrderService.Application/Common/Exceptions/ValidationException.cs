using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;  

namespace OrderService.Application.Common.Exceptions
{
    public class ValidationException:Exception
    {
        public IDictionary<string, string[]> Errors { get; }

        public ValidationException(IEnumerable<ValidationFailure> failures)
        : base(" One or more validation failures occurred. ")
        {
            Errors = failures
          .GroupBy(x => x.PropertyName)
          .ToDictionary(
              g => g.Key,
              g => g.Select(x => x.ErrorMessage).ToArray());
        }
    }
}

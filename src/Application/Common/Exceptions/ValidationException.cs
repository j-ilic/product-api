using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
            : base("Validation error or errors have occurred")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            var failureGroups = failures
                .GroupBy(f => f.PropertyName, f => f.ErrorMessage);

            foreach (var failureGroup in failureGroups)
            {
                string propertyName = failureGroup.Key;
                string[] propertyFailures = failureGroup.ToArray();

                Errors.Add(propertyName, propertyFailures);
            }
        }

        public IDictionary<string, string[]> Errors { get; set; }
    }
}

using ContactBookService.data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.core.Services
{
    public class ServiceResult
    {
        public bool Succeeded { get; private set; }

        private readonly List<string> errors = new List<string>();
        public IEntity Entity { get; private set; }

        public ServiceResult()
        {
        }
        public ServiceResult(bool succeeded)
        {
            Succeeded = succeeded;
        }
        public ServiceResult(IEnumerable<string> errors)
        {
            Set(errors);
        }
        public ServiceResult Add(IEnumerable<string> errors)
        {
            foreach (string err in errors)
            {
                if (!string.IsNullOrEmpty(err))
                    this.errors.Add(err);
            }
            return this;
        }

        public ServiceResult Set(IEnumerable<string> errors)
        {
            this.errors.Clear();
            Add(errors);
            return this;
        }

        public ServiceResult Set(params string[] errors)
        {
            this.errors.Clear();
            Add(errors);
            return this;
        }
        public ServiceResult Set(bool success)
        {
            Succeeded = success;
            return this;
        }
        public ServiceResult Set(IEntity entity)
        {
            Entity = entity;
            return this;
        }
    }
}

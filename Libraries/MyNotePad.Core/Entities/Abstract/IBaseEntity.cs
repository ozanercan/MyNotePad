using System;
using System.Collections.Generic;
using System.Text;

namespace MyNotePad.Core.Entities.Abstract
{
    public interface IBaseEntity
    {
        public Guid Id { get; set; }
    }
}

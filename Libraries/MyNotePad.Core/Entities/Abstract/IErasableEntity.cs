using System;

namespace MyNotePad.Core.Entities.Abstract
{
    public interface IErasableEntity
    {
        public bool IsDeleted { get; set; }
    }
}

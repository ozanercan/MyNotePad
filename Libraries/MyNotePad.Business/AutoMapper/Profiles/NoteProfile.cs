using AutoMapper;
using MyNotePad.Entities.DataTransferObjects;
using MyNotePad.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNotePad.Business.AutoMapper.Profiles
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<NoteCreateDto, Note>();

            CreateMap<Note, NoteDto>();
        }
    }
}

using AutoMapper;
using MyNotePad.Business.Abstract;
using MyNotePad.Core.Business.Results.Abstract;
using MyNotePad.Core.Business.Results.Concrete;
using MyNotePad.DataAccess.Abstract;
using MyNotePad.Entities.DataTransferObjects;
using MyNotePad.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyNotePad.Business.Concrete
{
    public class NoteManager : INoteService
    {
        private readonly INoteDal _noteDal;
        private readonly IMapper _mapper;
        public NoteManager(INoteDal noteDal, IMapper mapper)
        {
            _noteDal = noteDal;
            _mapper = mapper;
        }

        public async Task<IBusinessResult> CreateNoteAsync(NoteCreateDto noteCreateDto)
        {
            if ((await _noteDal.GetAsync(p => p.NoteTitle.Equals(noteCreateDto.NoteTitle))).Data != null)
            {
                return new BusinessResult("Bu başlığı kullanan bir not sistemde zaten kayıtlı! Lütfen not başlığını değiştirin.", ProcessResultType.Warning, ResultType.CreateUnSuccess);
            }

            var noteEntity = _mapper.Map<Note>(noteCreateDto);

            noteEntity.CreatedDateTime = DateTime.Now;
            noteEntity.IsDeleted = false;

            var createResult = await _noteDal.CreateAsync(noteEntity);

            if (createResult.Exception != null)
            {
                return new BusinessResult("Sistemde Bir Hata Oluştu!", ProcessResultType.Error, ResultType.CreateUnSuccess);
            }

            if (createResult.Data != null && createResult.IsCommited)
            {
                return new BusinessResult("Not Başarıyla Kayıt Edildi!", ProcessResultType.Completed, ResultType.CreateSuccess);
            }
            else
            {
                return new BusinessResult("Not Bilinmeyen Bir Nedenden Dolayı Kayıt Edilemedi!", ProcessResultType.Completed, ResultType.CreateUnSuccess);
            }
        }

        public async Task<IBusinessDataResult<NoteDto>> GetDtoByNoteTitleAsync(string noteTitle)
        {
            NoteDto noteDto = null;
            var getResult = await _noteDal.GetAsync(p => p.IsDeleted == false && p.NoteTitle.Equals(noteTitle));

            if (getResult.Exception != null)
            {
                return new BusinessDataResult<NoteDto>("Sistemde Bir Hata Oluştu!", ProcessResultType.Error, ResultType.CreateUnSuccess, noteDto);
            }

            if (getResult.Data != null)
            {
                noteDto = _mapper.Map<NoteDto>(getResult.Data);
                return new BusinessDataResult<NoteDto>("Kayıtlar Listelendi!", ProcessResultType.Completed, ResultType.Success, noteDto);
            }
            else
            {
                noteDto = _mapper.Map<NoteDto>(getResult.Data);
                return new BusinessDataResult<NoteDto>("Sistemde Kayıtlı Not Bulunamadı!", ProcessResultType.Completed, ResultType.Success, noteDto);
            }
        }

        public async Task<IBusinessDataResult<List<NoteDto>>> GetNoteDtosAsync()
        {
            List<NoteDto> noteDtos = null;
            var getResult = await _noteDal.GetListAsync(p => p.IsDeleted == false);

            if (getResult.Exception != null)
            {
                return new BusinessDataResult<List<NoteDto>>("Sistemde Bir Hata Oluştu!", ProcessResultType.Error, ResultType.CreateUnSuccess, noteDtos);
            }

            if (getResult.Data != null)
            {
                noteDtos = _mapper.Map<List<NoteDto>>(getResult.Data);
                return new BusinessDataResult<List<NoteDto>>("Kayıtlar Listelendi!", ProcessResultType.Completed, ResultType.Success, noteDtos);
            }
            else
            {
                noteDtos = _mapper.Map<List<NoteDto>>(getResult.Data);
                return new BusinessDataResult<List<NoteDto>>("Sistemde Kayıtlı Not Bulunamadı!", ProcessResultType.Completed, ResultType.Success, noteDtos);
            }
        }
    }
}
